using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class SinhVien
    {
        string MSSV;
        string hoLot;
        string ten;
        string SDT;
        string emailOU;
        string chuyenNganh;
        string emailCaNhan;
        string mssvBanCungNhom;
        bool lamKLTN;
        string NVGV1;
        string NVGV2;
        private bool lamLaiDAMH;
        private int namLamLai;
        string nganh;
        double GPA;
        int idDAMH;
        int idKLTN;

        public string MSSV1 { get => MSSV; }
        public string HoLot { get => hoLot; }
        public string Ten { get => ten; }
        public string SDT1 { get => SDT;}
        public string EmailOU { get => emailOU; }
        public string EmailCaNhan { get => emailCaNhan;  }
        public string MssvBanCungNhom { get => mssvBanCungNhom; }
        public bool LamKLTN { get => lamKLTN; }
        public string NVGV11 { get => NVGV1;}
        public string NVGV21 { get => NVGV2; }
        public bool LamLaiDAMH { get => lamLaiDAMH; }
        public int NamLamLai { get => namLamLai;  }
        public string Nganh { get => nganh; }
        public double gPA { get => GPA; }
        public string ChuyenNganh { get => chuyenNganh; }


        public SinhVien(string mSSV, string hoLot, string ten, string sDT, string mailOU, string mailCaNhan, string mssvbanCungNhom, bool lamKLTN, string nVGV1, string nVGV2, string nganh, double gPA, string chuyenNganh)
        {
            MSSV = mSSV;
            this.hoLot = hoLot;
            this.ten = ten;
            SDT = sDT;
            this.emailOU = mailOU;
            this.emailCaNhan = mailCaNhan;
            this.lamKLTN = lamKLTN;
            if (mssvbanCungNhom == "")
                this.mssvBanCungNhom = null;
            else
                this.mssvBanCungNhom = mssvbanCungNhom;

            if (NVGV1 == "")
                NVGV1 = null;
            else
                NVGV1 = nVGV1;
            if (NVGV2 == "")
                NVGV2 = null;
            else
                NVGV2 = nVGV2;
            this.nganh = nganh;
            GPA = gPA;
            this.chuyenNganh = chuyenNganh;
        }
    }
}
