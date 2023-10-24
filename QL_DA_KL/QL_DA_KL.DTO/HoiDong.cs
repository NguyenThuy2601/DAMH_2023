using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class HoiDong
    {
        private string idHoiDong;
        private string TGToChuc;
        private int id_HocKiToChuc;
        private string idBuoiBaoVe;

        public HoiDong(string ngayToChuc, string gioToChuc, int id_HocKiToChuc)
        {
            TGToChuc = ngayToChuc.Split(' ')[0] + " " + gioToChuc;
            this.id_HocKiToChuc = id_HocKiToChuc;
        }

        public HoiDong(string idHD, string TGToChuc)
        {
            idHoiDong = idHD;
            this.TGToChuc = TGToChuc;
        }

        public string TGToChuc1 { get => TGToChuc; set => TGToChuc = value; }
        public int Id_HocKiToChuc { get => id_HocKiToChuc; set => id_HocKiToChuc = value; }
        public string IdBuoiBaoVe { get => idBuoiBaoVe; set => idBuoiBaoVe = value; }
        public string IdHoiDong { get => idHoiDong; set => idHoiDong = value; }
    }
}
