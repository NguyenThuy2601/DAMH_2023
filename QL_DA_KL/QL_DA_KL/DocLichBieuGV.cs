using QL_DA_KL.BUS;
using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DA_KL
{
    public partial class DocLichBieuGV : Form
    {
        DocLichBieuGVBUS bus;
        DataTable dt;
        public DocLichBieuGV()
        {
            InitializeComponent();
        }

        private void taiFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            String path = "";
            dlg.Multiselect = false;
            dlg.Filter = "Excel Files|*.xls;*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                path = dlg.FileName;
                string[] temp = path.Split('\\');
                fileNameLbl.Text = temp[temp.Length - 1];
                dt = bus.getEcelToDatatable(path);
                if (!bus.checkApproriateExcel(dt))
                {
                    MessageBox.Show("File không hợp lệ với mục");
                    fileNameLbl.Text = "";
                }
                else
                    fileDetailDgv.DataSource = dt;
            }
        }

        private void DocLichBieuGV_Load(object sender, EventArgs e)
        {
            bus = new DocLichBieuGVBUS();
        }

        private void upFileBtn_Click(object sender, EventArgs e)
        {
            bus.deleteLichBieu();
            List<LichBieu> list = bus.createListLichBieuFromDT(dt);
            if (bus.insertListLichBieuToDB(list) == 0)
            {
                MessageBox.Show("Thất bại");
            }   
            else
            {
                MessageBox.Show("Thành công");
                resultDgv.DataSource = bus.getInsertedLichBieu();
            }    
        }
    }
}
