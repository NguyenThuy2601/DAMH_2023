using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.BUS
{
    public class QuanLyHoiDongBUS :ModelBus
    {
        public QuanLyHoiDongBUS()
        {
            base.load();
        }

        public string formatThuTrongTuan(string thu)
        {
            switch(thu)
            {
                case "Monday":
                    return "2";
                case "Tuesday":
                    return "3";
                case "Wednesday":
                    return "4";
                case "Thursday":
                    return "5";
                case "Friday":
                    return "6";
                default:
                    return "0";
            }    
        }

        public string getBuoiTrongngay(string gio)
        {
            string[] temp = gio.Split(':');
            int time = int.Parse(temp[0]);
            if (time >= 7 && time <= 11)
                return "S";
            if (time >= 13 && time <= 17)
                return "C";
            return "";
        }

        public string formattedConditionSQL(List<String> maGV)
        {
            string sql = null;
            if (maGV == null)
                return null;
            for(int i = 0; i < maGV.Count; i++)
            {
                if(i == 0)
                    sql = " and gv.MaGV != '" + maGV[i].ToString() + "'";
                else
                {
                    sql += " and gv.MaGV != '" + maGV[i].ToString() + "'";
                }    
            }

            return sql;
        }

        public DataTable getListMaGV(string thu, string buoiTrongNgay)
        {
            string sql = string.Format("select MaGV from LichBieu where BuoiTrongNgay = '{0}' " +
                        "and ThuTrongTuan = '{1}'", buoiTrongNgay, thu);
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getApproriateTienSi(string thu, string buoiTrongNgay, string ngay, string gio,string maGV1, List<string> listmaGV2, string idCurrentHoiDong)
        {
            string sql = string.Format("select distinct gv.MaGV, trim(HocVi) + '. ' + Hoten as 'HoTen'" +
                                        "from GiangVien gv, LichBieu l " +
                                        "where gv.MaGV = l.MaGV " +
                                        "and BuoiTrongNgay = '{0}' and ThuTrongTuan = '{1}' and HocVi = 'TS'", buoiTrongNgay, thu);
            if (maGV1 != "" || maGV1 != null )
                sql += "and gv.MaGV != '" + maGV1 +"'";
            string coditionSql = formattedConditionSQL(listmaGV2);
            if (coditionSql != null)
                sql += coditionSql;
            sql += string.Format(" and gv.MaGV not in (select MaGV from HoiDong hd, ThanhVien tv where hd.ID = tv.ID_HoiDong and convert(date, hd.TGBatDau) = '{0}' and convert(time, hd.TGBatDau) = '{1}' ", ngay, gio);
            if (idCurrentHoiDong != "")
                sql += string.Format(" and ID != '{0}')", idCurrentHoiDong);
            else
                sql += ")";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getApproriateGV(string thu, string buoiTrongNgay, string ngay, string gio, string maGV1, string maGV2, string idCurrentHoiDong)
        {
            string sql = string.Format("select distinct gv.MaGV, trim(HocVi) + '. ' + Hoten as 'HoTen'" +
                                        "from GiangVien gv, LichBieu l " +
                                        "where gv.MaGV = l.MaGV " +
                                        "and BuoiTrongNgay = '{0}' and ThuTrongTuan = '{1}'", buoiTrongNgay, thu);
            if (maGV1 != "" || maGV1 != null)
                sql += "and gv.MaGV != '" + maGV1 + "'";
            if (maGV2 != "" || maGV2 != null)
                sql += "and gv.MaGV != '" + maGV2 + "'";
            sql += string.Format(" and gv.MaGV not in (select MaGV from HoiDong hd, ThanhVien tv where hd.ID = tv.ID_HoiDong and convert(date, hd.TGBatDau) = '{0}' and convert(time, hd.TGBatDau) = '{1}' ", ngay, gio);
            if (idCurrentHoiDong != "")
                sql += string.Format(" and ID != '{0}')", idCurrentHoiDong);
            else
                sql += ")";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getApproriateGV(string thu, string buoiTrongNgay, string ngay, string gio , string maGV1, List<string> listmaGV2, string idCurrentHoiDong)
        {
            string sql = string.Format("select distinct gv.MaGV, trim(HocVi) + '. ' + Hoten as 'HoTen'" +
                                        "from GiangVien gv, LichBieu l " +
                                        "where gv.MaGV = l.MaGV " +
                                        "and BuoiTrongNgay = '{0}' and ThuTrongTuan = '{1}'", buoiTrongNgay, thu);
            if (maGV1 != "" || maGV1 != null)
                sql += "and gv.MaGV != '" + maGV1 + "'";
            string coditionSql = formattedConditionSQL(listmaGV2);
            if (coditionSql != "")
                sql += coditionSql;
            sql += string.Format(" and gv.MaGV not in (select MaGV from HoiDong hd, ThanhVien tv where hd.ID = tv.ID_HoiDong and convert(date, hd.TGBatDau) = '{0}' and convert(time, hd.TGBatDau) = '{1}' ", ngay, gio);
            if (idCurrentHoiDong != "")
                sql += string.Format(" and ID != '{0}')", idCurrentHoiDong);
            else
                sql += ")";
            return sQLfunction.GetDataToTable(sql);
        }

        public string getHocViHoTen(string maGV)
        {
            string sql = String.Format("select trim(HocVi) + '. ' + Hoten as 'HoTen' " +
                                "from GiangVien where MaGV = '{0}'", maGV);
            return sQLfunction.RunQuery(sql);
        }

        public string checkDuplicateDate(string ngayBD)
        {
            string sql = string.Format("select * from HoiDong where CONVERT(DATE, TGBatDau) = '{0}'", ngayBD);
            return sQLfunction.RunQuery(sql);
        }

        public string getLatestHocKiInHoiDongID()
        {
            string sql = "select top 1  ID_HocKiToChuc from HoiDong order by ID_HocKiToChuc desc";
            return sQLfunction.RunQuery(sql);
        }

        public DataTable getAllhocKiInHoiDong()
        {
            string sql = "select ID, 'HK' + trim(HocKi) + ' ' + NamHoc as 'HocKi' from ThoiGian where ID in (select distinct ID_HocKiToChuc from HoiDong)";
            return sQLfunction.GetDataToTable(sql);
        }    

        public DataTable getHoiDong(string idHocKi)
        {
            string sql = string.Format("select hd.ID, FORMAT(hd.TGBatDau,'dd/MM/yyyy HH:mm:ssss') as 'ThoiGian', trim(tg.HocKi) + ' ' + tg.NamHoc as 'HocKiNamHoc', " +
                "TRIM(gv.HocVi) + '. ' + gv.HoTen as 'ChuTich' " +
                "from HoiDong hd, ThoiGian tg, ThanhVien tv, GiangVien gv " +
                "where hd.ID_HocKiToChuc = tg.ID and tv.ID_HoiDong = hd.ID and tv.MaGV = gv.MaGV " +
                "and tv.VaiTro = 'CT' and tg.ID = {0}", idHocKi);
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getHoiDongDetail(string id)
        {
            string sql = string.Format("select TRIM(gv.HocVi) + '. ' + gv.HoTen as 'GiangVien', tv.VaiTro" +
                            " from GiangVien gv, ThanhVien tv " +
                            "where gv.MaGV = tv.MaGV and tv.ID_HoiDong = {0}", id);

            return sQLfunction.GetDataToTable(sql);
        }

        public string getThuKiInfo(string idHoiDong)
        {
            string sql = string.Format("select TRIM(gv.HocVi) + '. ' + gv.HoTen as 'GiangVien'" +
                           " from GiangVien gv, ThanhVien tv " +
                           "where gv.MaGV = tv.MaGV and tv.ID_HoiDong = {0} and tv.VaiTro = 'TK'", idHoiDong);

            return sQLfunction.RunQuery(sql);
        }

        public DataTable getThanhVienInfo(string idHoiDong)
        {
            string sql = string.Format("select gv.MaGV, TRIM(gv.HocVi) + '. ' + gv.HoTen as 'GiangVien'" +
                           " from GiangVien gv, ThanhVien tv " +
                           "where gv.MaGV = tv.MaGV and tv.ID_HoiDong = {0} and tv.VaiTro = 'TV'", idHoiDong);

            return sQLfunction.GetDataToTable(sql);
        }

        public int deleteTVinHoiDong(string idHoiDong)
        {
            string sql = string.Format("delete from ThanhVien where ID_HoiDong = {0}", idHoiDong);
            return sQLfunction.RunNonQuery(sql);
        }

        public int insertThanhVien(string idHoiDong, string maGV, string vaiTro)
        {
            string sql = string.Format("insert into ThanhVien values({0}, '{1}', '{2}')", maGV, idHoiDong, vaiTro);
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateHoiDong(HoiDong hd)
        {
            string sql = string.Format("update HoiDong set TGBatDau = '{0}' where ID = {1}", hd.TGToChuc1, hd.IdHoiDong);
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateThanhVien(string idHoiDong, string maGV, string vaiTro)
        {
            string sql = string.Format("update ThanhVien set MaGV = '{0}' where ID_HoiDong = {1} and VaiTro = '{2}' ", 
                                    maGV, idHoiDong, vaiTro);
            return sQLfunction.RunNonQuery(sql);
        }

        public string getMaGvByHoTen(string hoTen)
        {
            string sql = string.Format("select top 1 MaGV from GiangVien where HoTen = N'{0}'", hoTen);
            return sQLfunction.RunQuery(sql);
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

        public int getLastInputSem()
        {
            string sql = "select top 1 ID from ThoiGian order by ID desc";
            return int.Parse(sQLfunction.RunQuery(sql));
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

        public int insertHoiDong(HoiDong hd)
        {
            string sql = string.Format("insert into HoiDong(TGBatDau, ID_HocKiToChuc) values('{0}', {1})", hd.TGToChuc1, hd.Id_HocKiToChuc);
            return sQLfunction.RunNonQuery(sql);
        }

        public string getInputHoiDong()
        {
            string sql = "select top 1 ID from HoiDong order by ID desc";
            return sQLfunction.RunQuery(sql);
        }  
        
        public List<ThanhVien> tranferToListThanhVien(List<String> list, string idHoiDong)
        {
            List<ThanhVien> listTV = new List<ThanhVien>();
            for (int i = 0; i < list.Count; i++)
            {
                ThanhVien tv = new ThanhVien(list[i], idHoiDong, "TV");
                listTV.Add(tv);
            }    
            return listTV;
        }

        public int insertThanhVien(ThanhVien tv)
        {
            string sql = string.Format("insert into ThanhVien values('{0}', {1}, '{2}')", tv.MaGV, tv.ID_HoiDong1, tv.VaiTro);
            return sQLfunction.RunNonQuery(sql);
        }    

        public int createThanhVienForHoiDong(ThanhVien chuTich, ThanhVien thuKi, List<ThanhVien> ListTV)
        {
            if (insertThanhVien(chuTich) == 0)
                return 0;
            if (insertThanhVien(thuKi) == 0)
                return 0;
            for(int i = 0; i < ListTV.Count; i++)
            {
                if (insertThanhVien(ListTV[i]) == 0)
                    return 0;
            }
            return 1;
        }

        public DataTable getbuoiBaove(string idhoiDong)
        {
            string sql = string.Format("select bv.HocKyKLTN, FORMAT(bv.NgayBatDau,'dd/MM/yyyy') as 'NgayBatDau', luot.TGBatDau, kl.TenKLTN, sv.MSSV,sv.HoLot +  ' ' + sv.Ten as 'HoTen',  " +
                "TRIM(HocVi) + '. ' + HoTen as 'GVHD', temp.GVPB " +
                "from HoiDong hd, BuoiBaoVe bv, LuotBaoVe luot, KLTN kl, GiangVien gv, SinhVien sv, SV_KLTN svkl, " +
                " (select ID_KLTN, TRIM(HocVi) + '. ' + HoTen as 'GVPB'" +
                " from LuotBaoVe luot, GiangVien gv " +
                "where luot.GVPB = gv.MaGV) as temp " +
                "where hd.ID = bv.ID_HoiDong and bv.ID = luot.ID_BuoiBaoVe and luot.ID_KLTN = kl.ID " +
                "and kl.ID = svkl.ID_KLTN and svkl.MSSV = sv.MSSV and kl.GVHD = gv.MaGV " +
                "and luot.ID_KLTN = temp.ID_KLTN and hd.ID = {0}", idhoiDong);

            return sQLfunction.GetDataToTable(sql);
        }

        public int insertHocKiNamHoc(ThoiGian tg)
        {
            string sql = "insert into ThoiGian(HocKi, NamHoc) values('"
                        + tg.HocKi + "','"
                        + tg.NamHoc + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateHoiDongInfo(string maGVchuTich, string maGVThuKi, List<ThanhVien> ListTV, string idHoiDong)
        {

            deleteTVinHoiDong(idHoiDong);
            if (updateThanhVien(idHoiDong, maGVchuTich,  "CT") == 0)
                return 0;
            if (updateThanhVien(idHoiDong, maGVThuKi, "TK") == 0)
                return 0;
            deleteTVinHoiDong(idHoiDong);
            for (int i = 0; i < ListTV.Count; i++)
            {
                if (insertThanhVien(ListTV[i]) == 0)
                    return 0;
            }

            return 1;
        }

        public DataTable getTGToChucInHocKi(string idHocKi)
        {
            string sql = string.Format("select TGBatDau, FORMAT(TGBatDau,'dd/MM/yyyy HH:mm:ssss') as 'FormatedTgBD' from HoiDong where ID_HocKiToChuc = '{0}'", idHocKi);
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getHoiDongBYHocKiAndTG(string idHK, string ngayGio)
        {
            string sql = string.Format("select hd.ID, FORMAT(hd.TGBatDau,'dd/MM/yyyy HH:mm:ssss') as 'ThoiGian', trim(tg.HocKi) + ' ' + tg.NamHoc as 'HocKiNamHoc', " +
                "TRIM(gv.HocVi) + '. ' + gv.HoTen as 'ChuTich' " +
                "from HoiDong hd, ThoiGian tg, ThanhVien tv, GiangVien gv " +
                "where hd.ID_HocKiToChuc = tg.ID and tv.ID_HoiDong = hd.ID and tv.MaGV = gv.MaGV " +
                "and tv.VaiTro = 'CT' and tg.ID = {0} and hd.TGBatDau = '{1}'", idHK, ngayGio);
            return sQLfunction.GetDataToTable(sql);
        }

        public int deleteHoiDong(string idHoiDong)
        {
            string sql = string.Format("delete from HoiDong where ID = {0}", idHoiDong);
            return sQLfunction.RunNonQuery(sql);
        }
    }
}
