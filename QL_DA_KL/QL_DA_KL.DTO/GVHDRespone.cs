using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DA_KL.DTO
{
    public class GVHDRespone
    {
        private string hocVi;
        private string maGV;
        private int numOfDeTai;

        public string MaGV { get => maGV; }
        public int NumOfDeTai { get => numOfDeTai; }
        public string HocVi { get => hocVi;}


        public GVHDRespone(string maGV, int numOfDeTai, string hvi)
        {
            this.maGV = maGV;
            this.numOfDeTai = numOfDeTai;
            hocVi = hvi;
        }

        public GVHDRespone()
        {
            
        }

        public void updateDeTai()
        {
            numOfDeTai -= 1;
        }

    }
}
