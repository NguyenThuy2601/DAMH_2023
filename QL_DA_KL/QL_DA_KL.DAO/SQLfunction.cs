using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DA_KL.DAO
{
    public class SQLfunction
    {
        public SqlConnection Con = null;

        public int Connect()
        {
            if (Con == null)
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Data Source=DESKTOP-4CBR9B5;Initial Catalog=QLDAMH;Integrated Security=True";
                Con.Open();
                if (Con.State == ConnectionState.Open)
                    return 1;
                else
                    return 0;
            }
            return 1;

        }
        public int Disconnect()
        {
            if (Con != null)
            {
                Con.Close();
                Con.Dispose();
                Con = null;
                return 0;
            }
            return 0;

        }

        public DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Con;
            dap.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        public int RunNonQuery(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                return cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }

        public string RunQuery(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {

                if (cmd.ExecuteScalar() != null)
                    return cmd.ExecuteScalar().ToString(); //Thực hiện câu lệnh SQL
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
            return null;
        }
    }
}
