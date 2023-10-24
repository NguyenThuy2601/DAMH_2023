using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class ThoiGian
    {
        private int ID;
        private string hocKi;
        private string namHoc;
        private string hocKi_NamHoc;

        public ThoiGian()
        {

        }
        public ThoiGian(string hocKi, string namBD, string namKT)
        {
            this.hocKi = hocKi;
            this.namHoc = namBD + "-" + namKT;
        }

        public ThoiGian(int iD, string hocKi, string namHoc)
        {
            ID = iD;
            this.hocKi = hocKi;
            this.namHoc = namHoc;
            hocKi_NamHoc = "HK" + hocKi + "  " + namHoc;
        }

        public ThoiGian(string hocKi, string namHoc)
        {
            this.hocKi = hocKi;
            this.namHoc = namHoc;
        }

        public int ID1 { get => ID; }
        public string HocKi { get => hocKi; }
        public string NamHoc { get => namHoc; }
        public string HocKi_NamHoc { get => hocKi_NamHoc; }

        public int getNamHocBD()
        {
            string[] temp = namHoc.Split('-');
            return int.Parse(temp[0]);
        }

        public int getNamHocKT()
        {
            string[] temp = namHoc.Split('-');
            return int.Parse(temp[1]);
        }

        public int getHocKi()
        {
            return int.Parse(HocKi);
        }
    }
}
