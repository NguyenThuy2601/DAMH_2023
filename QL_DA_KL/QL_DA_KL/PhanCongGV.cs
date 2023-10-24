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
    public partial class PhanCongGV : Form
    {
        TrangChu trangChu;
        PhanCongGVBUS bus;
        ThoiGian tg;
        public PhanCongGV()
        {
            InitializeComponent();
        }

        public PhanCongGV(TrangChu form) :this()
        {
            trangChu = form;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void upFileBtn_Click(object sender, EventArgs e)
        {
            trangChu.openChildForm(new DocDSSVLamDAMH());
        }

        private void PhanCongGV_Load(object sender, EventArgs e)
        {
            bus = new PhanCongGVBUS();

            tg = bus.tranferToTGObject();
            hkLbl.Text = tg.HocKi_NamHoc;
        }

        private void phanCongBtn_Click(object sender, EventArgs e)
        {
            //bus.deletedThisHkExistDAMH(tg);
            if (bus.phanCongGVChoSVLamKLTN(tg) > 0 && bus.PhanCongChoSVLamDAMH(tg) > 0)
            {
                MessageBox.Show("Thành công");
                resultDgv.DataSource = bus.loadUpdatedSinhVien(tg);
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

       

        private void resultDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            resultDgv.CurrentRow.Selected = true;
            mssvLbl.Text = resultDgv.CurrentRow.Cells["MSSV"].Value.ToString();
            hoTenLbl.Text = resultDgv.CurrentRow.Cells["Họ Tên"].Value.ToString();        
            gpaLbl.Text = resultDgv.CurrentRow.Cells["Nguyện vọng KLTN"].Value.ToString();

            if(resultDgv.CurrentRow.Cells["Nguyện vọng KLTN"].Value.ToString().Equals("Không đủ điều kiện"))
                nvKLTNlbl.Text= "Không đủ điều kiện";
            else
                nvKLTNlbl.Text = "Có";

            if (resultDgv.CurrentRow.Cells["Số lượng thành viên"].Value.ToString() == " ")
                slLbl.Text = "1";
            else
                slLbl.Text = "2";

            nganhLbl.Text = resultDgv.CurrentRow.Cells["Nganh"].Value.ToString();
            chuuyenNganhLbl.Text = resultDgv.CurrentRow.Cells["ChuyenNganh"].Value.ToString();
            gvhdCbb.Text = resultDgv.CurrentRow.Cells["Giảng viên hướng dẫn"].Value.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
