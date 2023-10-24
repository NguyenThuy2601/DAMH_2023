using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class GiangVien
    {
        private string maGV;
        private string hoTen;
        private string hocVi;
        private string eMail;

        public string MaGV { get => maGV; }
        public string HoTen { get => hoTen;}
        public string HocVi { get => hocVi;}
        public string EMail { get => eMail;}
        public string HocViHoTen { get => HocVi.Trim() + ". " + HoTen.Trim();}

        public GiangVien(string maGV, string hoTen, string hocVi, string eMail)
        {
            this.maGV = maGV;
            this.hoTen = hoTen;
            this.hocVi = hocVi;
            this.eMail = eMail;
        }

        public GiangVien(string maGV, string hoTen, string hocVi)
        {
            this.maGV = maGV;
            this.hoTen = hoTen;
            this.hocVi = hocVi;
        }

        public GiangVien(string maGV, string hoTen)
        {
            this.maGV = maGV;
            this.hoTen = hoTen;
        }
    }
}
