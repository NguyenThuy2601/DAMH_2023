namespace QL_DA_KL
{
    partial class QLBuoiBaoVe
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.svChuaCoLichTab2Lbl = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hoidDongTab2Dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ngayToChucTab2Dtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BuoiToChucTab2DTP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gvpbCBBTab2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idHoiDongLblTab2Lbl = new System.Windows.Forms.Label();
            this.svTab2Gdv = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.hkTab2lbl = new System.Windows.Forms.Label();
            this.tvHoidDongDgv = new System.Windows.Forms.DataGridView();
            this.buttonCustom1 = new QL_DA_KL.buttonCustom();
            this.buttonCustom3 = new QL_DA_KL.buttonCustom();
            this.createBtn = new QL_DA_KL.buttonCustom();
            this.confirmBtnTab2 = new QL_DA_KL.buttonCustom();
            this.listGVPB = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svChuaCoLichTab2Lbl)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoidDongTab2Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svTab2Gdv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvHoidDongDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1143, 762);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1135, 733);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý buổi bảo vệ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.buttonCustom1);
            this.tabPage2.Controls.Add(this.buttonCustom3);
            this.tabPage2.Controls.Add(this.tvHoidDongDgv);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.svTab2Gdv);
            this.tabPage2.Controls.Add(this.hoidDongTab2Dgv);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.svChuaCoLichTab2Lbl);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1135, 733);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lập lịch";
            // 
            // svChuaCoLichTab2Lbl
            // 
            this.svChuaCoLichTab2Lbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.svChuaCoLichTab2Lbl.Location = new System.Drawing.Point(6, 384);
            this.svChuaCoLichTab2Lbl.Name = "svChuaCoLichTab2Lbl";
            this.svChuaCoLichTab2Lbl.RowHeadersWidth = 51;
            this.svChuaCoLichTab2Lbl.RowTemplate.Height = 24;
            this.svChuaCoLichTab2Lbl.Size = new System.Drawing.Size(544, 343);
            this.svChuaCoLichTab2Lbl.TabIndex = 2;
            this.svChuaCoLichTab2Lbl.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.svChuaCoLichTab2Lbl_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.listGVPB);
            this.groupBox1.Controls.Add(this.hkTab2lbl);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.createBtn);
            this.groupBox1.Controls.Add(this.idHoiDongLblTab2Lbl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.gvpbCBBTab2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.confirmBtnTab2);
            this.groupBox1.Controls.Add(this.BuoiToChucTab2DTP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ngayToChucTab2Dtp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 341);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // hoidDongTab2Dgv
            // 
            this.hoidDongTab2Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hoidDongTab2Dgv.Location = new System.Drawing.Point(556, 356);
            this.hoidDongTab2Dgv.Name = "hoidDongTab2Dgv";
            this.hoidDongTab2Dgv.RowHeadersWidth = 51;
            this.hoidDongTab2Dgv.RowTemplate.Height = 24;
            this.hoidDongTab2Dgv.Size = new System.Drawing.Size(573, 215);
            this.hoidDongTab2Dgv.TabIndex = 4;
            this.hoidDongTab2Dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.hoidDongTab2Dgv_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày bắt đầu:";
            // 
            // ngayToChucTab2Dtp
            // 
            this.ngayToChucTab2Dtp.CustomFormat = "dd/MM/yyyy";
            this.ngayToChucTab2Dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayToChucTab2Dtp.Location = new System.Drawing.Point(144, 57);
            this.ngayToChucTab2Dtp.MinDate = new System.DateTime(2023, 10, 23, 0, 0, 0, 0);
            this.ngayToChucTab2Dtp.Name = "ngayToChucTab2Dtp";
            this.ngayToChucTab2Dtp.Size = new System.Drawing.Size(182, 27);
            this.ngayToChucTab2Dtp.TabIndex = 1;
            this.ngayToChucTab2Dtp.ValueChanged += new System.EventHandler(this.ngayToChucTab2Dtp_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buổi tổ chức:";
            // 
            // BuoiToChucTab2DTP
            // 
            this.BuoiToChucTab2DTP.FormattingEnabled = true;
            this.BuoiToChucTab2DTP.Items.AddRange(new object[] {
            "Sáng (7h đến 11h30)",
            "Chiều (13h đến 17h)"});
            this.BuoiToChucTab2DTP.Location = new System.Drawing.Point(144, 94);
            this.BuoiToChucTab2DTP.Name = "BuoiToChucTab2DTP";
            this.BuoiToChucTab2DTP.Size = new System.Drawing.Size(182, 28);
            this.BuoiToChucTab2DTP.TabIndex = 3;
            this.BuoiToChucTab2DTP.SelectionChangeCommitted += new System.EventHandler(this.BuoiToChucTab2DTP_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "GVPB:";
            // 
            // gvpbCBBTab2
            // 
            this.gvpbCBBTab2.FormattingEnabled = true;
            this.gvpbCBBTab2.Location = new System.Drawing.Point(101, 194);
            this.gvpbCBBTab2.Name = "gvpbCBBTab2";
            this.gvpbCBBTab2.Size = new System.Drawing.Size(281, 28);
            this.gvpbCBBTab2.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Hội đồng:";
            // 
            // idHoiDongLblTab2Lbl
            // 
            this.idHoiDongLblTab2Lbl.AutoSize = true;
            this.idHoiDongLblTab2Lbl.Location = new System.Drawing.Point(97, 162);
            this.idHoiDongLblTab2Lbl.Name = "idHoiDongLblTab2Lbl";
            this.idHoiDongLblTab2Lbl.Size = new System.Drawing.Size(53, 20);
            this.idHoiDongLblTab2Lbl.TabIndex = 32;
            this.idHoiDongLblTab2Lbl.Text = "label5";
            // 
            // svTab2Gdv
            // 
            this.svTab2Gdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.svTab2Gdv.Location = new System.Drawing.Point(556, 31);
            this.svTab2Gdv.Name = "svTab2Gdv";
            this.svTab2Gdv.RowHeadersWidth = 51;
            this.svTab2Gdv.RowTemplate.Height = 24;
            this.svTab2Gdv.Size = new System.Drawing.Size(573, 197);
            this.svTab2Gdv.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(556, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 22);
            this.label6.TabIndex = 19;
            this.label6.Text = "Danh sách các sinh viên:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(364, 22);
            this.label7.TabIndex = 20;
            this.label7.Text = "Danh sách các sinh viên chưa được xếp lịch:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(558, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "Danh sách các hội đồng:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Học kì - năm học:";
            // 
            // hkTab2lbl
            // 
            this.hkTab2lbl.AutoSize = true;
            this.hkTab2lbl.Location = new System.Drawing.Point(168, 25);
            this.hkTab2lbl.Name = "hkTab2lbl";
            this.hkTab2lbl.Size = new System.Drawing.Size(62, 20);
            this.hkTab2lbl.TabIndex = 37;
            this.hkTab2lbl.Text = "label10";
            // 
            // tvHoidDongDgv
            // 
            this.tvHoidDongDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tvHoidDongDgv.Location = new System.Drawing.Point(560, 577);
            this.tvHoidDongDgv.Name = "tvHoidDongDgv";
            this.tvHoidDongDgv.RowHeadersWidth = 51;
            this.tvHoidDongDgv.RowTemplate.Height = 24;
            this.tvHoidDongDgv.Size = new System.Drawing.Size(569, 150);
            this.tvHoidDongDgv.TabIndex = 22;
            this.tvHoidDongDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tvHoidDongDgv_CellMouseClick);
            // 
            // buttonCustom1
            // 
            this.buttonCustom1.BackColor = System.Drawing.Color.White;
            this.buttonCustom1.BackgroundColor = System.Drawing.Color.White;
            this.buttonCustom1.BorderColor = System.Drawing.Color.Navy;
            this.buttonCustom1.BorderRadius = 40;
            this.buttonCustom1.BorderSize = 2;
            this.buttonCustom1.FlatAppearance.BorderSize = 0;
            this.buttonCustom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom1.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom1.Location = new System.Drawing.Point(973, 234);
            this.buttonCustom1.Name = "buttonCustom1";
            this.buttonCustom1.Size = new System.Drawing.Size(83, 42);
            this.buttonCustom1.TabIndex = 24;
            this.buttonCustom1.Text = "Reset";
            this.buttonCustom1.TextColor = System.Drawing.Color.Black;
            this.buttonCustom1.UseVisualStyleBackColor = false;
            // 
            // buttonCustom3
            // 
            this.buttonCustom3.BackColor = System.Drawing.Color.White;
            this.buttonCustom3.BackgroundColor = System.Drawing.Color.White;
            this.buttonCustom3.BorderColor = System.Drawing.Color.Navy;
            this.buttonCustom3.BorderRadius = 40;
            this.buttonCustom3.BorderSize = 2;
            this.buttonCustom3.FlatAppearance.BorderSize = 0;
            this.buttonCustom3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom3.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom3.Location = new System.Drawing.Point(1062, 234);
            this.buttonCustom3.Name = "buttonCustom3";
            this.buttonCustom3.Size = new System.Drawing.Size(67, 42);
            this.buttonCustom3.TabIndex = 23;
            this.buttonCustom3.Text = "X";
            this.buttonCustom3.TextColor = System.Drawing.Color.Black;
            this.buttonCustom3.UseVisualStyleBackColor = false;
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.Color.Navy;
            this.createBtn.BackgroundColor = System.Drawing.Color.Navy;
            this.createBtn.BorderColor = System.Drawing.Color.Navy;
            this.createBtn.BorderRadius = 40;
            this.createBtn.BorderSize = 2;
            this.createBtn.FlatAppearance.BorderSize = 0;
            this.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.createBtn.Location = new System.Drawing.Point(403, 287);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(87, 38);
            this.createBtn.TabIndex = 35;
            this.createBtn.Text = "Tạo";
            this.createBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.createBtn.UseVisualStyleBackColor = false;
            // 
            // confirmBtnTab2
            // 
            this.confirmBtnTab2.BackColor = System.Drawing.Color.Navy;
            this.confirmBtnTab2.BackgroundColor = System.Drawing.Color.Navy;
            this.confirmBtnTab2.BorderColor = System.Drawing.Color.Navy;
            this.confirmBtnTab2.BorderRadius = 40;
            this.confirmBtnTab2.BorderSize = 2;
            this.confirmBtnTab2.FlatAppearance.BorderSize = 0;
            this.confirmBtnTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtnTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtnTab2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.confirmBtnTab2.Location = new System.Drawing.Point(376, 62);
            this.confirmBtnTab2.Name = "confirmBtnTab2";
            this.confirmBtnTab2.Size = new System.Drawing.Size(87, 54);
            this.confirmBtnTab2.TabIndex = 28;
            this.confirmBtnTab2.Text = "Xác nhận";
            this.confirmBtnTab2.TextColor = System.Drawing.Color.WhiteSmoke;
            this.confirmBtnTab2.UseVisualStyleBackColor = false;
            this.confirmBtnTab2.Click += new System.EventHandler(this.confirmBtnTab2_Click);
            // 
            // listGVPB
            // 
            this.listGVPB.HideSelection = false;
            this.listGVPB.Location = new System.Drawing.Point(101, 228);
            this.listGVPB.Name = "listGVPB";
            this.listGVPB.Size = new System.Drawing.Size(281, 97);
            this.listGVPB.TabIndex = 38;
            this.listGVPB.UseCompatibleStateImageBehavior = false;
            // 
            // QLBuoiBaoVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 780);
            this.Controls.Add(this.tabControl1);
            this.Name = "QLBuoiBaoVe";
            this.Text = "QLBuoiBaoVe";
            this.Load += new System.EventHandler(this.QLBuoiBaoVe_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svChuaCoLichTab2Lbl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoidDongTab2Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svTab2Gdv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvHoidDongDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView hoidDongTab2Dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox BuoiToChucTab2DTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ngayToChucTab2Dtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView svChuaCoLichTab2Lbl;
        private System.Windows.Forms.DataGridView svTab2Gdv;
        private buttonCustom createBtn;
        private System.Windows.Forms.Label idHoiDongLblTab2Lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox gvpbCBBTab2;
        private System.Windows.Forms.Label label3;
        private buttonCustom confirmBtnTab2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label hkTab2lbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView tvHoidDongDgv;
        private buttonCustom buttonCustom1;
        private buttonCustom buttonCustom3;
        private System.Windows.Forms.ListView listGVPB;
    }
}