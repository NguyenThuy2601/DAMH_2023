namespace QL_DA_KL
{
    partial class DocLichBieuGV
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
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.fileDetailDgv = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.resultDgv = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.upFileBtn = new QL_DA_KL.buttonCustom();
            this.taiFileBtn = new QL_DA_KL.buttonCustom();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileDetailDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.taiFileBtn);
            this.groupBox1.Controls.Add(this.fileNameLbl);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(140, 58);
            this.fileNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(70, 22);
            this.fileNameLbl.TabIndex = 12;
            this.fileNameLbl.Text = "Tên file";
            // 
            // fileDetailDgv
            // 
            this.fileDetailDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDetailDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileDetailDgv.Location = new System.Drawing.Point(516, 37);
            this.fileDetailDgv.Name = "fileDetailDgv";
            this.fileDetailDgv.RowHeadersWidth = 51;
            this.fileDetailDgv.RowTemplate.Height = 24;
            this.fileDetailDgv.Size = new System.Drawing.Size(631, 286);
            this.fileDetailDgv.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(524, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nội dung file";
            // 
            // resultDgv
            // 
            this.resultDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDgv.Location = new System.Drawing.Point(12, 346);
            this.resultDgv.Name = "resultDgv";
            this.resultDgv.RowHeadersWidth = 51;
            this.resultDgv.RowTemplate.Height = 24;
            this.resultDgv.Size = new System.Drawing.Size(1135, 422);
            this.resultDgv.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 22);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nội dung lưu vào CSDL";
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
            this.upFileBtn.Location = new System.Drawing.Point(303, 157);
            this.upFileBtn.Name = "upFileBtn";
            this.upFileBtn.Size = new System.Drawing.Size(190, 42);
            this.upFileBtn.TabIndex = 15;
            this.upFileBtn.Text = "Đọc file";
            this.upFileBtn.TextColor = System.Drawing.Color.Black;
            this.upFileBtn.UseVisualStyleBackColor = false;
            this.upFileBtn.Click += new System.EventHandler(this.upFileBtn_Click);
            // 
            // taiFileBtn
            // 
            this.taiFileBtn.BackColor = System.Drawing.Color.Navy;
            this.taiFileBtn.BackgroundColor = System.Drawing.Color.Navy;
            this.taiFileBtn.BorderColor = System.Drawing.Color.Navy;
            this.taiFileBtn.BorderRadius = 40;
            this.taiFileBtn.BorderSize = 2;
            this.taiFileBtn.FlatAppearance.BorderSize = 0;
            this.taiFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taiFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taiFileBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.taiFileBtn.Location = new System.Drawing.Point(6, 47);
            this.taiFileBtn.Name = "taiFileBtn";
            this.taiFileBtn.Size = new System.Drawing.Size(111, 42);
            this.taiFileBtn.TabIndex = 13;
            this.taiFileBtn.Text = "Tải file";
            this.taiFileBtn.TextColor = System.Drawing.Color.WhiteSmoke;
            this.taiFileBtn.UseVisualStyleBackColor = false;
            this.taiFileBtn.Click += new System.EventHandler(this.taiFileBtn_Click);
            // 
            // DocLichBieuGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1159, 780);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.upFileBtn);
            this.Controls.Add(this.resultDgv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileDetailDgv);
            this.Controls.Add(this.groupBox1);
            this.Name = "DocLichBieuGV";
            this.Text = "DocLichBieuGV";
            this.Load += new System.EventHandler(this.DocLichBieuGV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileDetailDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private buttonCustom taiFileBtn;
        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.DataGridView fileDetailDgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView resultDgv;
        private buttonCustom upFileBtn;
        private System.Windows.Forms.Label label5;
    }
}