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
    public class DocDSSVLamDAMHBUS : ModelBus
    {
        public DocDSSVLamDAMHBUS()
        {
            base.load();
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

        public DataTable getLastInputSem()
        {
            string sql = "select top 1 HocKi, NamHoc from ThoiGian order by ID desc";
            return sQLfunction.GetDataToTable(sql);
        }

        public int insertHocKiNamHoc(ThoiGian tg)
        {
            string sql = "insert into ThoiGian(HocKi, NamHoc) values('"
                        + tg.HocKi + "','"
                        + tg.NamHoc + "')";
            return sQLfunction.RunNonQuery(sql);
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
            if( dt.Rows.Count < 1 || dt.Columns.Count != 20)
                return false;
            return true;
        }

        public bool checkApproriateSchoolYear(string startYear, string endYear)
        {

            int b = 0;
            bool checkParseInt = int.TryParse(startYear, out b);
            if (checkParseInt == false)
                return false;
            checkParseInt = int.TryParse(endYear, out b);

            if (checkParseInt == false)
                return false;

            int st = int.Parse(startYear);
            int e = int.Parse(endYear);

            if (st <= e)
                return true;
            return false;
        }
        public ThoiGian getLastSemToObject()
        {
            DataTable dt = new DataTable();
            dt = getLastInputSem();
            ThoiGian tg = new ThoiGian();
            foreach(DataRow r in dt.Rows)
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

        public string formatStringForSQL(string s)
        {
            if (s == "" || s == null)
                return "null";
            return "'" + s + "'";
        }

        public string formatStringForSQLNChar(string s)
        {
            if (s == "" || s == null)
                return "null";
            return "N'" + s + "'";
        }

        public string formatGPA(double gpa)
        {
            if (gpa == 0)
                return "null";
            return gpa.ToString();
        }

        public string checkExistDeTaiThisHK(string mssv, int idTg)
        {
            string sql = String.Format("select svda.ID_DA" +
                " from SV_DAMH svda, DoAn da" +
                " where MSSV = '{0}' and ID_ThoiGianToChuc = {1}", mssv, idTg);
            string result = sQLfunction.RunQuery(sql);
            return result;
        }

        public int deleteExistDeTai(string mssv, string idDoAn)
        {
            string sql = String.Format("Delete from DoAn where ID = '{0}'", idDoAn);
            if (sQLfunction.RunNonQuery(sql) == 0)
                return 0;
            return 1;
        }

        public int insertSV(SinhVien sv)
        {
            string sql = "insert into SinhVien values ("
                            + formatStringForSQL(sv.MSSV1) + ",N"
                            + formatStringForSQL(sv.HoLot) + ",N"
                            + formatStringForSQL(sv.Ten) + ","
                            + formatStringForSQL(sv.SDT1) + ","
                            + formatStringForSQL(sv.EmailOU) + ","
                            + formatStringForSQL(sv.EmailCaNhan) + ", "
                            + formatStringForSQLNChar(sv.ChuyenNganh) + ","
                            + formatStringForSQL(sv.MssvBanCungNhom) + ",'"
                            + sv.LamKLTN.ToString() + "',"
                            + formatStringForSQL(sv.NVGV11) + ","
                            + formatStringForSQL(sv.NVGV21) + ","
                            + "0, 0, "
                            + formatStringForSQL(sv.Nganh) + ","
                            + formatGPA(sv.gPA) + ")";
            return sQLfunction.RunNonQuery(sql);
        }    
        public bool convertToBool(string s)
        {
            if (s == "Có")
                return true;
            return false;
        }
        public double convertToDoube(string s)
        {
            if (s == "" || s == null )
                return 0;
            return double.Parse(s);
        }
        public string findGV(string tenGV)
        {
            if (tenGV == null || tenGV == "")
                return null;
            string[] temp = tenGV.Split('.'); 
            string sql = "select MaGV from GiangVien where HoTen like N'%" + temp[1].Trim() + "'";
            return sQLfunction.RunQuery(sql);
        }


        public List<SinhVien> tranferDSSVtoList(DataTable dt)
        {
            List<SinhVien> list = new List<SinhVien>();
                
            for(int i = 1; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                SinhVien sv = new SinhVien(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                                           dr[4].ToString(), dr[0].ToString(), dr[5].ToString(),
                                           dr[10].ToString(), convertToBool(dr[16].ToString()), findGV(dr[18].ToString()),
                                           findGV(dr[19].ToString()), dr[7].ToString(), convertToDoube(dr[17].ToString()),
                                           dr[8].ToString());
                list.Add(sv);
            }
            return list;
        }

        public bool checkExistSV(string mssv)
        {
            string sql = "select MSSV from SinhVien where MSSV = '" + mssv + "'";
            string result = sQLfunction.RunQuery(sql);
            if(result == null)
                return false;
            return true;
        }    

        public int updateSV(SinhVien sv)
        {
            string sql = "update SinhVien set LamLaiDoAn = 1, NamLamLaiDoAn = year(GETDATE())," +
                         " SDT = " + formatStringForSQL(sv.SDT1) + ","
                         + "EmailCaNhan = " + formatStringForSQL(sv.EmailCaNhan) + ","
                         + "MSSVBanCungNhom = " + formatStringForSQL(sv.MssvBanCungNhom) + ","
                         + "GPA = " + sv.gPA
                         + ",NVGVHD1 = " + formatStringForSQL(sv.NVGV11)
                         + ",NVGVHD2 = " + formatStringForSQL(sv.NVGV21)
                         + " where MSSV = " + formatStringForSQL(sv.MSSV1);
            return sQLfunction.RunNonQuery(sql);
        }

        public int deletedExistedDinhHuong(string mssv)
        {
            string sql = "delete from SV_DinhHuong where MSSV = '" + mssv + "'";
            return sQLfunction.RunNonQuery(sql);
        } 

        public int updateOnlyInfo(SinhVien sv)
        {
            string sql = "update SinhVien set "
                        + " SDT = " + formatStringForSQL(sv.SDT1) + ","
                        + "EmailCaNhan = " + formatStringForSQL(sv.EmailCaNhan) + ","
                        + "MSSVBanCungNhom = " + formatStringForSQL(sv.MssvBanCungNhom) + ","
                        + "GPA = " + sv.gPA
                        + ", LamKLTN = '" + sv.LamKLTN 
                        + "',NVGVHD1 = " + formatStringForSQL(sv.NVGV11)
                        + ",NVGVHD2 = " + formatStringForSQL(sv.NVGV21)
                        + " where MSSV = " + formatStringForSQL(sv.MSSV1);
            return sQLfunction.RunNonQuery(sql);
        }

        public bool checkExistDAMH(string mssv)
        {
            string sql = String.Format("select top 1 ID_DA from SV_DAMH where MSSV = '{0}'", mssv);
            string result = sQLfunction.RunQuery(sql);
            if (result == null)
                return false;
            return true;
        }

        public int insertListToDB(List<SinhVien> listSV, int idTG)
        {
            for(int i = 0; i < listSV.Count; i++)
            {
                if (checkExistSV(listSV[i].MSSV1) == false)
                {
                    if (insertSV(listSV[i]) < 1)
                        return 0;
                }
                else
                {
                    deletedExistedDinhHuong(listSV[i].MSSV1);
                    if (checkExistDeTaiThisHK(listSV[i].MSSV1, idTG) != null)
                    {
                        if (deleteExistDeTai(listSV[i].MSSV1, checkExistDeTaiThisHK(listSV[i].MSSV1, idTG)) == 0)
                            return 0;
                        if (updateOnlyInfo(listSV[i]) < 1)
                            return 0;
                    }
                    if (!checkExistDAMH(listSV[i].MSSV1))
                    {
                        if (updateOnlyInfo(listSV[i]) < 1)
                            return 0;
                    }
                    else
                    {
                        if (deleteExistDeTai(listSV[i].MSSV1, checkExistDeTaiThisHK(listSV[i].MSSV1, idTG)) == 0)
                            return 0;
                        if (updateOnlyInfo(listSV[i]) < 1)
                            return 0;
                    }                            
                }    
            }
            return 1;
        }

        public DataTable getInsertedDSSV()
        {
            string sql = "select * from SinhVien where ((LamLaiDoAn = 1 and NamLamLaiDoAn = year(getdate()))"
                         + "or(MSSV not in (select MSSV from SV_DAMH)))";
            return sQLfunction.GetDataToTable(sql);
        }

        public List<DinhHuong_SV> getDinhHuongCuaSinhVienFromDataTable(DataTable dt)
        {
            List<DinhHuong_SV> list = new List<DinhHuong_SV>();
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string[] dinhHuong = dr[6].ToString().Split(',');
                for(int j = 0; j < dinhHuong.Length; j++)
                {
                    int id_dh = getDinhHuongID(dinhHuong[j]);
                    if (id_dh == -1)
                        if (insertDinhHuong(dinhHuong[j]) < 1)
                            return null;
                    id_dh = getDinhHuongID(dinhHuong[j]);
                    DinhHuong_SV dh = new DinhHuong_SV(id_dh, dr[1].ToString());
                    list.Add(dh);
                }                   
            }
            return list;
        }    

        public int insertDinhHuong(string DinhHuong)
        {
            string sql = "insert into DinhHuongDeTai values(N'" + DinhHuong + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int getDinhHuongID(string DinhHuong)
        {
            string sql = "select ID from DinhHuongDeTai where UPPER(DinhHuong) = N'" + DinhHuong.ToUpper() + "'";
            string result = sQLfunction.RunQuery(sql);
            if (result == null)
               return -1;
            else
               return int.Parse(result);
        }

        public int insertDinhHuong_SV(DinhHuong_SV dh)
        {
            string sql = "insert into SV_DinhHuong values('" + dh.MSSV1 + "'," + dh.ID_DinhHuong1 + ")";
            return sQLfunction.RunNonQuery(sql);
        }

          
        public int insertListOfDInhHuongToDB(List<DinhHuong_SV> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                insertDinhHuong_SV(list[i]);
            }
            return 1;
        }

        public void closeConnection()
        {
            base.close();
        }
    }
}
