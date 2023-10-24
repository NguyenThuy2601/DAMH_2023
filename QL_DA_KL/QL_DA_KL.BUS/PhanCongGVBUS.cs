using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DA_KL.BUS
{
    public class PhanCongGVBUS :ModelBus
    {
        public PhanCongGVBUS()
        {
            base.load();
        }

        public DataTable getlatestInputHK()
        {
            string sql = "select top 1 * from ThoiGian order by ID desc ";
            return sQLfunction.GetDataToTable(sql);
        }

        public ThoiGian tranferToTGObject()
        {
            DataTable dt = getlatestInputHK();
            ThoiGian tg = new ThoiGian();
            foreach (DataRow row in dt.Rows)
                tg = new ThoiGian(int.Parse(row["ID"].ToString()),
                                row["HocKi"].ToString(), row["NamHoc"].ToString());
            return tg;
        }

        public DataTable getSVLamKLTNChuaCoGVHD()
        {
            string sql = "select sv.MSSV, MSSVBanCungNhom, NVGVHD1, NVGVHD2, GPA, Nganh, string_agg(DinhHuong, ', ') as DinhHuong " +
                         "from SinhVien sv, SV_DinhHuong svdh, DinhHuongDeTai dh " +
                         "where sv.MSSV = svdh.MSSV and svdh.ID_DinhHuong = dh.ID and GPA >= 2.5 and ( (LamLaiDoAn = 1 and NamLamLaiDoAn = year(getdate()))" +
                         " or sv.MSSV not in (select MSSV from SV_DAMH) )" +
                         " group by sv.MSSV,  MSSVBanCungNhom, NVGVHD1, NVGVHD2, GPA, Nganh";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getSVLamDAMHChuaCoGVHD(ThoiGian tg)
        {
            string sql = String.Format("select sv.MSSV, MSSVBanCungNhom, NVGVHD1, NVGVHD2, GPA, Nganh, string_agg(DinhHuong, ', ') as DinhHuong" +
                         " from SinhVien sv, SV_DinhHuong svdh, DinhHuongDeTai dh" +
                         " where sv.MSSV = svdh.MSSV and svdh.ID_DinhHuong = dh.ID " +
                         " and ( (LamLaiDoAn = 1 and NamLamLaiDoAn = year(getdate()))" +
                         " or sv.MSSV not in (select MSSV from SV_DAMH svda, DoAn da where svda.ID_DA = da.ID and da.ID_ThoiGianToChuc = {0}) )" +
                         " group by sv.MSSV,  MSSVBanCungNhom, NVGVHD1, NVGVHD2, GPA, Nganh", tg.ID1);
            return sQLfunction.GetDataToTable(sql);
        }

        public int deletedThisHkExistDAMH(ThoiGian tg)
        {
            string sql = String.Format("delete from DoAn where ID_ThoiGianToChuc = {0}", tg.ID1);
            return sQLfunction.RunNonQuery(sql);
        }

        public List<GVHDRespone> getGVHDAndNumOfDeTai()
        {
            string sql = "select MaGV, HocVi, count(da.ID) as SoLuong" +
                         " from GiangVien gv, DoAn da" +
                         " where gv.MaGV = da.GVHD" +
                         " group by MaGV, HocVi";
            DataTable dt = sQLfunction.GetDataToTable(sql);

            return tranferToListGVHDResponse(dt);
        }

        public string getHocViGV(string maGV)
        {
            string sql = "select HocVi from GiangVien where MaGV = '" + maGV + "'";
            return sQLfunction.RunQuery(sql);
        }

        public int getSoLuongDeTaiKLTN(string maGV)
        {
            string sql = String.Format("select count(GVHD) from DoAn da, SV_DAMH svda, SinhVien sv" +
                                        " where da.ID = svda.ID_DA and svda.MSSV = sv.MSSV" +
                                        " and sv.GPA >= 2.5 and da.GVHD = '{0}'", maGV);
            string result = sQLfunction.RunQuery(sql);
            if (result == null)
                return 0;
            else
                return int.Parse(result);
        }

        public List<GVHDRespone> tranferToListGVHDResponse(DataTable dt)
        {
            List<GVHDRespone> list = new List<GVHDRespone>();
            foreach (DataRow dr in dt.Rows)
            {
                GVHDRespone gv_respone = new GVHDRespone(dr["MaGV"].ToString(), int.Parse(dr["SoLuong"].ToString()), dr["HocVi"].ToString());
                list.Add(gv_respone);
            }
            return list;
        }

        public bool checkNumOfDeTai(string hocVi, int soLuong)
        {
            if (hocVi.Trim().Equals("ThS") && soLuong >= 5)
            {
                if (soLuong >= 5)
                    return false;
                else
                    return true;
            }    
            else
            {
                if (soLuong >= 10)
                    return false;
                else
                    return true;
            }
        }

        public int insertDoAn(DoAn da, int id_TG)
        {
            string sql = String.Format("insert into DoAn(ID, ID_ThoiGianToChuc, GVHD) values('{0}',{1},'{2}')",
                                 da.ID1, id_TG, da.GVHD1);
            return sQLfunction.RunNonQuery(sql);
        }

        public int insertSV_DAMH(string id_DA, string mssv)
        {
            string sql = String.Format("insert into SV_DAMH values('{0}', '{1}')",
                                            mssv, id_DA);
            return sQLfunction.RunNonQuery(sql);
        }

        public int findAndUpdate(string maGV, List<GVHDRespone> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(maGV.Equals( list[i].MaGV))
                {
                    list[i].updateDeTai();
                    return 1;
                }                       
            }
            return 0;
        }

        public GVHDRespone findGVHD(List<GVHDRespone> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (checkNumOfDeTai(list[i].HocVi, list[i].NumOfDeTai))
                    return list[i];
            }
            return null;
        }

        public int setGVHDForOneSV(ThoiGian tg, DataRow currentSV)
        {
            int soLuong = getSoLuongDeTaiKLTN(currentSV["NVGVHD1"].ToString());
            string hocVi = getHocViGV(currentSV["NVGVHD1"].ToString());
            if (checkNumOfDeTai(hocVi, soLuong))
            {
                DoAn da = new DoAn(currentSV["NVGVHD1"].ToString(), tg.HocKi, tg.ID1);
                if (insertDoAn(da, tg.ID1) == 0)
                    return 0;
                if (insertSV_DAMH(da.ID1, currentSV["MSSV"].ToString()) == 0)
                    return 0;
            }
            else
            {
                soLuong = getSoLuongDeTaiKLTN(currentSV["NVGVHD2"].ToString());
                hocVi = getHocViGV(currentSV["NVGVHD2"].ToString());
                if (checkNumOfDeTai(hocVi, soLuong))
                {
                    DoAn da = new DoAn(currentSV["NVGVHD2"].ToString(), tg.HocKi, tg.ID1);
                    if (insertDoAn(da, tg.ID1) == 0)
                        return 0;
                    if (insertSV_DAMH(da.ID1, currentSV["MSSV"].ToString()) == 0)
                        return 0;
                }
            }
            return 1;
        }

        public int setGVHDForTwoSV(ThoiGian tg, DataRow currentSV1, DataRow[] currentSV2)
        {
            
            int soLuong = getSoLuongDeTaiKLTN(currentSV1["NVGVHD1"].ToString());
            string hocVi = getHocViGV(currentSV1["NVGVHD1"].ToString());
            if (checkNumOfDeTai(hocVi, soLuong))
            {
                DoAn da = new DoAn(currentSV1["NVGVHD1"].ToString(), tg.HocKi, tg.ID1);
                if (insertDoAn(da, tg.ID1) == 0)
                    return 0;
                if (insertSV_DAMH(da.ID1, currentSV1["MSSV"].ToString()) == 0 )
                    return 0;
                if (insertSV_DAMH(da.ID1, currentSV2[0]["MSSV"].ToString()) == 0)
                    return 0;
            }
            else
            {
                soLuong = getSoLuongDeTaiKLTN(currentSV1["NVGVHD2"].ToString());
                hocVi = getHocViGV(currentSV1["NVGVHD2"].ToString());
                if (checkNumOfDeTai(hocVi, soLuong))
                {
                    DoAn da = new DoAn(currentSV1["NVGVHD2"].ToString(), tg.HocKi, tg.ID1);
                    if (insertDoAn(da, tg.ID1) == 0)
                        return 0;
                    if (insertSV_DAMH(da.ID1, currentSV1["MSSV"].ToString()) == 0)
                        return 0;
                    if (insertSV_DAMH(da.ID1, currentSV2[0]["MSSV"].ToString()) == 0)
                        return 0;
                }        
            }
            return 1;
        }

        public bool checkMacthTeamMate(DataRow[] teamMate, DataRow currentSV)
        {
            if (teamMate[0]["MSSV"].ToString().Trim().Equals(currentSV["MSSV"].ToString().Trim()))
                return false;
            if (!teamMate[0]["MSSVBanCungNhom"].ToString().Trim().Equals(currentSV["MSSV"].ToString().Trim()))
                return false;
            else
            {
                if (!teamMate[0]["Nganh"].ToString().Trim().Equals(currentSV["Nganh"].ToString().Trim()))
                    return false;
                else
                    if (!teamMate[0]["NVGVHD1"].ToString().Trim().Equals(currentSV["NVGVHD1"].ToString().Trim()))
                        return false;
                    else
                        if (!teamMate[0]["NVGVHD2"].ToString().Trim().Equals(currentSV["NVGVHD2"].ToString().Trim()))
                            return false;
                        else
                            return true;
            }
        }

        public int updateInfoSVWithFailTeamMateInfo(string mssv)
        {
            string sql = String.Format("update SinhVien set MSSVBanCungNhom = null where MSSV = '{0}'", mssv);
            return sQLfunction.RunNonQuery(sql);
        }

        public string formatQueryToGetGVFitAnyDinhHuong(StringBuilder sql, string chuyenMon)
        {
            string[] temp = chuyenMon.Split(',');
            StringBuilder tempSql = new StringBuilder(sql.ToString());
            StringBuilder mainSql = new StringBuilder("");
            string subQuery;
            for (int i = 0; i < temp.Length; i++)
            {

                subQuery = String.Format(" and UPPER(ChuyenMon) = '{0}' ", temp[i].Trim().ToUpper());
                tempSql.Append(subQuery);
                tempSql.Append(" group by da.GVHD, gv.MaGV, HocVi ");

                if (i != temp.Length - 1)
                {
                    tempSql.Append(" union ");
                }
                mainSql.Append(tempSql.ToString());
                tempSql = new StringBuilder(sql.ToString());
            }
            //subQuery = String.Format(" and UPPER(ChuyenMon) = '{0}' ", temp[temp.Length - 1].Trim().ToUpper());
            //tempSql.Append(subQuery);
            //tempSql.Append(" group by da.GVHD, gv.MaGV, HocVi ");
            //mainSql.Append(tempSql.ToString());


            return mainSql.ToString();
        }

        public String formatQueryToGetGVFitAllOfDinhHuong(StringBuilder sql, string chuyenMon)
        {
            string[] temp = chuyenMon.Split(',');
            StringBuilder tempSql = new StringBuilder(sql.ToString());
            StringBuilder mainSql = new StringBuilder("");
            string subQuery;
            for (int i = 0; i < temp.Length; i++)
            {
                
                subQuery = String.Format(" and UPPER(ChuyenMon) = '{0}' ", temp[i].Trim().ToUpper());
                tempSql.Append(subQuery);
                tempSql.Append(" group by da.GVHD, gv.MaGV, HocVi ");
                
                if (i != temp.Length - 1)
                {
                    tempSql.Append(" INTERSECT ");
                }
                mainSql.Append(tempSql.ToString());
                tempSql = new StringBuilder(sql.ToString()); 
            }
            //subQuery = String.Format(" and UPPER(ChuyenMon) = '{0}' ", temp[temp.Length - 1].Trim().ToUpper());
            //tempSql.Append(subQuery);
            //tempSql.Append(" group by da.GVHD, gv.MaGV, HocVi ");
            //mainSql.Append(tempSql.ToString());
            

            return mainSql.ToString();
        }

        public string getmaGV(string sql)
        {
            string result = sQLfunction.RunQuery(sql);
            return result;
        }

        public bool CheckExsitDoAn(string mssv)
        {
            string sql = string.Format("select ID_DA from SV_DAMH where MSSV = '{0}'", mssv);
            string result = sQLfunction.RunQuery(sql);
            if (result == null)
                return false;
            return true;
        }
        
        public int checkAndCreateDoAnWithChoosenGVHD(DataRow dr, ThoiGian tg, DataTable dt)
        {
            
            if (dr["MSSVBanCungNhom"].ToString() == null || dr["MSSVBanCungNhom"].ToString() == "")
            {
                if (setGVHDForOneSV(tg, dr) == 0) 
                    return 0;
            }
            else
            {
                DataRow[] drBanCungNhom = dt.Select(string.Format("MSSV = '{0}' ", dr["MSSVBanCungNhom"].ToString().Trim()));
                if (drBanCungNhom == null || drBanCungNhom.Length == 0)
                {
                    updateInfoSVWithFailTeamMateInfo(dr["MSSV"].ToString());
                    if (setGVHDForOneSV(tg, dr) == 0)
                        return 0;
                }
                else
                {
                    //if (dr["MSSV"].ToString().Equals("1451010147") || dr["MSSV"].ToString().Equals("1451010148"))
                    //    MessageBox.Show("stop");
                    if (checkMacthTeamMate(drBanCungNhom, dr) == false)
                    {
                        updateInfoSVWithFailTeamMateInfo(dr["MSSV"].ToString());
                        if (setGVHDForOneSV(tg, dr) == 0)
                            return 0;
                    }

                    else
                    {

                        if (setGVHDForTwoSV(tg, dr, drBanCungNhom) == 0)
                            return 0;
                        else
                            return 2;
                    }                       
                }
            }
            return 1;
        }

        public int checkAndCreateDoAnWithAnyGVHD(DataRow dr, string gvhd, ThoiGian tg, DataTable dt)
        {
            DoAn da = new DoAn(gvhd, tg.HocKi, tg.ID1);    
            if (dr["MSSVBanCungNhom"].ToString() == null || dr["MSSVBanCungNhom"].ToString() == "")
            {
                if (insertDoAn(da, tg.ID1) == 0)
                    return 0;
                if (insertSV_DAMH(da.ID1, dr["MSSV"].ToString()) == 0)
                    return 0;
            }
            else
            {
                DataRow[] drBanCungNhom = dt.Select(string.Format("MSSV ='{0}' ", dr["MSSVBanCungNhom"].ToString()));

                if (drBanCungNhom == null || drBanCungNhom.Length == 0)
                {
                    updateInfoSVWithFailTeamMateInfo(dr["MSSV"].ToString());
                    if (insertDoAn(da, tg.ID1) == 0)
                        return 0;
                    if (insertSV_DAMH(da.ID1, dr["MSSV"].ToString()) == 0)
                        return 0;
                }
                else
                {
                    if (checkMacthTeamMate(drBanCungNhom, dr) == false)
                    {
                        updateInfoSVWithFailTeamMateInfo(dr["MSSV"].ToString());
                        if (insertDoAn(da, tg.ID1) == 0)
                            return 0;
                        if (insertSV_DAMH(da.ID1, dr["MSSV"].ToString()) == 0)
                            return 0;
                    }            
                    else
                    {
                        
                        if (insertDoAn(da, tg.ID1) == 0)
                            return 0;
                        if (insertSV_DAMH(da.ID1, dr["MSSV"].ToString()) == 0)
                            return 0;
                        if (insertSV_DAMH(da.ID1, drBanCungNhom[0]["MSSV"].ToString()) == 0)
                            return 0;
                        return 2;
                    }
                }
            }
            return 1;
        }


        public string formatStringToGetMatchGVWithLeastDeTai(string dinhHuong, ThoiGian tg)
        {
            string[] temp = dinhHuong.Split(',');
            StringBuilder sql = new StringBuilder(String.Format("select top 1 gv.MaGV" +
                " from GiangVien gv, DoAn da, ChuyenMonGiangVien cmgv, NhanChuyenMon cm " +
                " where gv.MaGV = da.GVHD and da.ID_ThoiGianToChuc = {0}" +
                " and gv.MaGV = cmgv.MaGV and cmgv.ID_NhanChuyenMon = cm.ID and (", tg.ID1));
            for(int i = 0; i < temp.Length; i++)
            {
                StringBuilder condition = new StringBuilder(string.Format(" cm.ChuyenMon = N'{0}'", temp[i].Trim()));
                if(i != temp.Length - 1)
                    condition.Append(" or ");
                sql.Append(condition.ToString());
            }
            sql.Append(" ) group by gv.MaGV order by COUNT(da.GVHD) ");
            return sql.ToString();
        }

        public string stringFormartGetGVWithLeastDeTai(ThoiGian tg)
        {
            string sql = String.Format("select top 1 gv.MaGV" +
                " from GiangVien gv, DoAn da, ChuyenMonGiangVien cmgv, NhanChuyenMon cm " +
                " where gv.MaGV = da.GVHD and da.ID_ThoiGianToChuc = {0}" +
                " and gv.MaGV = cmgv.MaGV and cmgv.ID_NhanChuyenMon = cm.ID  group by gv.MaGV order by COUNT(da.GVHD)", tg.ID1);
            return sQLfunction.RunQuery(sql);
        }
         

        public string getGVThamGiaKLTNPhuHopDinhHuong (string dinhHuong,ThoiGian tg)
        {
            string sql = formatStringToGetMatchGVWithLeastDeTai(dinhHuong, tg);
            string maGV = sQLfunction.RunQuery(sql);
            return maGV;
        }
        public int PhanCongChoSVLamDAMH(ThoiGian tg)
        {
            DataTable dt = getSVLamDAMHChuaCoGVHD(tg);
            int status = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (CheckExsitDoAn(dr["MSSV"].ToString()) == true)
                    continue;
                string maGV = getGVThamGiaKLTNPhuHopDinhHuong(dr["DinhHuong"].ToString(), tg);
                if (maGV == null)
                    maGV = stringFormartGetGVWithLeastDeTai(tg);
                status = checkAndCreateDoAnWithAnyGVHD(dr, maGV, tg, dt);
                if (status == 0)
                    return 0;
            }
            return 1;
        }

        public int phanCongGVChoSVLamKLTN(ThoiGian tg)
        {
            DataTable dt = getSVLamKLTNChuaCoGVHD();
            int status = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (CheckExsitDoAn(dr["MSSV"].ToString()) == true)
                    continue;
                status = checkAndCreateDoAnWithChoosenGVHD(dr, tg, dt);
                if (status == 0)
                    return 0;
            }

            dt = getSVLamKLTNChuaCoGVHD();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (CheckExsitDoAn(dr["MSSV"].ToString()) == true)
                        continue;
                    StringBuilder sql = new StringBuilder(String.Format("select gv.MaGV, HocVi ,count(da.GVHD) as SoLuong " +
                                        " from GiangVien gv, ChuyenMonGiangVien cmgv, " +
                                        " NhanChuyenMon cm, SinhVien sv, SV_DAMH svda, DoAn da" +
                                        " where gv.MaGV = cmgv.MaGV " +
                                        " and cm.ID = cmgv.ID_NhanChuyenMon  and gv.ThamGiaKLTN = 1 and da.GVHD = gv.MaGV " +
                                        " and sv.MSSV = svda.MSSV  and svda.ID_DA = da.ID and " +
                                        " gv.MaGV != '{0}' and gv.MaGV != '{1}'", dr["NVGVHD1"].ToString(), dr["NVGVHD2"].ToString()));
                    string mainSql = formatQueryToGetGVFitAllOfDinhHuong(sql, dr["DinhHuong"].ToString());
                    List<GVHDRespone> listGVHD = tranferToListGVHDResponse(sQLfunction.GetDataToTable(mainSql));
                    if(listGVHD.Count > 0)
                    {
                        GVHDRespone gvhd = findGVHD(listGVHD);
                        if (gvhd != null)
                        {
                            status = checkAndCreateDoAnWithAnyGVHD(dr, gvhd.MaGV, tg, dt);
                            if (status == 0)
                                return -1;
                           
                        }    
                            
                        else
                        {
                            mainSql = formatQueryToGetGVFitAnyDinhHuong(sql, dr["DinhHuong"].ToString());
                            listGVHD = tranferToListGVHDResponse(sQLfunction.GetDataToTable(mainSql));
                             

                            if (listGVHD.Count > 0)
                            {
                                gvhd = findGVHD(listGVHD);
                                if (gvhd != null)
                                {
                                    status = checkAndCreateDoAnWithAnyGVHD(dr, gvhd.MaGV, tg, dt);
                                    if (status == 0)
                                        return -2;
                                    
                                }    
                                else
                                {
                                    status = checkAndCreateDoAnWithAnyGVHD(dr, dr["NVGVHD1"].ToString().Trim(), tg, dt);
                                    if (status == 0)
                                        return -3;
                                  
                                }    
                                    
                            }
                            else
                            {
                                status = checkAndCreateDoAnWithAnyGVHD(dr, dr["NVGVHD1"].ToString().Trim(), tg, dt);
                                if (status == 0)
                                    return -3;
                            }
                        }    
                    }  
                    
                    else
                    {
                        mainSql = formatQueryToGetGVFitAnyDinhHuong(sql, dr["DinhHuong"].ToString());
                        listGVHD = tranferToListGVHDResponse(sQLfunction.GetDataToTable(mainSql));

                        if(listGVHD.Count > 0)
                        {
                            GVHDRespone gvhd = findGVHD(listGVHD);
                            if (gvhd != null)
                            {
                                status = checkAndCreateDoAnWithAnyGVHD(dr, gvhd.MaGV, tg, dt);
                                if (status == 0)
                                    return -2;
                            }    
                            else
                            {
                                status = checkAndCreateDoAnWithAnyGVHD(dr, dr["NVGVHD1"].ToString(), tg, dt);
                                if (status == 0)
                                    return -3;
                            }    
                                
                        } 
                        else
                        {
                            status = checkAndCreateDoAnWithAnyGVHD(dr, dr["NVGVHD1"].ToString(), tg, dt);
                            if (status == 0)
                                return -3;
                        }    
                    }    

                }
            }    
            return 1;
        }


        public DataTable loadUpdatedSinhVien(ThoiGian tg)
        {
            string sql = String.Format("select sv.MSSV, sv.HoLot + ' ' + sv.Ten as N'Họ tên', " +
                " IIF(GPA >= 2.5, cast(GPA as nvarchar), N'Không đủ điều kiện') AS N'Nguyện vọng KLTN'," +
                " IIF(MSSVBanCungNhom != null, 'Nhóm 2 người', ' ') as N'Số lượng thành viên'," +
                " sv.Nganh, sv.ChuyenNganh, gv.HocVi + gv.HoTen as N'Giảng viên hướng dẫn'," +
                " string_agg(DinhHuong, ', ') as DinhHuong " +
                "from SinhVien sv, SV_DAMH svda, DoAn da, GiangVien gv, DinhHuongDeTai dh, SV_DinhHuong svdh" +
                " where sv.MSSV = svda.MSSV and svda.ID_DA = da.ID and gv.MaGV = da.GVHD" +
                " and svdh.ID_DinhHuong = dh.ID and svdh.MSSV = sv.MSSV and da.ID_ThoiGianToChuc = {0}" +
                "group by sv.MSSV, sv.HoLot, sv.Ten, GPA, MSSVBanCungNhom, Nganh, ChuyenNganh, gv.HocVi, gv.HoTen", tg.ID1);

            return sQLfunction.GetDataToTable(sql);
        }
    }
  
}
