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
    public class DocLichBieuGVBUS :ModelBus
    {
        public DocLichBieuGVBUS ()
        {
            base.load();
        }

        public bool checkApproriateExcel(DataTable dt)
        {
            if (dt.Rows.Count < 1 || dt.Columns.Count != 6)
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

        public int deleteLichBieu()
        {
            string sql = "delete from LichBieu";
            return sQLfunction.RunNonQuery(sql);
        }

        public string getMaGVByName(string name)
        {
            string sql = string.Format("select MaGV from GiangVien where upper(HoTen) = N'{0}'", name);
            return sQLfunction.RunQuery(sql);
        }    

        public int insertLichBieu(LichBieu lich)
        {
            string sql = string.Format("insert into LichBieu values('{0}', '{1}', '{2}')", lich.BuoiTrongNgay, lich.MaGV, lich.ThuTrongTuan);
            return sQLfunction.RunNonQuery(sql);
        }

        public List<string> getBuoiTrongNgay(string cacBuoiTrongNgay)
        {
            string[] temp = cacBuoiTrongNgay.Split(',');
            List<string> list = new List<string>(temp);
            return list;
        }

        public string formatBuoiTrongTuan(string buoiTrongTuan)
        {
            string[] temp = buoiTrongTuan.Split(' ');
            switch(temp[0])
            {
                case "Chiều":
                    return "C";
                default:
                    return "S";
            }    
        }

        public void createLichBieuObject(List<String> cacBuoiTrongNgay, string maGV, string thuTrongTuan, ref List<LichBieu> list)
        {
           for(int i = 0; i < cacBuoiTrongNgay.Count; i++)
            {
                string buoiTrongNgayID = formatBuoiTrongTuan(cacBuoiTrongNgay[i]); 
                LichBieu lich = new LichBieu(buoiTrongNgayID, maGV, thuTrongTuan);
                list.Add(lich);
            }    
        }
        public List<LichBieu> createListLichBieuFromDT(DataTable dt)
        {
            List<LichBieu> lich = new List<LichBieu>();
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string maGV = getMaGVByName(dr[0].ToString());


                if (dr[1].ToString() != null)
                {
                    createLichBieuObject(getBuoiTrongNgay(dr[1].ToString()), maGV, "2", ref lich);
                }    
                if (dr[2].ToString() != null)
                {
                    createLichBieuObject(getBuoiTrongNgay(dr[2].ToString()), maGV, "3", ref lich);
                }
                if (dr[3].ToString() != null)
                {
                    createLichBieuObject(getBuoiTrongNgay(dr[3].ToString()), maGV, "4", ref lich);
                }
                if (dr[4].ToString() != null)
                {
                    createLichBieuObject(getBuoiTrongNgay(dr[4].ToString()), maGV, "5", ref lich);
                }
                if (dr[5].ToString() != null)
                {
                    createLichBieuObject(getBuoiTrongNgay(dr[5].ToString()), maGV, "6", ref lich);
                }
            }
            return lich;
        }

        public int insertListLichBieuToDB(List<LichBieu> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (insertLichBieu(list[i]) == 0)
                    return 0;
            }
            return 1;
        }

        public DataTable getInsertedLichBieu()
        {
            string sql = "select l.*, gv.HoTen from LichBieu l, GiangVien gv where l.MaGV = gv.MaGV";
            return sQLfunction.GetDataToTable(sql);
        }
    }
}
