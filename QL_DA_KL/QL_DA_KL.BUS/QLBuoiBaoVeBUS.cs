using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.BUS
{
    public class QLBuoiBaoVeBUS : ModelBus
    {
        public QLBuoiBaoVeBUS()
        {
            base.load();
        }

        public string formatThuTrongTuan(string thu)
        {
            switch (thu)
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

        public int getLatestInPutHocKi()
        {
            string sql = "select top 1 ID from ThoiGian order by ID desc";
            return int.Parse(sQLfunction.RunQuery(sql));
        }

        public ThoiGian getLatestIDInHoiDong()
        {
            string sql = "select tg.ID, HocKi, NamHoc from ThoiGian tg, HoiDong hd where tg.ID = hd.ID_HocKiToChuc order by ID_HocKiToChuc desc";
            DataTable dt =  sQLfunction.GetDataToTable(sql);
            ThoiGian tg = new ThoiGian(int.Parse(dt.Rows[0]["ID"].ToString()), dt.Rows[0]["HocKi"].ToString(), dt.Rows[0]["NamHoc"].ToString());
            return tg;
        }

        public DataTable getSVChuaXepLich()
        {
            string sql = string.Format("select sv.MSSV, sv.HoLot + ' ' + sv.Ten as 'HoTen',  trim(HocVi) + '. ' + gv.HoTen " +
                "from SinhVien sv, KLTN kl, SV_KLTN svkl, GiangVien gv " +
                "where sv.MSSV = svkl.MSSV and kl.GVHD = gv.MaGV " +
                "and svkl.ID_KLTN = kl.ID and kl.ID not in (select ID_KLTN from LuotBaoVe) ");
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getAvailableHoiDong()
        {
            string sql = "select hd.ID, FORMAT(hd.TGBatDau,'dd/MM/yyyy HH:mm:ssss') as TG,  trim(HocVi) + '. ' + gv.HoTen as 'ChuTich' " +
                "from HoiDong hd, ThanhVien tv, GiangVien gv " +
                "where hd.ID = tv.ID_HoiDong and tv.MaGV = gv.MaGV and VaiTro = 'CT' " +
                "and hd.ID not in (select ID_HoiDong from BuoiBaoVe where ID_HoiDong is not null) ";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getThanhVienInfo(string idHoiDong)
        {
            string sql = string.Format("select gv.MaGV, TRIM(gv.HocVi) + '. ' + gv.HoTen as 'GiangVien'" +
                           " from GiangVien gv, ThanhVien tv " +
                           "where gv.MaGV = tv.MaGV and tv.ID_HoiDong = {0} and tv.VaiTro = 'TV'", idHoiDong);

            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getAvailableGV(string ngay, string gio, string buoiTrongNgay, string thu)
        {
            string sql = string.Format("select gv.MaGV, trim(HocVi) + '. ' + HoTen as GV" +
                        " from GiangVien gv, LichBieu lich " +
                        " where gv.MaGV = lich.MaGV  " +
                        "and BuoiTrongNgay = '{0}' " +
                        "and ThuTrongTuan = '{1}' " +
                        "and gv.MaGV not in " +
                        "(select MaGV " +
                        "from HoiDong hd, ThanhVien tv " +
                        "where hd.ID = tv.ID_HoiDong and " +
                        "convert(date, hd.TGBatDau) = '{2}' " +
                        "and convert(time, hd.TGBatDau) = '{3}')", buoiTrongNgay, thu, ngay, gio);
            return sQLfunction.GetDataToTable(sql);
        }
    }
}
