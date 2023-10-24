namespace QL_DA_KL
{
    partial class QLNhomSV
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.newGVHDCbb = new System.Windows.Forms.GroupBox();
            this.cbbGVHD = new System.Windows.Forms.ComboBox();
            this.chossenSVName = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chossenMSSV = new System.Windows.Forms.ListBox();
            this.curentGVHD = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.gvCBB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hkCbb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonCustom1 = new QL_DA_KL.buttonCustom();
            this.delSvFromList = new QL_DA_KL.buttonCustom();
            this.updateBtn = new QL_DA_KL.buttonCustom();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.newGVHDCbb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 319);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1135, 449);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Giảng viên";
            // 
            // newGVHDCbb
            // 
            this.newGVHDCbb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newGVHDCbb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newGVHDCbb.BackColor = System.Drawing.SystemColors.Control;
            this.newGVHDCbb.Controls.Add(this.delSvFromList);
            this.newGVHDCbb.Controls.Add(this.cbbGVHD);
            this.newGVHDCbb.Controls.Add(this.chossenSVName);
            this.newGVHDCbb.Controls.Add(this.label3);
            this.newGVHDCbb.Controls.Add(this.chossenMSSV);
            this.newGVHDCbb.Controls.Add(this.curentGVHD);
            this.newGVHDCbb.Controls.Add(this.label8);
            this.newGVHDCbb.Controls.Add(this.updateBtn);
            this.newGVHDCbb.Controls.Add(this.label);
            this.newGVHDCbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGVHDCbb.Location = new System.Drawing.Point(12, 12);
            this.newGVHDCbb.Name = "newGVHDCbb";
            this.newGVHDCbb.Size = new System.Drawing.Size(743, 244);
            this.newGVHDCbb.TabIndex = 5;
            this.newGVHDCbb.TabStop = false;
            this.newGVHDCbb.Text = "Thông tin sinh viên";
            // 
            // cbbGVHD
            // 
            this.cbbGVHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGVHD.FormattingEnabled = true;
            this.cbbGVHD.Location = new System.Drawing.Point(83, 209);
            this.cbbGVHD.Name = "cbbGVHD";
            this.cbbGVHD.Size = new System.Drawing.Size(253, 30);
            this.cbbGVHD.TabIndex = 31;
            this.cbbGVHD.SelectionChangeCommitted += new System.EventHandler(this.cbbGVHD_SelectionChangeCommitted);
            // 
            // chossenSVName
            // 
            this.chossenSVName.FormattingEnabled = true;
            this.chossenSVName.ItemHeight = 22;
            this.chossenSVName.Location = new System.Drawing.Point(415, 40);
            this.chossenSVName.Name = "chossenSVName";
            this.chossenSVName.Size = new System.Drawing.Size(188, 114);
            this.chossenSVName.TabIndex = 30;
            this.chossenSVName.SelectedIndexChanged += new System.EventHandler(this.chossenSVName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "Họ tên";
            // 
            // chossenMSSV
            // 
            this.chossenMSSV.FormattingEnabled = true;
            this.chossenMSSV.ItemHeight = 22;
            this.chossenMSSV.Location = new System.Drawing.Point(77, 40);
            this.chossenMSSV.Name = "chossenMSSV";
            this.chossenMSSV.Size = new System.Drawing.Size(188, 114);
            this.chossenMSSV.TabIndex = 28;
            this.chossenMSSV.SelectedIndexChanged += new System.EventHandler(this.chossenMSSV_SelectedIndexChanged);
            // 
            // curentGVHD
            // 
            this.curentGVHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.curentGVHD.AutoSize = true;
            this.curentGVHD.Location = new System.Drawing.Point(79, 170);
            this.curentGVHD.Name = "curentGVHD";
            this.curentGVHD.Size = new System.Drawing.Size(125, 22);
            this.curentGVHD.TabIndex = 27;
            this.curentGVHD.Text = "GVHD hiện tại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "GVHD:";
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(6, 38);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(65, 22);
            this.label.TabIndex = 0;
            this.label.Text = "MSSV:";
            // 
            // gvCBB
            // 
            this.gvCBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gvCBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvCBB.FormattingEnabled = true;
            this.gvCBB.Location = new System.Drawing.Point(129, 70);
            this.gvCBB.Name = "gvCBB";
            this.gvCBB.Size = new System.Drawing.Size(231, 30);
            this.gvCBB.TabIndex = 6;
            this.gvCBB.SelectionChangeCommitted += new System.EventHandler(this.gvCBB_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Học kì";
            // 
            // hkCbb
            // 
            this.hkCbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hkCbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hkCbb.FormattingEnabled = true;
            this.hkCbb.Location = new System.Drawing.Point(129, 123);
            this.hkCbb.Name = "hkCbb";
            this.hkCbb.Size = new System.Drawing.Size(231, 30);
            this.hkCbb.TabIndex = 8;
            this.hkCbb.SelectionChangeCommitted += new System.EventHandler(this.hkCbb_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.buttonCustom1);
            this.groupBox1.Controls.Add(this.gvCBB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.hkCbb);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(762, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 243);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "Nhóm sinh viên";
            // 
            // buttonCustom1
            // 
            this.buttonCustom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCustom1.BackColor = System.Drawing.Color.Navy;
            this.buttonCustom1.BackgroundColor = System.Drawing.Color.Navy;
            this.buttonCustom1.BorderColor = System.Drawing.Color.Navy;
            this.buttonCustom1.BorderRadius = 40;
            this.buttonCustom1.BorderSize = 2;
            this.buttonCustom1.FlatAppearance.BorderSize = 0;
            this.buttonCustom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCustom1.Location = new System.Drawing.Point(245, 168);
            this.buttonCustom1.Name = "buttonCustom1";
            this.buttonCustom1.Size = new System.Drawing.Size(115, 36);
            this.buttonCustom1.TabIndex = 15;
            this.buttonCustom1.Text = "Áp dụng";
            this.buttonCustom1.TextColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCustom1.UseVisualStyleBackColor = false;
            this.buttonCustom1.Click += new System.EventHandler(this.buttonCustom1_Click);
            // 
            // delSvFromList
            // 
            this.delSvFromList.BackColor = System.Drawing.Color.Navy;
            this.delSvFromList.BackgroundColor = System.Drawing.Color.Navy;
            this.delSvFromList.BorderColor = System.Drawing.Color.Navy;
            this.delSvFromList.BorderRadius = 40;
            this.delSvFromList.BorderSize = 2;
            this.delSvFromList.FlatAppearance.BorderSize = 0;
            this.delSvFromList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delSvFromList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delSvFromList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.delSvFromList.Location = new System.Drawing.Point(271, 113);
            this.delSvFromList.Name = "delSvFromList";
            this.delSvFromList.Size = new System.Drawing.Size(68, 36);
            this.delSvFromList.TabIndex = 32;
            this.delSvFromList.Text = "X";
            this.delSvFromList.TextColor = System.Drawing.Color.WhiteSmoke;
            this.delSvFromList.UseVisualStyleBackColor = false;
            this.delSvFromList.Click += new System.EventHandler(this.buttonCustom2_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.Navy;
            this.updateBtn.BackgroundColor = System.Drawing.Color.Navy;
            this.updateBtn.BorderColor = System.Drawing.Color.Navy;
            this.updateBtn.BorderRadius = 40;
            this.updateBtn.BorderSize = 2;
            this.updateBtn.FlatAppearance.BorderSize = 0;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.updateBtn.Location = new System.Drawing.Point(350, 202);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(141, 36);
            this.updateBtn.TabIndex = 14;
            this.updateBtn.Text = "Cập nhật";
            this.updateBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // QLNhomSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1159, 780);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newGVHDCbb);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QLNhomSV";
            this.Text = "s";
            this.Load += new System.EventHandler(this.QLNhomSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.newGVHDCbb.ResumeLayout(false);
            this.newGVHDCbb.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox newGVHDCbb;
        private System.Windows.Forms.Label label8;
        private buttonCustom updateBtn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox gvCBB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hkCbb;
        private System.Windows.Forms.GroupBox groupBox1;
        private buttonCustom buttonCustom1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbGVHD;
        private System.Windows.Forms.ListBox chossenSVName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox chossenMSSV;
        private System.Windows.Forms.Label curentGVHD;
        private buttonCustom delSvFromList;
    }
}