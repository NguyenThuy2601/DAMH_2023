using QL_DA_KL.BUS;
using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DA_KL
{

    public partial class QuanLyHoiDong : Form
    {
        string gio;
        string buoiTrongNgay;
        string ngayToChuc;
        string thu;
        int idLatestInputHK;
        QuanLyHoiDongBUS bus;
        DataTable tvHoiDongDt;
        public QuanLyHoiDong()
        {
            InitializeComponent();
        }

        public void disableMemberChoice()
        {
            chuTichCbb.Enabled = false;
            thuKiCbb.Enabled = false;
            tvCbb.Enabled = false;

            listView1.Enabled = false;
        }

        public void enableMemberChoice()
        {
            chuTichCbb.Enabled = true;
            thuKiCbb.Enabled = true;
            tvCbb.Enabled = true;

            listView1.Enabled = true;
        }

        private void ngayDtp_ValueChanged(object sender, EventArgs e)
        {
            thu = bus.formatThuTrongTuan(ngayDtp.Value.DayOfWeek.ToString());
            ngayToChuc = ngayDtp.Value.ToString("MM/dd/yyyy");
            disableMemberChoice();
        }

        public void setHocKiCbb()
        {
            hkCbb.ValueMember = "ID";
            hkCbb.DisplayMember = "HocKi";
            hkCbb.DataSource = bus.getAllhocKiInHoiDong();
            hkCbb.SelectedIndex = -1;
        }

        private void QuanLyHoiDong_Load(object sender, EventArgs e)
        {
            updateBtn.Enabled = false;
            xoaBtn.Enabled = false;
            thu = ngayDtp.Value.DayOfWeek.ToString();
            listView1.MultiSelect = false;
            idLbl.Text = "";

            bus = new QuanLyHoiDongBUS();

            tgCbb.Enabled = false;

            string latestIDTGInHoiDong = bus.getLatestHocKiInHoiDongID();
            hoiDongDgv.DataSource = bus.getHoiDong(latestIDTGInHoiDong);

            idLatestInputHK = bus.getLastInputSem();

            setHocKiCbb();

            
        }

        

        private void QuanLyHoiDong_Activated(object sender, EventArgs e)
        {
            //MessageBox.Show("test");
        }

        private void QuanLyHoiDong_Shown(object sender, EventArgs e)
        {

        }

        public void setCbbData(DataTable dt, ComboBox cbb, string selectedValue)
        {
            cbb.DisplayMember = "HoTen";
            cbb.ValueMember = "MaGV";
            cbb.DataSource = dt;
            if (selectedValue == null)
                cbb.SelectedValue = "";
            else
                cbb.SelectedValue = selectedValue;
        }

        public void restartCbb()
        {
            thuKiCbb.Text = "";
            thuKiCbb.SelectedValue = "";

            chuTichCbb.Text = "";
            chuTichCbb.SelectedValue = "";

            tvCbb.SelectedValue = "";
            tvCbb.Text = "";
            listView1.Items.Clear();
        }

        public void getFindHocKiCbbData()
        {
            hkCbb.ValueMember = "ID";
            hkCbb.DisplayMember = "HocKi";
            hkCbb.DataSource = bus.getAllhocKiInHoiDong();

            hkCbb.SelectedIndex = -1;
        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("Chưa chọn thời gian");
            else
            {
                enableMemberChoice();
                restartCbb();

                tgBatDau.Text = ngayDtp.Value.ToString("dd/M/yyyy").Split(' ')[0] + " " + gio;


                
                setCbbData(bus.getApproriateTienSi(thu, buoiTrongNgay, ngayToChuc, gio, "", null, idLbl.Text), chuTichCbb, idLbl.Text);
                setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, "", "", idLbl.Text), thuKiCbb, idLbl.Text);
                setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, "", "", idLbl.Text), tvCbb, idLbl.Text);
            } 
                
            
            
        }

        private void chuTichCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {

            List<string> listMaGV = listView1.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList(); 
            setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, chuTichCbb.SelectedValue.ToString(), listMaGV, idLbl.Text), thuKiCbb, formatSelectedItem(thuKiCbb.SelectedValue));
            setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, chuTichCbb.SelectedValue.ToString(), formatSelectedItem(thuKiCbb.SelectedValue), idLbl.Text), tvCbb, formatSelectedItem(tvCbb.SelectedValue));
        }

        public string formatSelectedItem(object control)
        {
            if(control == null)
                return null;
            return control.ToString();
        }



        public bool checkExistGV(ListView listView, string maGV)
        {
            for(int i = 0; i < listView.Items.Count; i++)
            {
                if (listView.Items[i].Text.Equals(maGV))
                    return true;
            }    
            return false;
        }

        private void tvCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 3)
            {
                MessageBox.Show("Đã quá số lượng thành viên");
                return;
            }    
               
            if(!checkExistGV(listView1, tvCbb.SelectedValue.ToString()))
            {

                string tenGV = bus.getHocViHoTen(tvCbb.SelectedValue.ToString());

                GiangVien gv = new GiangVien(tvCbb.SelectedValue.ToString(), tenGV);

                ListViewItem item1 = new ListViewItem();
                item1.Text = gv.MaGV;
                item1.SubItems.Add(gv.HoTen);
                listView1.Items.Add(item1);

                List<string> listMaGV = listView1.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList(); ;

                setCbbData(bus.getApproriateTienSi(thu, buoiTrongNgay, ngayToChuc, gio, formatSelectedItem(thuKiCbb.SelectedValue), listMaGV, idLbl.Text), chuTichCbb, formatSelectedItem(chuTichCbb.SelectedValue));
                setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, formatSelectedItem(tvCbb.SelectedValue), formatSelectedItem(chuTichCbb.SelectedValue), idLbl.Text), thuKiCbb, formatSelectedItem(thuKiCbb.SelectedValue));
            }    
                
        }


        private void thuKiCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {

            List<string> listMaGV = listView1.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
            setCbbData(bus.getApproriateTienSi(thu, buoiTrongNgay, ngayToChuc, gio, formatSelectedItem(thuKiCbb.SelectedValue), listMaGV, idLbl.Text), chuTichCbb, formatSelectedItem(chuTichCbb.SelectedValue));
            setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, chuTichCbb.SelectedValue.ToString(), formatSelectedItem(thuKiCbb.SelectedValue), idLbl.Text), tvCbb, formatSelectedItem(tvCbb.SelectedValue));
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count > 0)
            {
                List<string> listMaGV = listView1.Items.Cast<ListViewItem>()
                                     .Select(item => item.Text)
                                     .ToList();
                if (listView1.SelectedItems.Count == 0)
                {
                    listView1.Items.RemoveAt(listView1.Items.Count - 1);

                    setCbbData(bus.getApproriateTienSi(thu, buoiTrongNgay, ngayToChuc, gio, formatSelectedItem(thuKiCbb.SelectedValue), listMaGV, idLbl.Text), chuTichCbb, formatSelectedItem(chuTichCbb.SelectedValue));
                    setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, formatSelectedItem(tvCbb.SelectedValue), formatSelectedItem(chuTichCbb.SelectedValue), idLbl.Text), thuKiCbb, formatSelectedItem(thuKiCbb.SelectedValue));
                }    
                    


                else
                {
                    listView1.Items.RemoveAt(listView1.Items.IndexOf(listView1.SelectedItems[0]));
                    listView1.SelectedItems.Clear();

                    setCbbData(bus.getApproriateTienSi(thu, buoiTrongNgay, ngayToChuc, gio, formatSelectedItem(thuKiCbb.SelectedValue), listMaGV, idLbl.Text), chuTichCbb, formatSelectedItem(chuTichCbb.SelectedValue));
                    setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, formatSelectedItem(tvCbb.SelectedValue), formatSelectedItem(chuTichCbb.SelectedValue), idLbl.Text), thuKiCbb, formatSelectedItem(thuKiCbb.SelectedValue));
                }    
            }
           
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(chuTichCbb.SelectedValue == null || thuKiCbb.SelectedValue == null || listView1.Items.Count == 0 || cbbHocKi.Text == "" || namBDTxt.Text == "" || NamKTTxt.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                if(!bus.checkApproriateSchoolYear(namBDTxt.Text, NamKTTxt.Text))
                {
                    MessageBox.Show("Năm học không hợp lệ");
                    return;
                }    
                ThoiGian tg = new ThoiGian(cbbHocKi.Text, namBDTxt.Text, NamKTTxt.Text);
                int idHK = bus.getHocKiNamHoc(tg);
                if(idHK == 0)
                {
                    if(bus.insertHocKiNamHoc(tg) == 0)
                    {
                        MessageBox.Show("Xảy ra lỗi");
                        return;
                    }    
                    else
                    {
                        idHK = bus.getHocKiNamHoc(tg);
                    }    
                }
                if(idHK < idLatestInputHK)
                {
                    MessageBox.Show("Năm học đã qua không thể tạo thêm hội đồng");
                    return;
                } 
                if(ngayDtp.Value <= DateTime.Now)
                {
                    MessageBox.Show("Không thể tạo thêm hội đồng cho thời gian này");
                    return ;
                }
                HoiDong hd = new HoiDong(ngayDtp.Value.ToString(), gio, idHK);
                if(bus.insertHoiDong(hd) == 0)
                {
                    MessageBox.Show("Xảy ra lỗi");
                }    
                else
                {
                    string idHoiDong = bus.getInputHoiDong();
                    ThanhVien chuTich = new ThanhVien(chuTichCbb.SelectedValue.ToString(), idHoiDong, "CT");
                    ThanhVien thuKi = new ThanhVien(thuKiCbb.SelectedValue.ToString(), idHoiDong, "TK");
                    List<string> listMaGV = listView1.Items.Cast<ListViewItem>()
                                     .Select(item => item.Text)
                                     .ToList();
                    List<ThanhVien> listTV = bus.tranferToListThanhVien(listMaGV, idHoiDong);
                    if(bus.createThanhVienForHoiDong(chuTich, thuKi, listTV) == 0)
                    {
                        MessageBox.Show("Xảy ra lỗi");
                    }    
                    else
                    {
                        MessageBox.Show("Thành công");
                        hoiDongDgv.DataSource = bus.getHoiDong(idHK.ToString());

                        cbbHocKi.SelectedIndex = -1;
                        namBDTxt.Text = "";
                        NamKTTxt.Text = "";
                        tgBatDau.Text = "";

                        tvHoiDongDgv.DataSource = "";

                        restartCbb();
                        disableMemberChoice();
                    }    
                }    
            }    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                gio = "7:00";
                buoiTrongNgay = "S";
            }    
                
            else
            {
                gio = "13:00";
                buoiTrongNgay = "C";
            }    
                

            disableMemberChoice();
        }

        public int formatedBuoiBatDauSbbSelectedIndex(string time)
        {
            string hour = time.Split(':')[0];
            if (int.Parse(hour) == 7)
                return 0;
            else
                return 1;
        }

        public void tranferDtToListView(DataTable dt)
        {
            foreach(DataRow dr in dt.Rows)
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = dr["MaGV"].ToString();
                item1.SubItems.Add(dr["GiangVien"].ToString());
                listView1.Items.Add(item1);
            }    
        }

        private void hoiDongDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            hoiDongDgv.CurrentRow.Selected = true;
            idLbl.Text = hoiDongDgv.CurrentRow.Cells["ID"].Value.ToString();
            tvHoiDongDt = bus.getHoiDongDetail(idLbl.Text);
            tvHoiDongDgv.DataSource = tvHoiDongDt;
            tgBatDau.Text = hoiDongDgv.CurrentRow.Cells["ThoiGian"].Value.ToString();
            

            string hocki_namhoc = hoiDongDgv.CurrentRow.Cells["HocKiNamHoc"].Value.ToString();
            string ngayVaTG = tgBatDau.Text.Split(' ')[0];
            DateTime ngayBD = DateTime.ParseExact(ngayVaTG, "dd/MM/yyyy", new CultureInfo("en-CA"));

            if (int.Parse(hocki_namhoc.Split(' ')[0]) == 1)
                cbbHocKi.SelectedIndex = 0;
            else
            {
                if (int.Parse(hocki_namhoc.Split(' ')[0]) == 2)
                    cbbHocKi.SelectedIndex = 1;
                else
                    cbbHocKi.SelectedIndex = 2;
            }

            string []namHoc = hocki_namhoc.Split(' ')[1].Split('-');
            namBDTxt.Text = namHoc[0];
            NamKTTxt.Text = namHoc[1];

            ThoiGian tg = new ThoiGian(cbbHocKi.Text, namBDTxt.Text, NamKTTxt.Text);
            int idHK = bus.getHocKiNamHoc(tg);

            if(idHK < idLatestInputHK || ngayBD <= DateTime.Now)
            {
                addBtn.Enabled = false;
                updateBtn.Enabled = false;
                xoaBtn.Enabled = false;

                ngayDtp.Enabled = false;
                comboBox1.Enabled = false;
                confirmBtn.Enabled = false;
            }    
            else
            {
                addBtn.Enabled = false;
                updateBtn.Enabled = true;
                xoaBtn.Enabled = true;

                ngayDtp.Enabled = true;
                comboBox1.Enabled = true;
                confirmBtn.Enabled = true;
            }

            listView1.Items.Clear();
            DataTable tvInfo = bus.getThanhVienInfo(idLbl.Text);
            tranferDtToListView(tvInfo);

            List<string> listMaGV = listView1.Items.Cast<ListViewItem>()
                                     .Select(item => item.Text)
                                     .ToList();

            buoiBaoVe.DataSource = bus.getbuoiBaove(idLbl.Text);
            string maGVChuTich = bus.getMaGvByHoTen(chuTichCbb.Text);
            string maGVThuKi = bus.getMaGvByHoTen(thuKiCbb.Text);



            cbbHocKi.Enabled = false;
            namBDTxt.Enabled = false;
            NamKTTxt.Enabled = false;
            enableMemberChoice();

            thu = bus.formatThuTrongTuan(ngayBD.DayOfWeek.ToString());
            buoiTrongNgay = bus.getBuoiTrongngay(tgBatDau.Text.Split(' ')[1]);
            ngayToChuc = ngayBD.ToString("MM/dd/yyyy");
            gio = tgBatDau.Text.Split(' ')[1];

            setCbbData(bus.getApproriateTienSi(thu, buoiTrongNgay, ngayToChuc, gio, maGVThuKi, listMaGV, idLbl.Text), chuTichCbb, idLbl.Text);
            setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, maGVThuKi, listMaGV, idLbl.Text), thuKiCbb, idLbl.Text);
            setCbbData(bus.getApproriateGV(thu, buoiTrongNgay, ngayToChuc, gio, maGVChuTich, maGVThuKi, idLbl.Text), tvCbb, idLbl.Text);

            chuTichCbb.Text = hoiDongDgv.CurrentRow.Cells["ChuTich"].Value.ToString();
            thuKiCbb.Text = bus.getThuKiInfo(idLbl.Text);
        }



        private void buttonCustom3_Click(object sender, EventArgs e)
        {
            restartCbb();

            idLbl.Text = "";

            ngayDtp.Enabled = true;
            comboBox1.Enabled = true;
            confirmBtn.Enabled = true;

            string latestIDTGInHoiDong = bus.getLatestHocKiInHoiDongID();
            hoiDongDgv.DataSource = bus.getHoiDong(latestIDTGInHoiDong);

            cbbHocKi.SelectedIndex = -1;
            namBDTxt.Text = "";
            NamKTTxt.Text = "";

            tgBatDau.Text = "";

            tvHoiDongDgv.DataSource = "";
            buoiBaoVe.DataSource = "";

            ngayDtp.Enabled = true;
            comboBox1.Enabled = true;
            confirmBtn.Enabled = true;

            addBtn.Enabled = true;
            updateBtn.Enabled = false;
            xoaBtn.Enabled = false;

            cbbHocKi.Enabled = true;
            namBDTxt.Enabled = true;
            NamKTTxt.Enabled = true;
        }

        private void cbbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbbHocKi.SelectedIndex.ToString());
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(idLbl.Text == "")
            {
                MessageBox.Show("Chưa chọn hội đồng cần chỉnh sửa");
                return;
            }    
            if (chuTichCbb.Text == "" || thuKiCbb.Text == "" || listView1.Items.Count == 0 || cbbHocKi.Text == "" || namBDTxt.Text == "" || NamKTTxt.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                string []date = tgBatDau.Text.Split(' ')[0].Split('/');
                string formattedDate = date[1] + "/" + date[0] + "/" + date[2];
                string time = tgBatDau.Text.Split(' ')[1];

                string ngayBD = tgBatDau.Text.Split(' ')[0];
                if (DateTime.Parse(formattedDate).Date <= DateTime.Now.Date)
                {
                    MessageBox.Show("Thời gian bắt đầu ít nhất phải là ngày mai");
                    return;
                }    

                HoiDong hd = new HoiDong(idLbl.Text, formattedDate + " " + time);
                if(bus.updateHoiDong(hd) == 0)
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }    
                else
                {
                    string maGVChuTich = bus.getMaGvByHoTen(chuTichCbb.Text.Split('.')[1].Trim());
                    string maThuKi = bus.getMaGvByHoTen(thuKiCbb.Text.Split('.')[1].Trim());

                    ThanhVien chuTich = new ThanhVien(maGVChuTich, idLbl.Text, "CT");
                    ThanhVien thuKi = new ThanhVien(maThuKi.ToString(), idLbl.Text, "TK");
                    List<string> listMaGV = listView1.Items.Cast<ListViewItem>()
                                     .Select(item => item.Text)
                                     .ToList();
                    List<ThanhVien> listTV = bus.tranferToListThanhVien(listMaGV, idLbl.Text);
                    bus.deleteTVinHoiDong(idLbl.Text);
                    if(bus.createThanhVienForHoiDong(chuTich, thuKi, listTV) == 0)
                    {
                        MessageBox.Show("Đã xảy ra lỗi");
                    }    
                    else
                    {

                        string idHoiDong = bus.getHocKiNamHoc(new ThoiGian(cbbHocKi.Text, namBDTxt.Text, NamKTTxt.Text)).ToString();
                        MessageBox.Show("Thành công");

                        cbbHocKi.SelectedIndex = -1;
                        namBDTxt.Text = "";
                        NamKTTxt.Text = "";
                        idLbl.Text = "";
                        tgBatDau.Text = "";

                        hoiDongDgv.DataSource = bus.getHoiDong(idHoiDong);
                        buoiBaoVe.DataSource = "";
                        tvHoiDongDgv.DataSource = "";

                        restartCbb();
                        disableMemberChoice();
                    }    
                }    
                
            }    

        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            if (idLbl.Text == "")
                MessageBox.Show("Chưa chọn hội đồng để xóa");
            else
            {
                string idHoiDong = bus.getHocKiNamHoc(new ThoiGian(cbbHocKi.Text, namBDTxt.Text, NamKTTxt.Text)).ToString();
                var result = MessageBox.Show("Bạn có muốn xóa hội đồng này ?", "Thông báo", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    if (bus.deleteTVinHoiDong(idLbl.Text) > 0 && bus.deleteHoiDong(idLbl.Text) > 0)
                    {
                        MessageBox.Show("Xóa hội đồng thành công");

                        cbbHocKi.SelectedIndex = -1;
                        namBDTxt.Text = "";
                        NamKTTxt.Text = "";
                        tgBatDau.Text = "";
                        idLbl.Text = "";

                        hoiDongDgv.DataSource = bus.getHoiDong(idHoiDong);
                        buoiBaoVe.DataSource = "";
                        tvHoiDongDgv.DataSource = "";

                        restartCbb();
                        disableMemberChoice();
                    }    
                        
                }   
                else
                {
                    return;
                }    
            }    
        }

        private void hkCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tgCbb.ValueMember = "TGBatDau";
            tgCbb.DisplayMember = "FormatedTgBD";
            tgCbb.DataSource = bus.getTGToChucInHocKi(hkCbb.SelectedValue.ToString());
            tgCbb.SelectedIndex = -1;

            tgCbb.Enabled = true;
        }

        private void taiFileBtn_Click(object sender, EventArgs e)
        {
            string id = hkCbb.SelectedValue.ToString();
            if(tgCbb.Text != "")
            {
                string ngayGio = tgCbb.SelectedValue.ToString();
                hoiDongDgv.DataSource = bus.getHoiDongBYHocKiAndTG(id, ngayGio);

            }
            else
            {
                hoiDongDgv.DataSource = bus.getHoiDong(id);
            }

            tvHoiDongDgv.DataSource = null;
            buoiBaoVe.DataSource = null;

        }
    }
}
