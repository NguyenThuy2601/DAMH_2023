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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        internal void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }


        private void hideSubMenu()
        {
            if (subBTN.Visible == true)
                subBTN.Hide();
        }

        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                //hideSubMenu();
                submenu.Show() ;
            }
            else
                subBTN.Hide();
        }

        private void buttonCustom3_Click(object sender, EventArgs e)
        {
            showSubMenu(subBTN);
        }

        private void QLGVbtn_Click(object sender, EventArgs e)
        {
            openChildForm(new QLGV());
            hideSubMenu();
        }

        private void buttonCustom1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new DocDSSVLamDAMH());
            hideSubMenu();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void docDSSVTuGiangVienBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new DocDSSVTuGiangVien());
            hideSubMenu();
        }

        private void subBTN_Paint(object sender, PaintEventArgs e)
        {

        }

        protected void buttonCustom2_Click(object sender, EventArgs e)
        {
            openChildForm(new DocDSSVLamKhoaLuan());
            hideSubMenu();
        }

        private void buttonCustom3_Click_1(object sender, EventArgs e)
        {
            openChildForm(new DocLichBieuGV());
        }

        private void buttonCustom4_Click(object sender, EventArgs e)
        {
            openChildForm(new PhanCongGV(this));
        }

        private void qLSVBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new QLSV());
        }

        private void qLNhomSVBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new QLNhomSV());
        }

        private void qlHoiDongBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyHoiDong());
        }

        private void buttonCustom7_Click(object sender, EventArgs e)
        {
            openChildForm(new GuiEmail());
        }

        private void qLBuoiBaoVe_Click(object sender, EventArgs e)
        {
            openChildForm(new QLBuoiBaoVe());
        }
    }
}
