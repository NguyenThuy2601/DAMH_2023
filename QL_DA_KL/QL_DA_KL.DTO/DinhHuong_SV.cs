using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class DinhHuong_SV
    {
        private int ID_DinhHuong;
        private string MSSV;

        public DinhHuong_SV(int iD_DinhHuong, string mSSV)
        {
            ID_DinhHuong = iD_DinhHuong;
            MSSV = mSSV;
        }

        public int ID_DinhHuong1 { get => ID_DinhHuong;}
        public string MSSV1 { get => MSSV;}
    }
}
