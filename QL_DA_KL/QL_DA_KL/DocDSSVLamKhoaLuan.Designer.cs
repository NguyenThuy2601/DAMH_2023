namespace QL_DA_KL
{
    partial class DocDSSVLamKhoaLuan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.namKTTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.namBDTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hocKiCbb = new System.Windows.Forms.ComboBox();
            this.uploadFileBtn = new QL_DA_KL.buttonCustom();
            this.label2 = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.upFileBtn = new QL_DA_KL.buttonCustom();
            this.fileDetailDgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultDgv = new System.Windows.Forms.DataGridView();
            this.numOfRowInData = new System.Windows.Forms.Label();
            this.rowInDataBaseLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileDetailDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.namKTTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.namBDTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.hocKiCbb);
            this.groupBox1.Controls.Add(this.uploadFileBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameLbl);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // namKTTxt
            // 
            this.namKTTxt.Location = new System.Drawing.Point(234, 94);
            this.namKTTxt.Name = "namKTTxt";
            this.namKTTxt.Size = new System.Drawing.Size(120, 27);
            this.namKTTxt.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "-";
            // 
            // namBDTxt
            // 
            this.namBDTxt.Location = new System.Drawing.Point(93, 90);
            this.namBDTxt.Name = "namBDTxt";
            this.namBDTxt.Size = new System.Drawing.Size(100, 27);
            this.namBDTxt.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Năm học:";
            // 
            // hocKiCbb
            // 
            this.hocKiCbb.FormattingEnabled = true;
            this.hocKiCbb.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.hocKiCbb.Location = new System.Drawing.Point(74, 33);
            this.hocKiCbb.Name = "hocKiCbb";
            this.hocKiCbb.Size = new System.Drawing.Size(121, 28);
            this.hocKiCbb.TabIndex = 15;
            // 
            // uploadFileBtn
            // 
            this.uploadFileBtn.BackColor = System.Drawing.Color.Navy;
            this.uploadFileBtn.BackgroundColor = System.Drawing.Color.Navy;
            this.uploadFileBtn.BorderColor = System.Drawing.Color.Navy;
            this.uploadFileBtn.BorderRadius = 40;
            this.uploadFileBtn.BorderSize = 2;
            this.uploadFileBtn.FlatAppearance.BorderSize = 0;
            this.uploadFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadFileBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.uploadFileBtn.Location = new System.Drawing.Point(6, 149);
            this.uploadFileBtn.Name = "uploadFileBtn";
            this.uploadFileBtn.Size = new System.Drawing.Size(98, 42);
            this.uploadFileBtn.TabIndex = 14;
            this.uploadFileBtn.Text = "Tải file";
            this.uploadFileBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.uploadFileBtn.UseVisualStyleBackColor = false;
            this.uploadFileBtn.Click += new System.EventHandler(this.uploadFileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Học kì:";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(136, 162);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(59, 20);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "tên file";
            // 
            // upFileBtn
            // 
            this.upFileBtn.BackColor = System.Drawing.Color.White;
            this.upFileBtn.BackgroundColor = System.Drawing.Color.White;
            this.upFileBtn.BorderColor = System.Drawing.Color.Navy;
            this.upFileBtn.BorderRadius = 40;
            this.upFileBtn.BorderSize = 2;
            this.upFileBtn.FlatAppearance.BorderSize = 0;
            this.upFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upFileBtn.ForeColor = System.Drawing.Color.Black;
            this.upFileBtn.Location = new System.Drawing.Point(232, 215);
            this.upFileBtn.Name = "upFileBtn";
            this.upFileBtn.Size = new System.Drawing.Size(190, 42);
            this.upFileBtn.TabIndex = 15;
            this.upFileBtn.Text = "Đọc file";
            this.upFileBtn.TextColor = System.Drawing.Color.Black;
            this.upFileBtn.UseVisualStyleBackColor = false;
            this.upFileBtn.Click += new System.EventHandler(this.upFileBtn_Click);
            // 
            // fileDetailDgv
            // 
            this.fileDetailDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDetailDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileDetailDgv.Location = new System.Drawing.Point(444, 37);
            this.fileDetailDgv.Name = "fileDetailDgv";
            this.fileDetailDgv.RowHeadersWidth = 51;
            this.fileDetailDgv.RowTemplate.Height = 24;
            this.fileDetailDgv.Size = new System.Drawing.Size(703, 303);
            this.fileDetailDgv.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nội dung file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nội dung nhập vào CSDL";
            // 
            // resultDgv
            // 
            this.resultDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDgv.Location = new System.Drawing.Point(12, 369);
            this.resultDgv.Name = "resultDgv";
            this.resultDgv.RowHeadersWidth = 51;
            this.resultDgv.RowTemplate.Height = 24;
            this.resultDgv.Size = new System.Drawing.Size(1135, 399);
            this.resultDgv.TabIndex = 19;
            // 
            // numOfRowInData
            // 
            this.numOfRowInData.AutoSize = true;
            this.numOfRowInData.BackColor = System.Drawing.SystemColors.Control;
            this.numOfRowInData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfRowInData.Location = new System.Drawing.Point(590, 12);
            this.numOfRowInData.Name = "numOfRowInData";
            this.numOfRowInData.Size = new System.Drawing.Size(110, 22);
            this.numOfRowInData.TabIndex = 20;
            this.numOfRowInData.Text = "Nội dung file";
            // 
            // rowInDataBaseLbl
            // 
            this.rowInDataBaseLbl.AutoSize = true;
            this.rowInDataBaseLbl.BackColor = System.Drawing.SystemColors.Control;
            this.rowInDataBaseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowInDataBaseLbl.Location = new System.Drawing.Point(256, 344);
            this.rowInDataBaseLbl.Name = "rowInDataBaseLbl";
            this.rowInDataBaseLbl.Size = new System.Drawing.Size(110, 22);
            this.rowInDataBaseLbl.TabIndex = 21;
            this.rowInDataBaseLbl.Text = "Nội dung file";
            // 
            // DocDSSVLamKhoaLuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1159, 780);
            this.Controls.Add(this.rowInDataBaseLbl);
            this.Controls.Add(this.numOfRowInData);
            this.Controls.Add(this.resultDgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileDetailDgv);
            this.Controls.Add(this.upFileBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "DocDSSVLamKhoaLuan";
            this.Text = "DocDSSVLamKhoaLuan";
            this.Load += new System.EventHandler(this.DocDSSVLamKhoaLuan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileDetailDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label label2;
        private buttonCustom uploadFileBtn;
        private buttonCustom upFileBtn;
        private System.Windows.Forms.DataGridView fileDetailDgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView resultDgv;
        private System.Windows.Forms.TextBox namKTTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox namBDTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox hocKiCbb;
        private System.Windows.Forms.Label numOfRowInData;
        private System.Windows.Forms.Label rowInDataBaseLbl;
    }
}