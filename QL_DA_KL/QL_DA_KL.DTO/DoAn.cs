using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class DoAn
    {
        private string ID;
        private int thoiGianToChuc;
        private string GVHD;

        private String generateID(string HocKi)
        {
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();
            String[] temp = myuuidAsString.Split('-');

            DateTime current_year = DateTime.Now;
            string year = current_year.Year.ToString();
            string ID = HocKi.Trim() + year +temp[0];

            return ID;
        }
        public string ID1 { get => ID; set => ID = value; }
        public int ThoiGianToChuc { get => thoiGianToChuc; set => thoiGianToChuc = value; }
        public string GVHD1 { get => GVHD; set => GVHD = value; }

        public DoAn(string iD, int thoiGianToChuc, string gVHD)
        {
            ID = iD;
            this.thoiGianToChuc = thoiGianToChuc;
            GVHD = gVHD;
        }
        public DoAn(string gVHD, string HocKi, int thoiGianToChuc)
        {
            ID = generateID(HocKi);
            this.thoiGianToChuc = thoiGianToChuc;
            GVHD = gVHD;
        }

        public DoAn()
        {
           
        }
    }
}
