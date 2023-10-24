using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_DA_KL.DAO;

namespace QL_DA_KL.BUS
{
    public class ModelBus
    {

            SQLfunction SQLfunction = null;

            public SQLfunction sQLfunction { get => SQLfunction; }

            public void load()
            {
                SQLfunction = new SQLfunction();
                SQLfunction.Connect();
            }
            public void close()
            {
                SQLfunction.Disconnect();
            }
    }
}
