using QL_DA_KL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace QL_DA_KL.BUS
{
    public class GuiEmailBUS : ModelBus
    {
        public GuiEmailBUS() 
        {
            load();
        }

        public string getIDLatestTG()
        {
            string sql = "select ID from ThoiGian order by ID desc";
            return sQLfunction.RunQuery(sql);
        }

        public DataTable getDSEmailSinhVien(string idTG)
        {
            string sql = String.Format("select sv.EmailOU as Email " +
                "from SinhVien sv " +
                "where sv.MSSV not in (select MSSV from SV_DAMH) " +
                "or(sv.LamLaiDoAn = 1 and sv.NamLamLaiDoAn = YEAR(GETDATE())) " +
                "or sv.MSSV in (select MSSV from SV_DAMH, DoAn where ID_DA = ID and ID_ThoiGianToChuc = {0})", idTG);
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getDSEmailGiangVien()
        {
            string sql = "select Email from GiangVien";
            return sQLfunction.GetDataToTable(sql);
        }

        public bool checkApproriateEmail(string email)
        {
            string[] temp = email.Split(' ', ',', ';', '\t');
            for(int i = 0; i < temp.Length; i++)
                if (temp[i] != "")
                    if (!temp[i].Contains("@"))
                        return false;
            return true;
        }

        public string gennerateEmailfromTextBox(String email)
        {
            string[] temp = email.Split(' ', ',', ';', '\t');
            StringBuilder listEmail = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Trim() == " ")
                    continue;
                listEmail.Append(temp[i].Trim());
                if (i != 0 && i != temp.Length - 1)
                    listEmail.Append("; ");  
            }
            return listEmail.ToString();    
        }

        public string gennerateEmailFronDT(DataTable dt)
        {
            StringBuilder listEmail = new StringBuilder();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                listEmail.Append(dr["Email"].ToString().Trim());
                if (i != dt.Rows.Count - 1)
                    listEmail.Append("; ");
            }
            return listEmail.ToString();
        }

        public string gennerateEmailFronTwoDT(DataTable dt1, DataTable dt2)
        {
            StringBuilder listEmail = new StringBuilder();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt1.Rows[i];
                listEmail.Append(dr["Email"].ToString().Trim());
                if (i != 0 && i != dt1.Rows.Count - 1)
                    listEmail.Append("; ");
            }
            listEmail.Append("; ");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow dr = dt2.Rows[i];
                listEmail.Append(dr["Email"].ToString().Trim());
                if (i != 0 && i != dt2.Rows.Count - 1)
                    listEmail.Append("; ");
            }
            return listEmail.ToString();
        }

        public void addMailAttachment(List<String> filePath,ref MailMessage mail)
        {
            for(int i = 0; i < filePath.Count; i++)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filePath[i]);
                mail.Attachments.Add(attachment);
            }    
        }
        
        public void sendEmail(string email, string tittle, string content, List<String> filePath)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("2051052135thuy@ou.edu.vn");
            mail.To.Add(email);
            mail.Subject = tittle;
            var html = RtfPipe.Rtf.ToHtml(content);
            string formatedHTML = html.ToString();
            mail.IsBodyHtml = true;
            mail.Body = formatedHTML;

            if(filePath.Count > 0)
                addMailAttachment(filePath, ref mail);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("2051052135thuy@ou.edu.vn", "seojuhyun286");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
