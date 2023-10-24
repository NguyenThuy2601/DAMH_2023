using QL_DA_KL.DTO;
using QL_DA_KL.BUS;
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
    public partial class DocDSSVLamDAMH : Form
    {
        DataTable dt;
        DocDSSVLamDAMHBUS bus;
        public DocDSSVLamDAMH()
        {
            InitializeComponent();
            bus = new DocDSSVLamDAMHBUS();
            fileNameLbl.Text = "";
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
                    dssvDgv.DataSource = dt;
            }
        }

        private void upFileBtn_Click(object sender, EventArgs e)
        {

            //for (int i = 1; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[i];
            //    MessageBox.Show(dr[0].ToString());
            //    MessageBox.Show(dr[18].ToString());
            //    MessageBox.Show(bus.findGV(dr[18].ToString()));
            //}
            if (fileNameLbl.Text == "")
                MessageBox.Show("Chưa tải file");
            if (namBDTxt.Text == "" || namKTtxt.Text == "" || cbbHocKi.Text == "")
                MessageBox.Show("Chưa điền thông tin học kì tổ chức năm học");
            else
            {
                if (bus.checkApproriateSchoolYear(namBDTxt.Text, namKTtxt.Text))
                {
                    ThoiGian tg = new ThoiGian(cbbHocKi.Text, namBDTxt.Text, namKTtxt.Text);
                    if (bus.checkArroriateSem(tg))
                    {
                        if (bus.getHocKiNamHoc(tg) == 0)
                            bus.insertHocKiNamHoc(tg);
                        int id_tg = bus.getHocKiNamHoc(tg);
                        List<SinhVien> listSV = bus.tranferDSSVtoList(dt);
                        List<DinhHuong_SV> listDH = bus.getDinhHuongCuaSinhVienFromDataTable(dt);
                        if (bus.insertListToDB(listSV, id_tg) > 0 && bus.insertListOfDInhHuongToDB(listDH) > 0)
                        {
                            MessageBox.Show("Thành công");
                            dssvDgv.DataSource = bus.getInsertedDSSV();
                        }

                        else
                            MessageBox.Show("Thất bại");
                    }
                    else
                        MessageBox.Show("Học kì không hợp lệ");
                }
                else
                    MessageBox.Show("Năm học không hợp lệ");
            }
        }
    }
}
