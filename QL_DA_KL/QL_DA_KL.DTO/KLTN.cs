using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class KLTN
    {
        private string iD;
        private string tenDeTai;
        private int thoiGianToChuc;
        private string GVHD;

        public KLTN(string iD, string tenDeTai, int thoiGianToChuc, string gVHD)
        {
            this.iD = iD;
            this.tenDeTai = tenDeTai;
            this.thoiGianToChuc = thoiGianToChuc;
            GVHD = gVHD;
        }

        public string ID { get => iD; }
        public string TenDeTai { get => tenDeTai;  }
        public int ThoiGianToChuc { get => thoiGianToChuc; }
        public string GVHD1 { get => GVHD;  }
    }
}
