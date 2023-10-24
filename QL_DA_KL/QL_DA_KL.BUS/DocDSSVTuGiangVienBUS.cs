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
    public class DocDSSVTuGiangVienBUS :ModelBus
    {
        public DocDSSVTuGiangVienBUS()
        {
            base.load();
        }    

        public DataTable getHocKiFromDB()
        {
            string sql = "select top 1 * from ThoiGian order by ID desc";
            return sQLfunction.GetDataToTable(sql);
        }

        public ThoiGian tranferDTtoThoiGianObject()
        {
            DataTable dt = getHocKiFromDB();
            ThoiGian tg = new ThoiGian();
            foreach (DataRow dr in dt.Rows)
            {
                tg = new ThoiGian(int.Parse(dr["ID"].ToString()),
                                  dr["HocKi"].ToString(),
                                  dr["NamHoc"].ToString());
            }
            return tg;
        } 
        
        public DataTable getDSGV()
        {
            string sql = "select MaGV, HoTen from GiangVien where ThamGiaKLTN = 1";
            return sQLfunction.GetDataToTable(sql);
        }

        public bool checkApproriateExcel(DataTable dt)
        {
            if (dt.Rows.Count < 1 || dt.Columns.Count != 2)
                return false;
            return true;
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
        public bool checkExsistSV(string mSSV)
        {
            string sql = "select MSSV from SinhVien where MSSV = '" + mSSV + "'";
            string result = sQLfunction.RunQuery(sql);
            if (result == null)
                return false;
            return true;
        }
        public int insertDoAn(DoAn da, string maGV, int id_TG)
        {
            string sql = String.Format("insert into DoAn(ID, ID_ThoiGianToChuc, GVHD) values('{0}',{1},'{2}')",
                                 da.ID1, id_TG, maGV);
            return sQLfunction.RunNonQuery(sql);
        }

        public int insertSV_DAMH(string id_DA, string mssv)
        {
            string sql = String.Format("insert into SV_DAMH values('{0}', '{1}')",
                                            mssv, id_DA);
            return sQLfunction.RunNonQuery(sql);
        }   
        
        public string getCurrrentFormattedShortHocKiNamHienTai(ThoiGian tg)
        {
            DateTime current_year = DateTime.Now;
            string year = current_year.Year.ToString();
            string result = tg.HocKi.Trim() + year;
            return result;
        }

        public string getExistDoAnThisHK(string mssv, string curentHK)
        {
            string sql = String.Format("select ID_DA from SV_DAMH where MSSV = '{0}' and ID_DA like '{1}%'",
                                        mssv, curentHK);
            return sQLfunction.RunQuery(sql);
        }

        public int updateDoAn(string id_DA, string msGV)
        {
            string sql = String.Format("update DoAn set GVHD = '{0}' where ID = '{1}'", msGV, id_DA);
            return sQLfunction.RunNonQuery(sql);
        }

        public bool getLamLaiDoAnInfo(string mssv)
        {
            string sql = "select LamLaiDoAn from SinhVien where MSSV = '" + mssv + "'";
            return bool.Parse(sQLfunction.RunQuery(sql));
        }

        public bool checkNamLamLaiDoAnInfo(string mssv)
        {
            string sql = "select NamLamLaiDoAn from SinhVien where MSSV = '" + mssv + "'";
            string result = sQLfunction.RunQuery(sql);
            if (result == null)
                return true;
            else
            {
                DateTime current_year = DateTime.Now;
                int year = current_year.Year;
                if (year == int.Parse(result) || int.Parse(result) == 0)
                    return true;
                else
                    return false; 
            }    
        }


        public string getTeamMate(string mssv)
        {
            string sql = String.Format("select MSSVBanCungNhom from SinhVien where MSSV = '{0}'", mssv);
            return sQLfunction.RunQuery(sql);
        }    

        public DataTable getSVInfo(string mssv)
        {
            string sql = String.Format("select MSSV, MSSVBanCungNhom, Nganh, GPA" +
                                        " from SinhVien where MSSV = '{0}'", mssv);
            return sQLfunction.GetDataToTable(sql);
        }

        public bool checkMatchTeamMateInfo(string mssv, string mssvTeamMate)
        {
            DataTable dtTeamMate = getSVInfo(mssvTeamMate);
            DataTable dtSinhVien = getSVInfo(mssv);
            if (dtTeamMate.Rows[0]["MSSV"].ToString().Trim().Equals(dtSinhVien.Rows[0]["MSSV"].ToString().Trim()))
                return false;
            if (!dtTeamMate.Rows[0]["MSSVBanCungNhom"].ToString().Trim().Equals(dtSinhVien.Rows[0]["MSSV"].ToString().Trim()))
                return false;
            else
            {
                if (!dtTeamMate.Rows[0]["Nganh"].ToString().Trim().Equals(dtSinhVien.Rows[0]["nganh"].ToString().Trim()))
                    return false;
                else
                {
                    if (!dtTeamMate.Rows[0]["GPA"].ToString().Trim().Equals(dtSinhVien.Rows[0]["GPA"].ToString().Trim()))
                        return false;
                    else
                        return true;
                }    
            }    
        }

        public int checkTeamMate(DataTable dt, string mssv)
        {
            if (getTeamMate(mssv) == null)
                return 0;
            else
            {
                string mssvTeamMate = getTeamMate(mssv);
                string mssvteamMateInExcel = null;
                for (int i = 2; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr[0].ToString().Equals(mssvTeamMate.Trim()))
                    {
                        mssvteamMateInExcel = dr[0].ToString();
                        break;
                    }
                }

                if (mssvteamMateInExcel == null)
                    return -1;
                else
                {
                    if (checkMatchTeamMateInfo(mssv, mssvteamMateInExcel))
                        return 1;
                    return -1;
                }
            }
        }

        public int updateInfoSVWithFailTeamMateInfo(string mssv)
        {
            string sql = String.Format("update SinhVien set MSSVBanCungNhom = null where MSSV = '{0}'", mssv);
            return sQLfunction.RunNonQuery(sql);
        }

        public int deleteSVFromDT(ref DataTable dt, String mssv)
        {
            DataRow[] rows = dt.Select(String.Format("MSSV = '{0}'", mssv));

            foreach (DataRow row in rows)
                dt.Rows.Remove(row);
            return rows.Length;
        }

        public int readDataTableToDB(DataTable dataTable, string maGV, ThoiGian tg ,ref List<String> success, ref DataTable failed)
        {
            string currentHK = getCurrrentFormattedShortHocKiNamHienTai(tg);
            for (int i = 2; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                if (!checkExsistSV(dr[0].ToString()))
                    failed.ImportRow(dr);
                else
                {
                    DoAn da = new DoAn(maGV, tg.HocKi, tg.ID1);
                    if (getExistDoAnThisHK(dr[0].ToString(), currentHK) == null)
                    {
                        if (getLamLaiDoAnInfo(dr[0].ToString()) == true && checkNamLamLaiDoAnInfo(dr[0].ToString()))
                            failed.ImportRow(dr);
                        else
                        {
                            
                            if (checkTeamMate(dataTable, dr[0].ToString()) == -1)
                            {
                                if(updateInfoSVWithFailTeamMateInfo(dr[0].ToString()) == 0)
                                    return 0;
                                if (insertDoAn(da, maGV, tg.ID1) == 0)
                                    return 0;
                                else
                                {
                                    if (insertSV_DAMH(da.ID1, dr[0].ToString()) == 0)
                                        return 0;
                                    else
                                        success.Add(dr[0].ToString());
                                }
                            }
                            else
                            {
                                if (checkTeamMate(dataTable, dr[0].ToString()) == 1)
                                {
                                    string teamMate = getTeamMate(dr[0].ToString());
                                    if (insertDoAn(da, maGV, tg.ID1) == 0)
                                        return 0;
                                    else
                                    {
                                        if (insertSV_DAMH(da.ID1, dr[0].ToString()) == 0 || insertSV_DAMH(da.ID1, teamMate) == 0)
                                            return 0;
                                        else
                                        {
                                            success.Add(dr[0].ToString());
                                            success.Add(teamMate);
                                            deleteSVFromDT(ref dataTable, teamMate);
                                        }                                              
                                    }
                                }
                                else
                                {
                                    if (insertDoAn(da, maGV, tg.ID1) == 0)
                                        return 0;
                                    else
                                    {
                                        if (insertSV_DAMH(da.ID1, dr[0].ToString()) == 0)
                                            return 0;
                                        else
                                            success.Add(dr[0].ToString());
                                    }
                                }    
                            }                            
                        }
                            
                    }
                    else
                    {
                        string id_DAMH = getExistDoAnThisHK(dr[0].ToString(), currentHK);
                        if (updateDoAn(id_DAMH, maGV) == 0)
                            return 0;
                        success.Add(dr[0].ToString());
                    }    
                }    
            }
            return 1;
        }

        public DataTable getSucessFromDT(List<String> list)
        {
            StringBuilder sql = new StringBuilder("select sv.* " +
                                "from SinhVien sv, SV_DAMH svda, DoAN da, GiangVien gv" +
                                " where sv.MSSV = svda.MSSV and svda.ID_DA = da.ID and da.GVHD = gv.MaGV and ( ");
            for (int i = 0; i < list.Count; i++)
            {
               
                string condition;
                if(i == 0)
                    condition = String.Format("sv.MSSV = '{0}'", list[i]);
                else
                    condition = String.Format(" or sv.MSSV = '{0}'", list[i]);
                sql.Append(condition);
            }
            sql.Append(" )");
            return sQLfunction.GetDataToTable(sql.ToString());
        }
    }
}
