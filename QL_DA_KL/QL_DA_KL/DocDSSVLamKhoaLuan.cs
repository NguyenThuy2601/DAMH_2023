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
    public partial class DocDSSVLamKhoaLuan : Form
    {
        DataTable dt;
        DataTable dtResult;
        DocDSSVLamKLTNBUS bus;
        public DocDSSVLamKhoaLuan()
        {
            InitializeComponent();
        }

        private void upFileBtn_Click(object sender, EventArgs e)
        {
            if (nameLbl.Text == "")
                MessageBox.Show("Chưa tải file");
            if (hocKiCbb.Text == "" || namKTTxt.Text == "" || namBDTxt.Text == "")
                MessageBox.Show("Chưa điền thông tin học kì tổ chức năm học");
            else
            {
                if (bus.checkApproriateSchoolYear(namBDTxt.Text, namKTTxt.Text) == false)
                    MessageBox.Show("Năm nhập vào không hợp lệ");
                else
                {
                    ThoiGian tg = new ThoiGian(hocKiCbb.Text, namBDTxt.Text, namKTTxt.Text);
                    if (bus.checkArroriateSem(tg) == false)
                        MessageBox.Show("Học kì đã qua không thể thêm sinh viên");
                    else
                    {
                        if (bus.getHocKiNamHoc(tg) == 0)
                            bus.insertHocKiNamHoc(tg);
                        int idTG = bus.getHocKiNamHoc(tg);
                        if(!bus.checkMatchSemWithDAMH(idTG))
                        {
                            MessageBox.Show("Năm làm đồ án và khóa luận không thể trùng nhau");
                            return;
                        }    
                        if (bus.updateSVLamKLTNFromDT(dt, idTG) == 0)
                            MessageBox.Show("Thất bại");
                        else
                        {
                            MessageBox.Show("Thành công");
                            dtResult = bus.getListKLTN(idTG); ;
                            resultDgv.DataSource = dtResult;
                            rowInDataBaseLbl.Text = (dtResult.Rows.Count).ToString() + " sinh viên";
                        }    

                    }    
                }    
            }    
        }

        private void uploadFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            String path = "";
            dlg.Multiselect = false;
            dlg.Filter = "Excel Files|*.xls;*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                path = dlg.FileName;
                string[] temp = path.Split('\\');
                nameLbl.Text = temp[temp.Length - 1];
                dt = bus.getEcelToDatatable(path);
                if (!bus.checkApproriateExcel(dt))
                {
                    MessageBox.Show("File không hợp lệ với mục");
                    nameLbl.Text = "";
                }
                else
                {
                    fileDetailDgv.DataSource = dt;
                    numOfRowInData.Text = (dt.Rows.Count - 1).ToString() + " Sinh viên";
                }    
                    
            }
        }

        private void DocDSSVLamKhoaLuan_Load(object sender, EventArgs e)
        {
            bus = new DocDSSVLamKLTNBUS();
        }
    }
}
