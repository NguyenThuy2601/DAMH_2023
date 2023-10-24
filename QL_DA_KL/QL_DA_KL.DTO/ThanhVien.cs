using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class ThanhVien
    {
        private string maGV;
        private string ID_HoiDong;
        private string vaiTro;

        public ThanhVien(string maGV, string iD_HoiDong, string vaiTro)
        {
            this.maGV = maGV;
            ID_HoiDong = iD_HoiDong;
            this.vaiTro = vaiTro;
        }

        public string MaGV { get => maGV; set => maGV = value; }
        public string ID_HoiDong1 { get => ID_HoiDong; set => ID_HoiDong = value; }
        public string VaiTro { get => vaiTro; set => vaiTro = value; }
    }
}
