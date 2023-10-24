using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.BUS
{
    public class QLNhomSVBUS :ModelBus
    {
        public QLNhomSVBUS()
        {
            base.load();
        }

        public DataTable getThoiGian()
        {
            string sql = "select * from ThoiGian order by ID desc";
            return sQLfunction.GetDataToTable(sql);
        }

        public List<ThoiGian> getListTG()
        {
            DataTable dt = getThoiGian();
            List<ThoiGian> list = new List<ThoiGian>();
            foreach(DataRow dr in dt.Rows)
            {
                ThoiGian tg = new ThoiGian(int.Parse(dr["ID"].ToString()), dr["HocKi"].ToString(), dr["NamHoc"].ToString());
                list.Add(tg);
            }
            return list;
        }

        public DataTable getNhomSinhVienTheoGiangVien(string maGV, string idTG)
        {
            string sql = string.Format("select sv.MSSV, sv.HoLot + ' ' + sv.Ten as N'Họ tên', " +
                "IIF(GPA >= 2.5, cast(GPA as nvarchar), N'Không đủ điều kiện') AS N'Nguyện vọng KLTN', " +
                "IIF(MSSVBanCungNhom != null, 'Nhóm 2 người', ' ') as N'Số lượng thành viên', " +
                "sv.Nganh, sv.ChuyenNganh, gv.HocVi + gv.HoTen as N'Giảng viên hướng dẫn', " +
                "string_agg(DinhHuong, ', ') as DinhHuong " +
                "from SinhVien sv, SV_DAMH svda, DoAn da, GiangVien gv, DinhHuongDeTai dh, SV_DinhHuong svdh " +
                "where sv.MSSV = svda.MSSV and svda.ID_DA = da.ID and gv.MaGV = da.GVHD " +
                "and svdh.ID_DinhHuong = dh.ID and svdh.MSSV = sv.MSSV and da.ID_ThoiGianToChuc = {0} " +
                "and da.GVHD = '{1}' " +
                "group by sv.MSSV, sv.HoLot, sv.Ten, GPA, MSSVBanCungNhom, Nganh, ChuyenNganh, gv.HocVi, gv.HoTen", idTG, maGV);
            return sQLfunction.GetDataToTable(sql);
        }

        public int countSoLuongKLTNCuaGV(string maGV, string idTG)
        {
            string sql = string.Format("select COUNT(da.ID) " +
                "from GiangVien gv, DoAn da, SV_DAMH svda, SinhVien sv " +
                "where gv.MaGV = da.GVHD and da.ID = svda.ID_DA and sv.MSSV = svda.MSSV " +
                "and GPA >= 2.5 and da.ID_ThoiGianToChuc = {0} and gv.MaGV = '{1}'", idTG, maGV);

            return int.Parse(sql);
        }

        public string getHocVi(string maGV)
        {
            string sql = string.Format("select HocVi from GiangVien where MaGV = '{0}'", maGV);
            return sQLfunction.RunQuery(sql);
        }

        public bool checkSLKLTNCuaGV(string hocVI, int soLuong)
        {
            if (hocVI.Trim().Equals("ThS"))
                if (soLuong > 5)
                    return false;
            if (hocVI.Trim().Equals("TS"))
                if(soLuong > 10)
                    return false;
            return true;
        }

        public DataTable getApproriateGV(int trangThai)
        {
            string sql = string.Format("select MaGV, HocVi, HoTen " +
                                    "from GiangVien where ThamGiaKLTN = {0}", trangThai);
            return sQLfunction.GetDataToTable(sql); 
        }

        public DataTable getGV()
        {
            string sql = "select MaGV, HocVi, HoTen from GiangVien";
            return sQLfunction.GetDataToTable(sql);
        }

        public List<GiangVien> getListApproriateGiangVien(int soLuongSVLamKLTN)
        {
            int trangThai = 0;
            if (soLuongSVLamKLTN > 0)
                trangThai = 1;
            DataTable dt = getApproriateGV(trangThai);
            List<GiangVien> list = new List<GiangVien>();
            foreach(DataRow dr in dt.Rows)
            {
                GiangVien gv = new GiangVien(dr["MaGV"].ToString(), dr["HoTen"].ToString(), dr["HocVi"].ToString());
                list.Add(gv);
            }
            return list;
        }

        public List<GiangVien> getListGiangVien()
        {
            DataTable dt = getGV();
            List<GiangVien> list = new List<GiangVien>();
            foreach (DataRow dr in dt.Rows)
            {
                GiangVien gv = new GiangVien(dr["MaGV"].ToString(), dr["HoTen"].ToString(), dr["HocVi"].ToString());
                list.Add(gv);
            }
            return list;
        }

        public string getMaDoAn(string mssv)
        {
            string sql = string.Format("select ID_DoAn from SV_DAMH where MSSV = '{0}'", mssv);
            return sQLfunction.RunQuery(sql);
        }

        public int updateGVHDInDoAn(string idDoAn, string maGV)
        {
            string sql = string.Format("update DoAn set GVHD = '{0}', TGThayDoiGVHD = getdate() where DoAn.ID = '{0}'", idDoAn);
            return sQLfunction.RunNonQuery(sql);
        }    

        public int updateGVHD(string maGV, List<String> listMSSV)
        {
            for(int i = 0; i < listMSSV.Count; i++)
            {
                string idDA = getMaDoAn(listMSSV[i]);
                if(updateGVHDInDoAn(idDA, maGV) == 0)
                    return 0;
            }
            return 1;
        }
    }
}
