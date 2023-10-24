using ExcelDataReader;
using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.BUS
{
    public class DocDSSVLamKLTNBUS :ModelBus
    {
        public DocDSSVLamKLTNBUS()
        {
            base.load();
        }

        public bool checkApproriateSchoolYear(string startYear, string endYear)
        {
            int b = 0;
            bool checkParseInt = int.TryParse(startYear, out b);
            if(checkParseInt == false)
                return false;
            checkParseInt = int.TryParse(endYear, out b);

            if (checkParseInt == false)
                return false;

            int st = int.Parse(startYear);
            int e = int.Parse(endYear);
            
            if (st < 0 || e < 0)
                return false;

            if (st <= e)
                return true;
            return false;
        }
        public DataTable getLastInputSem()
        {
            string sql = "select top 1 HocKi, NamHoc from ThoiGian order by ID desc";
            return sQLfunction.GetDataToTable(sql);
        }

        public ThoiGian getLastSemToObject()
        {
            DataTable dt = new DataTable();
            dt = getLastInputSem();
            ThoiGian tg = new ThoiGian();
            foreach (DataRow r in dt.Rows)
            {
                tg = new ThoiGian(r["HocKi"].ToString(), r["NamHoc"].ToString());
            }
            return tg;
        }
        public bool checkArroriateSem(ThoiGian inputSem)
        {
            ThoiGian lastSem = getLastSemToObject();
            if (lastSem.getNamHocBD() > inputSem.getNamHocBD())
                return false;
            else
            {
                if (lastSem.getNamHocBD() == inputSem.getNamHocBD())
                    if (lastSem.getHocKi() <= inputSem.getHocKi())
                        return true;
                    else
                        return false;
                else
                    return true;
            }
        }

        public bool checkMatchSemWithDAMH(int idTG)
        {
            string sql = string.Format("select count(ID) from DoAn where ID_ThoiGianToChuc = {0}", idTG);
            int soLuong = int.Parse(sQLfunction.RunQuery(sql));
            if (soLuong == 0)
                return true;
            return false;
        }

        public DataTable getEcelToDatatable(string path)
        {
            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var r = ExcelReaderFactory.CreateReader(stream);
            var re = r.AsDataSet();
            var tab = re.Tables.Cast<DataTable>();
            DataTable dt = new DataTable();
            stream.Close();
            stream.Dispose();
            r.Close();
            r.Dispose();
            foreach (DataTable tb in tab)
            {
                dt = tb;
            }
            return dt;
        }

        public bool checkApproriateExcel(DataTable dt)
        {
            if (dt.Rows.Count < 1 || dt.Columns.Count != 6)
                return false;
            return true;
        }

        public int getHocKiNamHoc(ThoiGian tg)
        {
            string sql = "select ISNULL(ID, 0 ) from ThoiGian where HocKi = '" + tg.HocKi +
                        "' and NamHoc = '" + tg.NamHoc + "'";
            string result = sQLfunction.RunQuery(sql);
            if (result == null)
                return 0;
            return int.Parse(result);
        }

        public int insertHocKiNamHoc(ThoiGian tg)
        {
            string sql = "insert into ThoiGian(HocKi, NamHoc) values('"
                        + tg.HocKi + "','"
                        + tg.NamHoc + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public string getIDDoAn(string mssv, int idTG)
        {
            string sql = string.Format("select ID_DA " +
                            "from SV_DAMH svda, DoAn da " +
                            "where MSSV = '{0}' " +
                            "and svda.ID_DA = da.ID and ID_ThoiGianToChuc = {1}", mssv, idTG);
            return sQLfunction.RunQuery(sql);
        }

        public string getMaGVHD(string idDoAn)
        {
            string sql = string.Format("select GVHD from DoAn where ID = '{0}'", idDoAn);
            return sQLfunction.RunQuery(sql);
        }
        public string getDeTaiKLTNWithSV(string idDeTai, string mssv)
        {
            string sql = string.Format("select ID_KLTN from SV_KLTN where ID_KLTN = '{0}' and MSSV = '{1}'", idDeTai, mssv);
            return sQLfunction.RunQuery(sql);
        }    

        public string getDeTaiKLTN(string idDeTai)
        {
            string sql = string.Format("select ID from KLTN where ID = '{0}'", idDeTai);
            return sQLfunction.RunQuery(sql);
        }
        public int insertKLTN(KLTN khoaLuan)
        {
            string sql = string.Format("insert into KLTN(ID, ID_ThoiGianToChuc, GVHD, TenKLTN) " +
                                        " values('{0}', {1}, '{2}', N'{3}')", khoaLuan.ID, khoaLuan.ThoiGianToChuc, khoaLuan.GVHD1, khoaLuan.TenDeTai);
            return sQLfunction.RunNonQuery(sql);
        }    

        public int insertSV_KLTN(string mssv, string idDeTai)
        {
            string sql = string.Format("insert into SV_KLTN(MSSV, ID_KLTN) " +
                                "values('{0}', '{1}')", mssv, idDeTai);
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateKLTNInfo(string idKLTN, string tenDeTai)
        {
            string sql = string.Format("update KLTN set TenKLTN = N'{0}' where ID = '{1}'", tenDeTai, idKLTN);
            return sQLfunction.RunNonQuery(sql);
        }   
        
        public int getIDLatestDAMH()
        {
            string sql = "select distinct ID_ThoiGianToChuc from DoAn order by ID_ThoiGianToChuc";
            return int.Parse(sQLfunction.RunQuery(sql));
        }

        public int updateSVLamKLTNFromDT(DataTable dt, int tgID)
        {
            int idTGDoAn = getIDLatestDAMH();
            int temp = 0;
            for(int i = 1; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (getIDDoAn(dr[0].ToString(), idTGDoAn) != null)
                {
                    string idDoAn = getIDDoAn(dr[0].ToString(), idTGDoAn);
                    if(getDeTaiKLTN(idDoAn) == null)
                    {
                        string maGV = getMaGVHD(idDoAn);

                        KLTN khoaLuan = new KLTN(idDoAn, dr[5].ToString().ToUpper(), tgID, maGV);
                        if (insertKLTN(khoaLuan) == 0)
                            return 0;
                        if (insertSV_KLTN(dr[0].ToString(), idDoAn) == 0)
                            return 0;
                    }    
                    else
                    {
                        if (getDeTaiKLTNWithSV(idDoAn, dr[0].ToString()) == null)
                        {
                            if (insertSV_KLTN(dr[0].ToString(), idDoAn) == 0)
                                return 0;
                        }
                        else
                        {
                            if (updateKLTNInfo(idDoAn, dr[5].ToString().ToUpper()) == 0)
                                return 0;
                        }
                        
                    }
                }
            }    
            
            return 1;
        }

        public DataTable getListKLTN(int idTG)
        {
            string sql = string.Format("select sv.MSSV, sv.HoLot + ' ' + sv.Ten as 'HoTen', " +
                                "EmailOU, TenKLTN, TRIM(gv.HocVi) + '. ' + gv.HoTen as 'GVHD' " +
                                "from SinhVien sv, SV_KLTN svkl, KLTN kl, GiangVien gv " +
                                "where sv.MSSV = svkl.MSSV and svkl.ID_KLTN = kl.ID and " +
                                "kl.GVHD = gv.MaGV and ID_ThoiGianToChuc = {0}", idTG);
            return sQLfunction.GetDataToTable(sql);
        }
    }
}