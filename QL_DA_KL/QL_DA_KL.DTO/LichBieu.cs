using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class LichBieu
    {
        private int iD;
        private string buoiTrongNgay;
        private string maGV;
        private string thuTrongTuan;

        public LichBieu(int iD, string buoiTrongNgay, string maGV, string thuTrongTuan)
        {
            this.iD = iD;
            this.buoiTrongNgay = buoiTrongNgay;
            this.maGV = maGV;
            this.thuTrongTuan = thuTrongTuan;
        }

        public LichBieu(string buoiTrongNgay, string maGV, string thuTrongTuan)
        {
            this.buoiTrongNgay = buoiTrongNgay;
            this.maGV = maGV;
            this.thuTrongTuan = thuTrongTuan;
        }

        public int ID { get => iD; }
        public string BuoiTrongNgay { get => buoiTrongNgay; set => buoiTrongNgay = value; }
        public string MaGV { get => maGV; set => maGV = value; }
        public string ThuTrongTuan { get => thuTrongTuan; set => thuTrongTuan = value; }


    }
}
