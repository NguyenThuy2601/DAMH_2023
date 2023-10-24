using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.BUS
{
    public class QLGVBUS :ModelBus
    {
        public QLGVBUS()
        {
            base.load();
        }

        public DataTable getListGiangVienToDT()
        {
            string sql = "select * from GiangVien";
            DataTable dt = sQLfunction.GetDataToTable(sql);
            return dt;
        }    

        public DataTable getChuyenMonList()
        {
            string sql = "select * from NhanChuyenMon";
            DataTable dt = sQLfunction.GetDataToTable(sql);
            return dt;
        }

        public DataTable getGV_ChuyenMon(string maGV)
        {
            string sql = "select n.*" +
                         "from ChuyenMonGiangVien cm, NhanChuyenMon n " +
                         "where cm.ID_NhanChuyenMon = n.ID and MaGV = '" + maGV + "'";
            return sQLfunction.GetDataToTable(sql);
        }

        public string modifyString(string s)
        {
            StringBuilder newString = new StringBuilder();
            for(int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                    newString.Append(char.ToUpper(s[i]));
                else
                    newString.Append(char.ToLower(s[i]));
            }    
            return newString.ToString();
        }

        public int insertNhan(NhanChuyenMon nhan)
        {
            string sql = "insert into NhanChuyenMon values(N'" + nhan.ChuyenMon + "')";
            return sQLfunction.RunNonQuery(sql);
        }    
        public int getInsertedNhanChuyenMonID(string chuyenMon)
        {
            string sql = "select top 1 ID from NhanChuyenMon order by ID desc";
            string result = sQLfunction.RunQuery(sql);
            if(result == null)
                return 0;
            return int.Parse(result);
        }    

        public int insertGV_ChuyenMon(string maGV, NhanChuyenMon cm)
        {
            string sql = "insert into ChuyenMonGiangVien values(" + cm.ID1 + ",'" + maGV + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public DataTable getChuyenMonChuaCo(string maGV)
        {
            string sql = "select * from NhanChuyenMon " +
                         "where ID not in " +
                         "(select ID_NhanChuyenMon from ChuyenMonGiangVien where MaGV = '" + maGV + "')";
            return sQLfunction.GetDataToTable(sql);
        }

        public int updateTrangThai(string maGV, bool trangThai)
        {
            string sql = "update Giangvien set ThamGiaKLTN = '" + trangThai 
                        + "' where maGV = '" + maGV +"'";
            return sQLfunction.RunNonQuery(sql);
        }

        public DataTable findGVbyMaGV(string maGV, DataTable originalDT)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("MaGV = '{0}'", maGV);
            return dt;
        }

        public DataTable findGVbyTen(string hoTen, DataTable originalDT)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("HoTen like '%{0}%'", hoTen);
            return dt;
        }

        public int deleteNhanFromGiangVien(int id_Nhan, string maGV)
        {
            string sql = "delete ChuyenMonGiangVien where MaGV = '" + maGV + "' and " +
                         "ID_NhanChuyenMon = '" + id_Nhan + "'";
            return sQLfunction.RunNonQuery(sql);
        }

    }
}
