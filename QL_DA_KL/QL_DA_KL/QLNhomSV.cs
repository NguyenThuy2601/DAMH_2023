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
    public partial class QLNhomSV : Form
    {
        QLNhomSVBUS bus;
        DataTable dt;
        string maGV;
        string selectedNewMaGV;
        int soLuongSVLamKLTN;
        string idTG;
        bool _valueIsSetProgrammatically = false;
        public QLNhomSV()
        {
            InitializeComponent();
        }

        public void setHkCbbData()
        {
            hkCbb.ValueMember = "ID1";
            hkCbb.DisplayMember = "HocKi_NamHoc";
            hkCbb.DataSource = bus.getListTG();
            hkCbb.Text = "";
        }
        public bool checkExistSVInListBox(string mssv)
        {
            for (int i = 0; i < chossenMSSV.Items.Count; i++)
                if (chossenMSSV.Items[i].ToString().Equals(mssv))
                    return true;
            return false;
        }
        public void setGVCbbData()
        {
            gvCBB.ValueMember = "MaGV";
            gvCBB.DisplayMember = "HocViHoTen";
            gvCBB.DataSource = bus.getListGiangVien();
            gvCBB.Text = "";
        }

        public void setNewGVHDCbbData()
        {
            cbbGVHD.ValueMember = "MaGV";
            cbbGVHD.DisplayMember = "HocViHoTen";
            cbbGVHD.DataSource = bus.getListApproriateGiangVien(soLuongSVLamKLTN);
            cbbGVHD.Text = "";
        }

        public int updateSoLuongSVLamKLTN()
        {
            int numberOfRecords = 0;
            for (int i = 0; i < chossenMSSV.Items.Count; i++)
            {
                DataRow[] rows;

                rows = dt.Select(String.Format("MSSV = '{0}'", chossenMSSV.Items[i]));
                if(!rows[0]["Nguyện vọng KLTN"].ToString().Equals("Không đủ điều kiện"))
                    numberOfRecords++;
            }

            return numberOfRecords;
        }
        private void QLNhomSV_Load(object sender, EventArgs e)
        {
            bus = new QLNhomSVBUS();

            setHkCbbData();
            setGVCbbData();

            delSvFromList.Enabled = false;
        }

        private void gvCBB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            maGV = gvCBB.SelectedValue.ToString();
        }

        private void hkCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idTG = hkCbb.SelectedValue.ToString();
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            dt = bus.getNhomSinhVienTheoGiangVien(maGV, idTG);
            dataGridView1.DataSource = dt;

            curentGVHD.Text = gvCBB.Text;

            chossenMSSV.Items.Clear();
            chossenSVName.Items.Clear();
            delSvFromList.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;

            string mssv = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            string hoTen = dataGridView1.CurrentRow.Cells["Họ tên"].Value.ToString();

            if(!checkExistSVInListBox(mssv))
            {
                chossenMSSV.Items.Add(mssv);
                chossenSVName.Items.Add(hoTen);
                delSvFromList.Enabled = true;

                if (!dataGridView1.CurrentRow.Cells["Nguyện vọng KLTN"].Value.ToString().Equals("Không đủ điều kiện"))
                    soLuongSVLamKLTN++;
                setNewGVHDCbbData();
            }    
            
        }

        private void chossenMSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            _valueIsSetProgrammatically = true;
            chossenSVName.SelectedIndex = chossenMSSV.SelectedIndex;

        }

        private void chossenSVName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_valueIsSetProgrammatically == false)
                chossenSVName.SelectedItems.Clear();
            else
                _valueIsSetProgrammatically = false;
        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            int selectedIndex = chossenMSSV.SelectedIndex;
            if(selectedIndex == -1)
            {
                chossenMSSV.Items.RemoveAt(0);
                chossenSVName.Items.RemoveAt(0);
            }   
            else
            {
                chossenMSSV.Items.RemoveAt(selectedIndex);
                chossenSVName.Items.RemoveAt(selectedIndex);
            }    
            if(chossenSVName.Items.Count == 0)
                delSvFromList.Enabled = false;
            else
            {
                soLuongSVLamKLTN = updateSoLuongSVLamKLTN();
                setNewGVHDCbbData();
            }    
        }

        private void cbbGVHD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            curentGVHD.Text = cbbGVHD.Text;
            selectedNewMaGV = cbbGVHD.SelectedItem.ToString();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string hocViNewGVHD = bus.getHocVi(selectedNewMaGV);
            int soLuongKLTNNewGVHD = bus.countSoLuongKLTNCuaGV(selectedNewMaGV, idTG);
            if (bus.checkSLKLTNCuaGV(hocViNewGVHD, soLuongKLTNNewGVHD) == false)
            {
                DialogResult result = MessageBox.Show("Giảng viên đã hết đề tài cho KLTN theo quy định, Bạn có muốn tiếp tục", "Warning", MessageBoxButtons.YesNo);
                if(result == DialogResult.No)
                {
                    return;
                    
                }
                List<String> listMSSV = chossenMSSV.Items.Cast<String>().ToList();
                if (bus.updateGVHD(selectedNewMaGV, listMSSV) == 0)
                {
                    curentGVHD.Text = gvCBB.Text;
                    MessageBox.Show("Cập nhật thất bại");
                    chossenMSSV.Items.Clear();
                    chossenSVName.Items.Clear();
                }    
                    
                else
                    MessageBox.Show("Thành công");
            }
            
        }
    }
}
