using QL_DA_KL.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DA_KL
{
    public partial class GuiEmail : Form
    {
        List<uploadFile> fileList = new List<uploadFile>();
        long totalsize = 0;
        GuiEmailBUS bus;
        public GuiEmail()
        {
            InitializeComponent();
        }
        public List<string> getStringPath(List<uploadFile> fileList)
        {
            List<string> filePath = new List<string>();
            for(int i = 0; i < fileList.Count; i++)
            {
                if (fileList[i].getFullPath() != "")
                    filePath.Add(fileList[i].getFullPath());
            }    
            return filePath;
        }
        private void uploadFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            String path = "";
            dlg.Multiselect = false;
            dlg.Filter = "Excel Files|*.xls;*.xlsx|" +
                            "Docfile|*.doc; *.docx|" +
                            "PDF file|*.pdf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                path = dlg.FileName;
                long fileSize = new FileInfo(path).Length;
                if (totalsize > 25000000)
                    MessageBox.Show("Quá tải dung lượng");
                else
                {
                    if (fileSize > 25000000)
                        MessageBox.Show("Quá tải dung lượng");
                    else
                    {
                        uploadFile file = new uploadFile(path);
                        file.TopLevel = false;
                        fileFlowOutPanel.Controls.Add(file);
                        file.Show();
                        totalsize += fileSize;
                        fileList.Add(file);
                    }    
                }    
                
            }
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                colorLbl.BackColor = dlg.Color;
                contenRichTextBox.SelectionColor = dlg.Color;
            }    
        }

        private void contenRichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            //chinh mau va so hien tai
            colorLbl.BackColor = contenRichTextBox.SelectionColor;
            sizeNumeric.Value = (decimal)contenRichTextBox.SelectionFont.Size;

            //chinh nút bold theo hien tai
            if(contenRichTextBox.SelectionFont.Bold == true)
                boldBtn.BackColor = SystemColors.InactiveCaption;
            else
                boldBtn.BackColor = Color.GhostWhite;

            //chinh nút italic theo hien tai
            if (contenRichTextBox.SelectionFont.Italic == true)
                italicBtn.BackColor = SystemColors.InactiveCaption;
            else
                italicBtn.BackColor = Color.GhostWhite;

            ////chinh nút underline theo hien tai
            if (contenRichTextBox.SelectionFont.Underline == true)
                underlineBtn.BackColor = SystemColors.InactiveCaption;
            else
                underlineBtn.BackColor = Color.GhostWhite;

            //chinh nut can trai theo hien tai
            if (contenRichTextBox.SelectionAlignment == HorizontalAlignment.Left)
                leftAlignBtn.BackColor = SystemColors.InactiveCaption;
            else
                leftAlignBtn.BackColor = Color.GhostWhite;


            //chinh nut can giua theo hien tai
            if (contenRichTextBox.SelectionAlignment == HorizontalAlignment.Center)
                centerAlignBtn.BackColor = SystemColors.InactiveCaption;
            else
                centerAlignBtn.BackColor = Color.GhostWhite;

            //chinh nut can phai theo hien tai
            if (contenRichTextBox.SelectionAlignment == HorizontalAlignment.Right)
                rightAlignBtn.BackColor = SystemColors.InactiveCaption;
            else
                rightAlignBtn.BackColor = Color.GhostWhite;

        }

        private void sizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            contenRichTextBox.SelectionFont = new Font(contenRichTextBox.SelectionFont.FontFamily,
                                                (int)sizeNumeric.Value);
        }

        private void boldBtn_Click(object sender, EventArgs e)
        {
            if(contenRichTextBox.SelectionFont.Bold == false)
            {
                boldBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionFont = new Font(contenRichTextBox.SelectionFont.FontFamily,
                                                        (int)sizeNumeric.Value,
                                                        FontStyle.Bold);
            }       
            else
            {
                boldBtn.BackColor = Color.GhostWhite;
                boldBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionFont = new Font(contenRichTextBox.SelectionFont.FontFamily,
                                                        (int)sizeNumeric.Value,
                                                        FontStyle.Regular);
            }    
                
        }

        private void italicBtn_Click(object sender, EventArgs e)
        {
            if (contenRichTextBox.SelectionFont.Italic == false)
            {
                italicBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionFont = new Font(contenRichTextBox.SelectionFont.FontFamily,
                                                        (int)sizeNumeric.Value,
                                                        FontStyle.Italic);
            }
            else
            {
                italicBtn.BackColor = Color.GhostWhite;
                italicBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionFont = new Font(contenRichTextBox.SelectionFont.FontFamily,
                                                        (int)sizeNumeric.Value,
                                                        FontStyle.Regular);
            }
        }

        private void underlineBtn_Click(object sender, EventArgs e)
        {
            if (contenRichTextBox.SelectionFont.Underline == false)
            {
                underlineBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionFont = new Font(contenRichTextBox.SelectionFont.FontFamily,
                                                        (int)sizeNumeric.Value,
                                                        FontStyle.Underline);
            }
            else
            {
                underlineBtn.BackColor = Color.GhostWhite;
                underlineBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionFont = new Font(contenRichTextBox.SelectionFont.FontFamily,
                                                        (int)sizeNumeric.Value,
                                                        FontStyle.Regular);
            }
        }

        private void leftAlignBtn_Click(object sender, EventArgs e)
        {
            contenRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
            if (leftAlignBtn.BackColor == Color.GhostWhite)
                leftAlignBtn.BackColor = SystemColors.InactiveCaption;
            else
                leftAlignBtn.BackColor = Color.GhostWhite;
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            if (contenRichTextBox.SelectionAlignment == HorizontalAlignment.Center)
            {
                leftAlignBtn.BackColor = Color.GhostWhite;
                contenRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
            }      
            else
            {
                leftAlignBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            }    
                
        }

        private void rightAlignBtn_Click(object sender, EventArgs e)
        {
            if (contenRichTextBox.SelectionAlignment == HorizontalAlignment.Right)
            {
                leftAlignBtn.BackColor = Color.GhostWhite;
                contenRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                leftAlignBtn.BackColor = SystemColors.InactiveCaption;
                contenRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            if(contenRichTextBox.SelectionBullet == false)
            {
                contenRichTextBox.SelectionIndent = 30;
                contenRichTextBox.SelectionBullet = true;
                contenRichTextBox.AcceptsTab = true;
                listBtn.BackColor = SystemColors.InactiveCaption;
            }   
            else
            {
                contenRichTextBox.SelectionIndent = 0;
                contenRichTextBox.SelectionBullet = false;
                listBtn.BackColor = Color.GhostWhite;
            }    
            
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string emailAccount = "";
            if (toEmailCbb.Text == "")
                MessageBox.Show("Chưa chọn người gửi");
            else
            {
                if (titleTxt.Text == "")
                    MessageBox.Show("Chưa điền tiêu đề");
                else
                {
                    if (!toEmailCbb.Text.Equals("Nhóm sinh viên (học kì mới nhất)") && !toEmailCbb.Text.Equals("Nhóm giảng viên") && !toEmailCbb.Text.Equals("Tất cả"))
                    {
                        if (!bus.checkApproriateEmail(toEmailCbb.Text))
                        {
                            MessageBox.Show("Email không hợp lệ");
                            return;
                        }       
                        else
                            emailAccount = bus.gennerateEmailfromTextBox(toEmailCbb.Text);
                    }
                    else
                    {
                        string idTG = bus.getIDLatestTG();
                        if(toEmailCbb.Text.Equals("Nhóm sinh viên (học kì mới nhất)"))
                        {
                            DataTable dt = bus.getDSEmailSinhVien(idTG);
                            emailAccount = bus.gennerateEmailFronDT(dt);
                        } 
                        else
                        {
                            if (toEmailCbb.Text.Equals("Nhóm giảng viên"))
                            {
                                DataTable dt = bus.getDSEmailGiangVien();
                                emailAccount = bus.gennerateEmailFronDT(dt);
                            }
                            else
                            {
                                DataTable dtSV = bus.getDSEmailSinhVien(idTG);
                                DataTable dtGV = bus.getDSEmailGiangVien();

                                emailAccount = bus.gennerateEmailFronTwoDT(dtSV, dtGV);
                            }    
                        }    
                    }
                    List<string> list = new List<string>();
                    list = getStringPath(fileList);

                    bus.sendEmail(emailAccount, titleTxt.Text, contenRichTextBox.Rtf, list);
                }

                
            }

            
        }

        private void GuiEmail_Load(object sender, EventArgs e)
        {
            bus = new GuiEmailBUS();
        }

        private void toEmailCbb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
