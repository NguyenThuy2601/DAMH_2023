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
    public partial class uploadFile : Form
    {
        string fullPath;
        public uploadFile()
        {
            InitializeComponent();
        }

        public uploadFile(string fileName) :this()
        {
            string[] name = fileName.Split('\\');
            fullPath = fileName;
            fileName = name[name.Length - 1];
            fileNamelbl.Text = fileName;
        }

        public string getFullPath()
        {
            return fullPath;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            fullPath = "";
            this.Close();
        }

        private void uploadFile_Load(object sender, EventArgs e)
        {

        }
    }
}
