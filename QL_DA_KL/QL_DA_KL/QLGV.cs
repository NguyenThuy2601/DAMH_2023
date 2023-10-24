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
    public partial class QLGV : Form
    {
        QLGVBUS bus;
        DataTable dt;
        DataTable dtChuyenMon;
        NhanChuyenMon selectedNhan;
        NhanChuyenMon selectedNhanCbb;
        bool flagSelectFromDgv = false;

        public QLGV()
        {
            InitializeComponent();
           

            maGVlbl.Text = "";
            hoTenlbl.Text = "";
            hocVilbl.Text = "";
            emailLbl.Text = "";
           

            nhanListbox.DataSource = null;
            seletedChuyenMonLbl.Text = "";

            updateBtn.Enabled = false;
            themBtn.Enabled = false;
            xoaBtn.Enabled = false;

            bus = new QLGVBUS();

            dsgvDgv.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dsgvDgv.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        

        private void findByMaGVBtn_Click(object sender, EventArgs e)
        {
            if (maGVTxt.Text == "")
                loadDSGV();
            else
                dsgvDgv.DataSource = bus.findGVbyMaGV(maGVTxt.Text, dt);
        }

        private void QLGV_Load(object sender, EventArgs e)
        {
            loadDSGV();
        }

        private void loadDSGV()
        {
            dt = bus.getListGiangVienToDT();
            dsgvDgv.DataSource = dt;
        }    

        public void getChuyenMonGV()
        {
            
            nhanListbox.DataSource = bus.getGV_ChuyenMon(dsgvDgv.CurrentRow.Cells["MaGV"].Value.ToString()); ;
            nhanListbox.DisplayMember = "ChuyenMon";
            nhanListbox.ValueMember = "ID";
            
            
        }

        public void setChuyenMonGVChuaCo()
        {

            dtChuyenMon = bus.getChuyenMonChuaCo(dsgvDgv.CurrentRow.Cells["MaGV"].Value.ToString());
            
            
            chuyenMonCbb.DisplayMember = "ChuyenMon";
            chuyenMonCbb.ValueMember = "ID";
            chuyenMonCbb.DataSource = dtChuyenMon;

            chuyenMonCbb.Text = "";
            //chuyenMonCbb.SelectedItem = null;
            //chuyenMonCbb.SelectedIndex = -1;
        }

        private void dsgvDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dsgvDgv.CurrentRow.Selected = true;
            maGVlbl.Text = dsgvDgv.CurrentRow.Cells["MaGV"].Value.ToString();
            hoTenlbl.Text = dsgvDgv.CurrentRow.Cells["HoTen"].Value.ToString();
            emailLbl.Text = dsgvDgv.CurrentRow.Cells["Email"].Value.ToString();
            hocVilbl.Text = dsgvDgv.CurrentRow.Cells["HocVi"].Value.ToString();
            checkBox1.Checked = Boolean.Parse(dsgvDgv.CurrentRow.Cells["ThamGiaKLTN"].Value.ToString());

            getChuyenMonGV();
            setChuyenMonGVChuaCo();

            updateBtn.Enabled = true;
            themBtn.Enabled = true;
            xoaBtn.Enabled = true;

            
        }

        private void nhanListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(nhanListbox.SelectedValue != null)
            {
                int ignoreMe = 0;
                bool successfullyParsed = int.TryParse(nhanListbox.SelectedValue.ToString(), out ignoreMe);
                if (successfullyParsed)
                {
                    selectedNhan = new NhanChuyenMon(
                                    int.Parse(nhanListbox.SelectedValue.ToString()),
                                    nhanListbox.SelectedItem.ToString());

                    seletedChuyenMonLbl.Text = ((DataRowView)nhanListbox.SelectedItem)["ChuyenMon"].ToString();
                }
            }    
              
            
        }

        private void themBtn_Click(object sender, EventArgs e)
        {
            if (chuyenMonCbb.Text == "")
                MessageBox.Show("Chưa chọn chuyên môn để thêm");
            else
            {
                DataRow[] nhanList = dtChuyenMon.Select("ChuyenMon = '" + bus.modifyString(chuyenMonCbb.Text) + "'");

                if (nhanList.Length == 0)
                {
                    NhanChuyenMon cm = new NhanChuyenMon(bus.modifyString(chuyenMonCbb.Text));
                    bus.insertNhan(cm);
                    selectedNhanCbb = new NhanChuyenMon(bus.getInsertedNhanChuyenMonID(bus.modifyString(chuyenMonCbb.Text)),
                                                        bus.modifyString(chuyenMonCbb.Text));
                }
                else
                {
                    selectedNhanCbb = new NhanChuyenMon(int.Parse(nhanList[0]["ID"].ToString()),
                                                        bus.modifyString(chuyenMonCbb.Text));
                }
                if (bus.insertGV_ChuyenMon(maGVlbl.Text, selectedNhanCbb) > 0)
                {
                    MessageBox.Show("Thành công");
                    chuyenMonCbb.SelectedItem = null;
                    chuyenMonCbb.Text = "";
                    selectedNhanCbb = new NhanChuyenMon();

                    getChuyenMonGV();

                    setChuyenMonGVChuaCo();
                }
            }                              
        }

        private void chuyenMonCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (chuyenMonCbb.SelectedIndex != -1)
            //    selectedNhanCbb = new NhanChuyenMon(int.Parse(chuyenMonCbb.SelectedValue.ToString()),
            //                              chuyenMonCbb.Text);
            //if(chuyenMonCbb.ValueMember.ToString() == null)
            //    MessageBox.Show("0");
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            
             if (bus.updateTrangThai(maGVlbl.Text, checkBox1.Checked) > 0)
             {
                    MessageBox.Show("Thay đổi thành công");
                    loadDSGV();
             }    
             else
             {
                    MessageBox.Show("Có lỗi xảy ra");
                    checkBox1.Checked = Boolean.Parse(dsgvDgv.CurrentRow.Cells["ThamGiaKLTN"].Value.ToString());
             }    
        
        }

        

        private void findByNameBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
                loadDSGV();
            else
                dsgvDgv.DataSource = bus.findGVbyTen(nameTxt.Text, dt);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
           

            maGVlbl.Text = "";
            hoTenlbl.Text = "";
            hocVilbl.Text = "";
            emailLbl.Text = "";
            

            nhanListbox.DataSource = null;
            chuyenMonCbb.DataSource = null;
            seletedChuyenMonLbl.Text = "";

            selectedNhan = new NhanChuyenMon();
            selectedNhanCbb = new NhanChuyenMon();

            nhanListbox.SelectedItem = null;
            chuyenMonCbb.SelectedItem = null;

            updateBtn.Enabled = false;
            themBtn.Enabled = false;
            xoaBtn.Enabled = false;

            maGVTxt.Text = "";
            nameTxt.Text = "";

            loadDSGV();
        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            if(bus.deleteNhanFromGiangVien(selectedNhan.ID1, maGVlbl.Text) > 0)
            {
                MessageBox.Show("Xóa nhãn thành công");
                seletedChuyenMonLbl.Text = "";
                getChuyenMonGV();
                setChuyenMonGVChuaCo();
            }   
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
                selectedNhan = null;
                nhanListbox.SelectedItem = null;
                seletedChuyenMonLbl.Text = "";
            }    
        }

        private void dsgvDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
