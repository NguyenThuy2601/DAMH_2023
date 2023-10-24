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
    public partial class QLBuoiBaoVe : Form
    {
        QLBuoiBaoVeBUS bus;
        ThoiGian latestTGInHoiDong;
        DataTable dtSVChuaXepLich;
        DataTable chosenSVDT;
        string ngay;
        string buoiTrongNgay;
        string gio;
        string thu;
        public QLBuoiBaoVe()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ResetCreateInfoCbb()
        {
            idHoiDongLblTab2Lbl.Text = "";
            gvpbCBBTab2.Enabled = false;
            idHoiDongLblTab2Lbl.Text = "";
        }
        private void QLBuoiBaoVe_Load(object sender, EventArgs e)
        {
            ResetCreateInfoCbb();
            bus = new QLBuoiBaoVeBUS();

            ngay = ngayToChucTab2Dtp.Value.ToString("MM/dd/yyyy");
            thu = bus.formatThuTrongTuan(ngayToChucTab2Dtp.Value.DayOfWeek.ToString());

            
            latestTGInHoiDong = bus.getLatestIDInHoiDong();
            hkTab2lbl.Text = latestTGInHoiDong.HocKi_NamHoc;
            int idLatestHKInDB = bus.getLatestInPutHocKi();
            if(latestTGInHoiDong.ID1 < idLatestHKInDB)
            {
                ngayToChucTab2Dtp.Enabled = false;
                BuoiToChucTab2DTP.Enabled = false;
                confirmBtnTab2.Enabled = false;
            }
            dtSVChuaXepLich = bus.getSVChuaXepLich();
            svChuaCoLichTab2Lbl.DataSource = dtSVChuaXepLich;
            hoidDongTab2Dgv.DataSource = bus.getAvailableHoiDong();
            chosenSVDT = dtSVChuaXepLich.Clone();
        }

        private void tvHoidDongDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tvHoidDongDgv.CurrentRow.Selected = true;

            idHoiDongLblTab2Lbl.Text = tvHoidDongDgv.CurrentRow.Cells["ID"].Value.ToString();
            tvHoidDongDgv.DataSource = bus.getThanhVienInfo(idHoiDongLblTab2Lbl.Text);
        }

        public void deleteSVINSVChuaCoLich(DataRow[] rows)
        {
            foreach (DataRow row in rows)
            {
                dtSVChuaXepLich.Rows[dtSVChuaXepLich.Rows.IndexOf(row)].Delete();
            }
        }

        private void svChuaCoLichTab2Lbl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            svChuaCoLichTab2Lbl.CurrentRow.Selected = true;

            string selectedMSSV = svChuaCoLichTab2Lbl.CurrentRow.Cells["MSSV"].Value.ToString();

            DataRow[] rowsInSelectedSV = chosenSVDT.Select(string.Format("MSSV = '{0}'", selectedMSSV));
            if (rowsInSelectedSV.Length > 0)
                return;
            DataRow[] rowsInSVChuaXepLich = dtSVChuaXepLich.Select(string.Format("MSSV = '{0}'", selectedMSSV));
            if(rowsInSVChuaXepLich.Length > 0)
            {
                chosenSVDT.ImportRow(rowsInSVChuaXepLich[0]);
                deleteSVINSVChuaCoLich(rowsInSVChuaXepLich);
                svTab2Gdv.DataSource = chosenSVDT;
            }    
            
        }

        private void hoidDongTab2Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            hoidDongTab2Dgv.CurrentRow.Selected = true;

            idHoiDongLblTab2Lbl.Text = hoidDongTab2Dgv.CurrentRow.Cells["ID"].Value.ToString();

            tvHoidDongDgv.DataSource = bus.getThanhVienInfo(idHoiDongLblTab2Lbl.Text);
        }

        private void ngayToChucTab2Dtp_ValueChanged(object sender, EventArgs e)
        {
            ngay = ngayToChucTab2Dtp.Value.ToString("MM/dd/yyyy");
            thu = bus.formatThuTrongTuan(ngayToChucTab2Dtp.Value.DayOfWeek.ToString());

            gvpbCBBTab2.Enabled = false;
        }

        private void BuoiToChucTab2DTP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (BuoiToChucTab2DTP.SelectedIndex == 0)
            {
                gio = "7:00";
                buoiTrongNgay = "S";
            }

            else
            {
                gio = "13:00";
                buoiTrongNgay = "C";
            }

            gvpbCBBTab2.Enabled = false;
        }

        public void setDataForGVPBCbb(ComboBox cbb, DataTable dt)
        {
            cbb.DisplayMember = "GV";
            cbb.ValueMember = "MaGV";
            cbb.DataSource = dt;
        }    

        private void confirmBtnTab2_Click(object sender, EventArgs e)
        {
            if (BuoiToChucTab2DTP.Text == "")
                MessageBox.Show("Chưa nhập đủ thông tin");
            else
            {
                if (ngayToChucTab2Dtp.Value <= DateTime.Now)
                    MessageBox.Show("Ngày tổ chức không hợp lệ");
                else
                {
                    DataTable dt = bus.getAvailableGV(ngay, gio, buoiTrongNgay, thu);
                    setDataForGVPBCbb(gvpbCBBTab2, dt);
                    gvpbCBBTab2.Enabled = true;
                }    
            }    
        }
    }
}
