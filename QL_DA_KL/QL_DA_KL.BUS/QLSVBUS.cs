using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.BUS
{
    public class QLSVBUS :ModelBus
    {
        public QLSVBUS()
        {
            base.load();
        }

        public string getLatestInputThoiGianINDoAn()
        {
            string sql = "select distinct ID_ThoiGianToChuc from DoAn order by ID_ThoiGianToChuc";
            return sQLfunction.RunQuery(sql);
        }

        public string getLatestInputThoiGian()
        {
            string sql = "select top 1 ID from ThoiGian order by ID desc";
            return sQLfunction.RunQuery(sql);
        }

        public DataTable getListSinhVien(string idTG)
        {
            string sql = String.Format("select top 100 sv.MSSV, sv.HoLot + ' ' + sv.Ten as N'HoTen', EmailOU, EmailCaNhan, SDT, " +
                " IIF(GPA >= 2.5, cast(GPA as nvarchar), N'Không đủ điều kiện') AS N'Nguyện vọng KLTN'," +
                " IIF(MSSVBanCungNhom != null, 'Nhóm 2 người', ' ') as N'Số lượng thành viên'," +
                " sv.Nganh, sv.ChuyenNganh, gv.HocVi + gv.HoTen as N'Giảng viên hướng dẫn'," +
                " string_agg(DinhHuong, ', ') as DinhHuong " +
                " from SinhVien sv, SV_DAMH svda, DoAn da, GiangVien gv, DinhHuongDeTai dh, SV_DinhHuong svdh" +
                " where sv.MSSV = svda.MSSV and svda.ID_DA = da.ID and gv.MaGV = da.GVHD" +
                " and svdh.ID_DinhHuong = dh.ID and svdh.MSSV = sv.MSSV and da.ID_ThoiGianToChuc = {0}" +
                " group by sv.MSSV, EmailOU, EmailCaNhan, SDT, sv.HoLot, sv.Ten, GPA, MSSVBanCungNhom, Nganh, ChuyenNganh, gv.HocVi, gv.HoTen", idTG);

            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getListSVInLatestHocKi(string idTG)
        {
            string sql = String.Format("select top 100 sv.MSSV, sv.HoLot + ' ' + sv.Ten as N'HoTen', EmailOU, EmailCaNhan, SDT,  " +
                " IIF(GPA >= 2.5, cast(GPA as nvarchar), N'Không đủ điều kiện') AS N'Nguyện vọng KLTN'," +
                " IIF(MSSVBanCungNhom != null, 'Nhóm 2 người', ' ') as N'Số lượng thành viên', " +
                "sv.Nganh, sv.ChuyenNganh, trim(GiangVien.HocVi) + '. ' + GiangVien.HoTen as N'Giảng viên hướng dẫn', " +
                "string_agg(DinhHuong, ', ') as DinhHuong " +
                "from SinhVien sv " +
                "left join SV_DAMH on sv.MSSV = SV_DAMH.MSSV " +
                "left join DoAn on SV_DAMH.ID_DA = DoAn.ID " +
                "left join GiangVien on GiangVien.MaGV = DoAn.GVHD " +
                "left join SV_DinhHuong on SV_DinhHuong.MSSV = sv.MSSV " +
                "left join DinhHuongDeTai on DinhHuongDeTai.ID = SV_DinhHuong.ID_DinhHuong " +
                "where sv.MSSV not in (select MSSV from SV_DAMH, DoAn where SV_DAMH.ID_DA = DoAn.ID and ID_ThoiGianToChuc = {0}) " +
                " or sv.MSSV in (select MSSV from SV_DAMH, DoAn where SV_DAMH.ID_DA = DoAn.ID and ID_ThoiGianToChuc = {0}) " +
                " group by sv.MSSV, EmailOU, EmailCaNhan, SDT, sv.HoLot, sv.Ten, GPA, MSSVBanCungNhom, Nganh, ChuyenNganh, GiangVien.HocVi, GiangVien.HoTen", idTG);

            return sQLfunction.GetDataToTable(sql);
        }



        public DataTable getThoiGian()
        {
            string sql = "select * from ThoiGian where ID in (select ID_ThoiGianToChuc from DoAn) order by ID desc";
            return sQLfunction.GetDataToTable(sql);
        }

        public List<ThoiGian> tranferDTToListTG()
        {
            DataTable dt = getThoiGian();
            List<ThoiGian> list = new List<ThoiGian>();
            foreach (DataRow dr in dt.Rows)
            {
                ThoiGian tg = new ThoiGian(int.Parse(dr["ID"].ToString()), dr["HocKi"].ToString(),
                                            dr["NamHoc"].ToString());
                list.Add(tg);
            }
            return list;
        }   

        public DataTable getListGiangVienByTinhTrangLamKLTN(string tinhTrang)
        {
            string sql = "select MaGV, HocVi, HoTen from GiangVien";
            if(tinhTrang.Equals("Có"))
            {
                sql += " where ThamGiaKLTN = 1";
            }
            else
            {
                sql += " where ThamGiaKLTN = 0";
            }    
                
            return sQLfunction.GetDataToTable(sql);                   
        }

        public DataTable getListGiangVienByID(string maGV)
        {
            string sql = String.Format("select MaGV, HocVi, HoTen from GiangVien where MaGV = '{0}'", maGV);
            return sQLfunction.GetDataToTable(sql);
        }

        public List<GiangVien> tranferDTToListGV(DataTable dtGVHD)
        {
            List<GiangVien> list = new List<GiangVien>();
            foreach (DataRow dr in dtGVHD.Rows)
            {
                GiangVien gv = new GiangVien(dr["MaGV"].ToString(), dr["HoTen"].ToString(), dr["HocVi"].ToString());
                list.Add(gv);
            }

            return list;
        }

        public string getIDDeTai(string idTG, string mssv)
        {
            string sql = String.Format("select ID_DA from SV_DAMH svda, DoAN da where svda.ID_DA = da.ID " +
                            "  and MSSV = '{0}' and ID_ThoiGianToChuc = {1}", mssv, idTG);
            return sQLfunction.RunQuery(sql);
        }

        public int updateGVHD(string maGV, string idTG, string mssv)
        {
            string idDoAn = getIDDeTai(idTG, mssv);

            string sql = String.Format("update DoAn set GVHD = '{0}', TGThayDoiGVHD = getdate() where ID = '{1}'", maGV, idDoAn);
            return sQLfunction.RunNonQuery(sql);
        }

        public string getHocKi(string idTG)
        {
            string sql = "select HocKi from ThoiGian where ID = " + idTG;
            return sQLfunction.RunQuery(sql);
        }

        public int insertDoAn(DoAn doAn)
        {
            string sql = String.Format("insert into DoAn(ID, ID_ThoiGianToChuc, GVHD) values('{0}',{1},'{2}')",
                                 doAn.ID1, doAn.ThoiGianToChuc, doAn.GVHD1);
            return sQLfunction.RunNonQuery(sql);
        }

        public int insertSV_DAMH(string id_DA, string mssv)
        {
            string sql = String.Format("insert into SV_DAMH values('{0}', '{1}')",
                                            mssv, id_DA);
            return sQLfunction.RunNonQuery(sql);
        }

        public int createDoAn(string maGV, string idTG, string mssv)
        {
            string hocKi = getHocKi(idTG);
            DoAn doAn = new DoAn(maGV, hocKi, int.Parse(idTG));

            if (insertDoAn(doAn) == 0)
                return 0;
            else
            {
                if (insertSV_DAMH(doAn.ID1, mssv) == 0)
                    return 0;
                return 1;
            }    
        }

        public DataTable findSvBYMSSV(string mssv)
        {
            string sql = "select sv.MSSV, sv.HoLot + ' ' + sv.Ten as N'HoTen',EmailOU, EmailCaNhan, SDT, " +
                " IIF(GPA >= 2.5, cast(GPA as nvarchar), N'Không đủ điều kiện') AS N'Nguyện vọng KLTN'," +
                " IIF(MSSVBanCungNhom != null, 'Nhóm 2 người', ' ') as N'Số lượng thành viên', " +
                "sv.Nganh, sv.ChuyenNganh, trim(GiangVien.HocVi) + '. ' + GiangVien.HoTen as N'Giảng viên hướng dẫn', " +
                "string_agg(DinhHuong, ', ') as DinhHuong " +
                "from SinhVien sv " +
                "left join SV_DAMH on sv.MSSV = SV_DAMH.MSSV " +
                "left join DoAn on SV_DAMH.ID_DA = DoAn.ID " +
                "left join GiangVien on GiangVien.MaGV = DoAn.GVHD " +
                "left join SV_DinhHuong on SV_DinhHuong.MSSV = sv.MSSV " +
                "left join DinhHuongDeTai on DinhHuongDeTai.ID = SV_DinhHuong.ID_DinhHuong " +
                "where SV.MSSV = '" + mssv +  "' " +
                "group by sv.MSSV, sv.HoLot, EmailOU, EmailCaNhan, SDT, sv.Ten, GPA, MSSVBanCungNhom, Nganh, ChuyenNganh, GiangVien.HocVi, GiangVien.HoTen";

            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable findSvBYName(string name)
        {
            string sql = String.Format("select sv.MSSV, sv.HoLot + ' ' + sv.Ten as N'HoTen',EmailOU, EmailCaNhan, SDT, " +
                " IIF(GPA >= 2.5, cast(GPA as nvarchar), N'Không đủ điều kiện') AS N'Nguyện vọng KLTN'," +
                " IIF(MSSVBanCungNhom != null, 'Nhóm 2 người', ' ') as N'Số lượng thành viên', " +
                "sv.Nganh, sv.ChuyenNganh, trim(GiangVien.HocVi) + '. ' + GiangVien.HoTen as N'Giảng viên hướng dẫn', " +
                "string_agg(DinhHuong, ', ') as DinhHuong " +
                "from SinhVien sv " +
                "left join SV_DAMH on sv.MSSV = SV_DAMH.MSSV " +
                "left join DoAn on SV_DAMH.ID_DA = DoAn.ID " +
                "left join GiangVien on GiangVien.MaGV = DoAn.GVHD " +
                "left join SV_DinhHuong on SV_DinhHuong.MSSV = sv.MSSV " +
                "left join DinhHuongDeTai on DinhHuongDeTai.ID = SV_DinhHuong.ID_DinhHuong " +
                "where  UPPER(sv.HoLot + ' ' + sv.Ten) like N'%{0}%' " +
                "group by sv.MSSV, sv.HoLot, " +
                "EmailOU, EmailCaNhan, SDT, sv.Ten, GPA, MSSVBanCungNhom, " +
                "Nganh, ChuyenNganh, GiangVien.HocVi, GiangVien.HoTen", name.Trim().ToUpper());

            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable findSVbyMSSV(string mssv, DataTable originalDT)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("MSSV = '{0}'", mssv);
            return dt;
        }

        public DataTable findSVbyName(string ten, DataTable originalDT)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("HoTen like '%{0}%'", ten);
            return dt;
        }

    }
}
