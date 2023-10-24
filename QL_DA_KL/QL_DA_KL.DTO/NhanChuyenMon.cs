using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class NhanChuyenMon
    {
        private int ID;
        private string chuyenMon;

        public int ID1 { get => ID;  }
        public string ChuyenMon { get => chuyenMon; }

        public NhanChuyenMon(int iD, string chuyenMon)
        {
            ID = iD;
            this.chuyenMon = chuyenMon;
        }
        public NhanChuyenMon(string chuyenMon)
        {
            this.chuyenMon = chuyenMon;
        }
        public NhanChuyenMon()
        {
            
        }


    }
}
