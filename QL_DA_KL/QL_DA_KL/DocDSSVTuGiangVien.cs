using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_DA_KL.BUS;
using QL_DA_KL.DTO;

namespace QL_DA_KL
{
    public partial class DocDSSVTuGiangVien : Form
    {
        DocDSSVTuGiangVienBUS bus;
        DataTable dt;
        ThoiGian tg;
        public DocDSSVTuGiangVien()
        {
            InitializeComponent();
            bus = new DocDSSVTuGiangVienBUS();
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
                    readFileDgv.DataSource = dt;
            }
        }
        //private void loadThoiGianCbb()
        //{
        //    tgCbb.ValueMember = "ID1";
        //    tgCbb.DisplayMember = "HocKi_NamHoc";
        //    tgCbb.DataSource = bus.tranferDTtoListThoiGian();
        //}

        private void loadGiangVienCbb()
        {
            gvCbb.ValueMember = "MaGV";
            gvCbb.DisplayMember = "HoTen";
            gvCbb.DataSource = bus.getDSGV();

            gvCbb.Text = "";
        }

        private void DocDSSVTuGiangVien_Load(object sender, EventArgs e)
        {
            tg = bus.tranferDTtoThoiGianObject();

            fileNameLbl.Text = "";
            hkLbl.Text = tg.HocKi_NamHoc;
            
            loadGiangVienCbb();

        }

        private void upFileBtn_Click(object sender, EventArgs e)
        {
            if (gvCbb.Text == "")
                MessageBox.Show("Chưa chọn giảng viên");
            if (fileNameLbl.Text == "")
                MessageBox.Show("Chưa chọn file");
            else
            {
                List<String> sucess = new List<string>();
                DataTable failed = dt.Clone();
                failed.ImportRow(dt.Rows[1]);
                if (bus.readDataTableToDB(dt, gvCbb.SelectedValue.ToString(), tg, ref sucess, ref failed) > 0)
                {
                    MessageBox.Show("thành công");
                    failedDgv.DataSource = failed;
                    sucessDgv.DataSource = bus.getSucessFromDT(sucess);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra");
                }
            }    
        }
    }
}
