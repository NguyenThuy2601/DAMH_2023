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
    public partial class QLSV : Form
    {

        QLSVBUS bus;
        DataTable dt;
        string idTG;
        string latestIdHK;
        string idGVHD;
        public QLSV()
        {
            InitializeComponent();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string currentGVHD = gvhdLbl.Text;
            string mssv = mssvLbl.Text;
            if ( currentGVHD == "" )
            {
                if(bus.createDoAn(idGVHD, idTG, mssv) == 0)
                {
                    MessageBox.Show("Thất bại");
                    gvhdCbb.Text = "";
                } 
                else
                {
                    MessageBox.Show("Thành công");
                    DataTable dt = bus.getListGiangVienByID(idGVHD);
                    idGVHD = dt.Rows[0]["MaGV"].ToString();
                    gvhdCbb.Text = "";
                    gvhdLbl.Text = dt.Rows[0]["HocVi"].ToString().Trim() + ". " + dt.Rows[0]["HoTen"].ToString().Trim();

                    if (idTG.Trim().Equals(latestIdHK.Trim()))
                        dt = bus.getListSVInLatestHocKi(idTG);
                    else
                        dt = bus.getListSinhVien(idTG);
                    dataGridView1.DataSource = dt;
                }    
                    
            }    
            else
            {
                if (bus.updateGVHD(idGVHD, idTG, mssv) == 0)
                {
                    MessageBox.Show("Thất bại");
                    gvhdCbb.Text = "";
                }    
                    
                else
                {
                    MessageBox.Show("Thành công");
                    DataTable dt = bus.getListGiangVienByID(idGVHD);
                    idGVHD = dt.Rows[0]["MaGV"].ToString();
                    gvhdCbb.Text = "";
                    gvhdLbl.Text = dt.Rows[0]["HocVi"].ToString().Trim() + ". " + dt.Rows[0]["HoTen"].ToString().Trim();

                    if (idTG.Trim().Equals(latestIdHK.Trim()))
                        dt = bus.getListSVInLatestHocKi(idTG);
                    else
                        dt = bus.getListSinhVien(idTG);
                    dataGridView1.DataSource = dt;
                }    
                    
            }    
        }

        public void getDataToDt()
        {
            dt = bus.getListSVInLatestHocKi(idTG);
            dataGridView1.DataSource = dt;
        }

        private void QLSV_Load(object sender, EventArgs e)
        {
            bus = new QLSVBUS();

            idTG = bus.getLatestInputThoiGian();
            latestIdHK = bus.getLatestInputThoiGianINDoAn();
            

            updateBtn.Enabled = false;

            hkCbb.ValueMember = "ID1";
            hkCbb.DisplayMember = "HocKi_NamHoc";
            hkCbb.DataSource = bus.tranferDTToListTG();

            getDataToDt();
        }

        private void gvhdCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("true1");
        }

        private void gvhdCbb_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void hkCbb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hkCbb_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void setDataForGVcbb(DataTable gvhdDT)
        {
            gvhdCbb.ValueMember = "MaGV";
            gvhdCbb.DisplayMember = "HocViHoTen";
            gvhdCbb.DataSource = bus.tranferDTToListGV(gvhdDT);
            gvhdCbb.Text = "";
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            mssvLbl.Text = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            hoTenLbl.Text = dataGridView1.CurrentRow.Cells["HoTen"].Value.ToString();
            gpaLbl.Text = dataGridView1.CurrentRow.Cells["Nguyện vọng KLTN"].Value.ToString();
            emailOU.Text = dataGridView1.CurrentRow.Cells["EmailOU"].Value.ToString();
            emailCaNhan.Text = dataGridView1.CurrentRow.Cells["EmailCaNhan"].Value.ToString();
            sdtLbl.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();

            if (dataGridView1.CurrentRow.Cells["Nguyện vọng KLTN"].Value.ToString().Equals("Không đủ điều kiện"))
                nvKLTNlbl.Text = "Không đủ điều kiện";
            else
                if(dataGridView1.CurrentRow.Cells["Nguyện vọng KLTN"].Value.ToString().Equals(""))
                    nvKLTNlbl.Text = "Không";
                else
                    nvKLTNlbl.Text = "Có";

            if (dataGridView1.CurrentRow.Cells["Số lượng thành viên"].Value.ToString() == " ")
                slLbl.Text = "1";
            else
                slLbl.Text = "2";

            nganhLbl.Text = dataGridView1.CurrentRow.Cells["Nganh"].Value.ToString();
            chuuyenNganhLbl.Text = dataGridView1.CurrentRow.Cells["ChuyenNganh"].Value.ToString();
            gvhdCbb.Text = dataGridView1.CurrentRow.Cells["Giảng viên hướng dẫn"].Value.ToString();
            dinhHuonglbl.Text = dataGridView1.CurrentRow.Cells["DinhHuong"].Value.ToString();
            gvhdLbl.Text = dataGridView1.CurrentRow.Cells["Giảng viên hướng dẫn"].Value.ToString();

            DataTable gvhdDT = bus.getListGiangVienByTinhTrangLamKLTN(nvKLTNlbl.Text);
            setDataForGVcbb(gvhdDT);

            if (idTG.Equals(latestIdHK))
                updateBtn.Enabled = true;
            else
                updateBtn.Enabled = false;
        }

        private void gvhdCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idGVHD = gvhdCbb.SelectedValue.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            if (mssvTxt.Text == "")
            {
                if (idTG.Trim().Equals(latestIdHK.Trim()))
                {
                    dt = bus.getListSVInLatestHocKi(idTG);
                    dataGridView1.DataSource = dt;
                }    
                else
                {
                    dt = bus.getListSinhVien(idTG);
                    dataGridView1.DataSource = dt;
                }    
                    
            }    
            else
            {
                
                dataGridView1.DataSource = bus.findSvBYMSSV(mssvTxt.Text);
            }    
                
        }

        private void findNameBtn_Click(object sender, EventArgs e)
        {
            if (findNameTxt.Text == "")
            {
                if (idTG.Trim().Equals(latestIdHK.Trim()))
                    dt = bus.getListSVInLatestHocKi(idTG);
                else
                    dt = bus.getListSinhVien(idTG);
                dataGridView1.DataSource = dt;
            }
            else
            {
                //DataTable allSVDT = bus.getAllSVInDB();
                dataGridView1.DataSource = bus.findSvBYName(findNameTxt.Text);
            }
        }

        private void hkCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idTG = hkCbb.SelectedValue.ToString().Trim();
            if (idTG.Trim().Equals(latestIdHK.Trim()))
                dt = bus.getListSVInLatestHocKi(idTG);
            else
                dt = bus.getListSinhVien(idTG);
            dataGridView1.DataSource = dt;
        }

        private void QLSV_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
