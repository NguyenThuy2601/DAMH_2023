namespace QL_DA_KL
{
    partial class GuiEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiEmail));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toEmailCbb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rightAlignBtn = new QL_DA_KL.buttonCustom();
            this.leftAlignBtn = new QL_DA_KL.buttonCustom();
            this.centerAlignBtn = new QL_DA_KL.buttonCustom();
            this.listBtn = new QL_DA_KL.buttonCustom();
            this.underlineBtn = new QL_DA_KL.buttonCustom();
            this.italicBtn = new QL_DA_KL.buttonCustom();
            this.boldBtn = new QL_DA_KL.buttonCustom();
            this.sizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colorBtn = new QL_DA_KL.buttonCustom();
            this.colorLbl = new System.Windows.Forms.Label();
            this.contenRichTextBox = new System.Windows.Forms.RichTextBox();
            this.fileFlowOutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sendBtn = new QL_DA_KL.buttonCustom();
            this.uploadFileBtn = new QL_DA_KL.buttonCustom();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gửi đến:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiêu đề:";
            // 
            // toEmailCbb
            // 
            this.toEmailCbb.FormattingEnabled = true;
            this.toEmailCbb.Items.AddRange(new object[] {
            "Nhóm sinh viên (học kì mới nhất)",
            "Nhóm giảng viên",
            "Tất cả"});
            this.toEmailCbb.Location = new System.Drawing.Point(89, 44);
            this.toEmailCbb.Name = "toEmailCbb";
            this.toEmailCbb.Size = new System.Drawing.Size(349, 33);
            this.toEmailCbb.TabIndex = 2;
            this.toEmailCbb.SelectionChangeCommitted += new System.EventHandler(this.toEmailCbb_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.titleTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.toEmailCbb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 168);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // titleTxt
            // 
            this.titleTxt.Location = new System.Drawing.Point(86, 112);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(474, 30);
            this.titleTxt.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.rightAlignBtn);
            this.groupBox2.Controls.Add(this.leftAlignBtn);
            this.groupBox2.Controls.Add(this.centerAlignBtn);
            this.groupBox2.Controls.Add(this.listBtn);
            this.groupBox2.Controls.Add(this.underlineBtn);
            this.groupBox2.Controls.Add(this.italicBtn);
            this.groupBox2.Controls.Add(this.boldBtn);
            this.groupBox2.Controls.Add(this.sizeNumeric);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.colorBtn);
            this.groupBox2.Controls.Add(this.colorLbl);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(599, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 213);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kiểu chữ";
            // 
            // rightAlignBtn
            // 
            this.rightAlignBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.rightAlignBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.rightAlignBtn.BorderColor = System.Drawing.Color.Navy;
            this.rightAlignBtn.BorderRadius = 40;
            this.rightAlignBtn.BorderSize = 1;
            this.rightAlignBtn.FlatAppearance.BorderSize = 0;
            this.rightAlignBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightAlignBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightAlignBtn.ForeColor = System.Drawing.Color.Black;
            this.rightAlignBtn.Image = ((System.Drawing.Image)(resources.GetObject("rightAlignBtn.Image")));
            this.rightAlignBtn.Location = new System.Drawing.Point(147, 158);
            this.rightAlignBtn.Name = "rightAlignBtn";
            this.rightAlignBtn.Size = new System.Drawing.Size(60, 40);
            this.rightAlignBtn.TabIndex = 11;
            this.rightAlignBtn.TextColor = System.Drawing.Color.Black;
            this.rightAlignBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rightAlignBtn.UseVisualStyleBackColor = false;
            this.rightAlignBtn.Click += new System.EventHandler(this.rightAlignBtn_Click);
            // 
            // leftAlignBtn
            // 
            this.leftAlignBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.leftAlignBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.leftAlignBtn.BorderColor = System.Drawing.Color.Navy;
            this.leftAlignBtn.BorderRadius = 40;
            this.leftAlignBtn.BorderSize = 1;
            this.leftAlignBtn.FlatAppearance.BorderSize = 0;
            this.leftAlignBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftAlignBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftAlignBtn.ForeColor = System.Drawing.Color.Black;
            this.leftAlignBtn.Image = ((System.Drawing.Image)(resources.GetObject("leftAlignBtn.Image")));
            this.leftAlignBtn.Location = new System.Drawing.Point(17, 158);
            this.leftAlignBtn.Name = "leftAlignBtn";
            this.leftAlignBtn.Size = new System.Drawing.Size(60, 40);
            this.leftAlignBtn.TabIndex = 9;
            this.leftAlignBtn.TextColor = System.Drawing.Color.Black;
            this.leftAlignBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.leftAlignBtn.UseVisualStyleBackColor = false;
            this.leftAlignBtn.Click += new System.EventHandler(this.leftAlignBtn_Click);
            // 
            // centerAlignBtn
            // 
            this.centerAlignBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.centerAlignBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.centerAlignBtn.BorderColor = System.Drawing.Color.Navy;
            this.centerAlignBtn.BorderRadius = 40;
            this.centerAlignBtn.BorderSize = 1;
            this.centerAlignBtn.FlatAppearance.BorderSize = 0;
            this.centerAlignBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.centerAlignBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centerAlignBtn.ForeColor = System.Drawing.Color.Black;
            this.centerAlignBtn.Image = ((System.Drawing.Image)(resources.GetObject("centerAlignBtn.Image")));
            this.centerAlignBtn.Location = new System.Drawing.Point(81, 158);
            this.centerAlignBtn.Name = "centerAlignBtn";
            this.centerAlignBtn.Size = new System.Drawing.Size(60, 40);
            this.centerAlignBtn.TabIndex = 8;
            this.centerAlignBtn.TextColor = System.Drawing.Color.Black;
            this.centerAlignBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.centerAlignBtn.UseVisualStyleBackColor = false;
            this.centerAlignBtn.Click += new System.EventHandler(this.buttonCustom1_Click);
            // 
            // listBtn
            // 
            this.listBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.listBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.listBtn.BorderColor = System.Drawing.Color.Navy;
            this.listBtn.BorderRadius = 40;
            this.listBtn.BorderSize = 1;
            this.listBtn.FlatAppearance.BorderSize = 0;
            this.listBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBtn.ForeColor = System.Drawing.Color.Black;
            this.listBtn.Location = new System.Drawing.Point(271, 107);
            this.listBtn.Name = "listBtn";
            this.listBtn.Size = new System.Drawing.Size(129, 40);
            this.listBtn.TabIndex = 7;
            this.listBtn.Text = "Danh sách";
            this.listBtn.TextColor = System.Drawing.Color.Black;
            this.listBtn.UseVisualStyleBackColor = false;
            this.listBtn.Click += new System.EventHandler(this.listBtn_Click);
            // 
            // underlineBtn
            // 
            this.underlineBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.underlineBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.underlineBtn.BorderColor = System.Drawing.Color.Navy;
            this.underlineBtn.BorderRadius = 40;
            this.underlineBtn.BorderSize = 1;
            this.underlineBtn.FlatAppearance.BorderSize = 0;
            this.underlineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.underlineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.underlineBtn.ForeColor = System.Drawing.Color.Black;
            this.underlineBtn.Location = new System.Drawing.Point(147, 112);
            this.underlineBtn.Name = "underlineBtn";
            this.underlineBtn.Size = new System.Drawing.Size(60, 40);
            this.underlineBtn.TabIndex = 6;
            this.underlineBtn.Text = "U";
            this.underlineBtn.TextColor = System.Drawing.Color.Black;
            this.underlineBtn.UseVisualStyleBackColor = false;
            this.underlineBtn.Click += new System.EventHandler(this.underlineBtn_Click);
            // 
            // italicBtn
            // 
            this.italicBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.italicBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.italicBtn.BorderColor = System.Drawing.Color.Navy;
            this.italicBtn.BorderRadius = 40;
            this.italicBtn.BorderSize = 1;
            this.italicBtn.FlatAppearance.BorderSize = 0;
            this.italicBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.italicBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.italicBtn.ForeColor = System.Drawing.Color.Black;
            this.italicBtn.Location = new System.Drawing.Point(81, 112);
            this.italicBtn.Name = "italicBtn";
            this.italicBtn.Size = new System.Drawing.Size(60, 40);
            this.italicBtn.TabIndex = 5;
            this.italicBtn.Text = "I";
            this.italicBtn.TextColor = System.Drawing.Color.Black;
            this.italicBtn.UseVisualStyleBackColor = false;
            this.italicBtn.Click += new System.EventHandler(this.italicBtn_Click);
            // 
            // boldBtn
            // 
            this.boldBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.boldBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.boldBtn.BorderColor = System.Drawing.Color.Navy;
            this.boldBtn.BorderRadius = 40;
            this.boldBtn.BorderSize = 1;
            this.boldBtn.FlatAppearance.BorderSize = 0;
            this.boldBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boldBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boldBtn.ForeColor = System.Drawing.Color.Black;
            this.boldBtn.Location = new System.Drawing.Point(17, 112);
            this.boldBtn.Name = "boldBtn";
            this.boldBtn.Size = new System.Drawing.Size(60, 40);
            this.boldBtn.TabIndex = 4;
            this.boldBtn.Text = "B";
            this.boldBtn.TextColor = System.Drawing.Color.Black;
            this.boldBtn.UseVisualStyleBackColor = false;
            this.boldBtn.Click += new System.EventHandler(this.boldBtn_Click);
            // 
            // sizeNumeric
            // 
            this.sizeNumeric.Location = new System.Drawing.Point(353, 45);
            this.sizeNumeric.Name = "sizeNumeric";
            this.sizeNumeric.Size = new System.Drawing.Size(120, 30);
            this.sizeNumeric.TabIndex = 3;
            this.sizeNumeric.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.sizeNumeric.ValueChanged += new System.EventHandler(this.sizeNumeric_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cỡ chữ:";
            // 
            // colorBtn
            // 
            this.colorBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.colorBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.colorBtn.BorderColor = System.Drawing.Color.Navy;
            this.colorBtn.BorderRadius = 40;
            this.colorBtn.BorderSize = 1;
            this.colorBtn.FlatAppearance.BorderSize = 0;
            this.colorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorBtn.ForeColor = System.Drawing.Color.Black;
            this.colorBtn.Location = new System.Drawing.Point(81, 39);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(150, 40);
            this.colorBtn.TabIndex = 1;
            this.colorBtn.Text = "Chọn màu";
            this.colorBtn.TextColor = System.Drawing.Color.Black;
            this.colorBtn.UseVisualStyleBackColor = false;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // colorLbl
            // 
            this.colorLbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorLbl.Location = new System.Drawing.Point(21, 44);
            this.colorLbl.Name = "colorLbl";
            this.colorLbl.Size = new System.Drawing.Size(45, 33);
            this.colorLbl.TabIndex = 0;
            // 
            // contenRichTextBox
            // 
            this.contenRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenRichTextBox.Location = new System.Drawing.Point(12, 303);
            this.contenRichTextBox.Name = "contenRichTextBox";
            this.contenRichTextBox.Size = new System.Drawing.Size(1135, 475);
            this.contenRichTextBox.TabIndex = 5;
            this.contenRichTextBox.Text = "";
            this.contenRichTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contenRichTextBox_MouseClick);
            // 
            // fileFlowOutPanel
            // 
            this.fileFlowOutPanel.AutoScroll = true;
            this.fileFlowOutPanel.BackColor = System.Drawing.Color.White;
            this.fileFlowOutPanel.Location = new System.Drawing.Point(12, 237);
            this.fileFlowOutPanel.Name = "fileFlowOutPanel";
            this.fileFlowOutPanel.Size = new System.Drawing.Size(560, 60);
            this.fileFlowOutPanel.TabIndex = 6;
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.sendBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.sendBtn.BorderColor = System.Drawing.Color.Navy;
            this.sendBtn.BorderRadius = 40;
            this.sendBtn.BorderSize = 1;
            this.sendBtn.FlatAppearance.BorderSize = 0;
            this.sendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.ForeColor = System.Drawing.Color.Black;
            this.sendBtn.Location = new System.Drawing.Point(1018, 246);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(129, 40);
            this.sendBtn.TabIndex = 9;
            this.sendBtn.Text = "Gửi";
            this.sendBtn.TextColor = System.Drawing.Color.Black;
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // uploadFileBtn
            // 
            this.uploadFileBtn.BackColor = System.Drawing.Color.GhostWhite;
            this.uploadFileBtn.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.uploadFileBtn.BorderColor = System.Drawing.Color.Navy;
            this.uploadFileBtn.BorderRadius = 40;
            this.uploadFileBtn.BorderSize = 1;
            this.uploadFileBtn.FlatAppearance.BorderSize = 0;
            this.uploadFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadFileBtn.ForeColor = System.Drawing.Color.Black;
            this.uploadFileBtn.Location = new System.Drawing.Point(599, 246);
            this.uploadFileBtn.Name = "uploadFileBtn";
            this.uploadFileBtn.Size = new System.Drawing.Size(129, 40);
            this.uploadFileBtn.TabIndex = 8;
            this.uploadFileBtn.Text = "Tải file";
            this.uploadFileBtn.TextColor = System.Drawing.Color.Black;
            this.uploadFileBtn.UseVisualStyleBackColor = false;
            this.uploadFileBtn.Click += new System.EventHandler(this.uploadFileBtn_Click);
            // 
            // GuiEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1159, 790);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.uploadFileBtn);
            this.Controls.Add(this.fileFlowOutPanel);
            this.Controls.Add(this.contenRichTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GuiEmail";
            this.Text = "GuiEmail";
            this.Load += new System.EventHandler(this.GuiEmail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox toEmailCbb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private buttonCustom colorBtn;
        private System.Windows.Forms.Label colorLbl;
        private buttonCustom listBtn;
        private buttonCustom underlineBtn;
        private buttonCustom italicBtn;
        private buttonCustom boldBtn;
        private System.Windows.Forms.NumericUpDown sizeNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox contenRichTextBox;
        private System.Windows.Forms.FlowLayoutPanel fileFlowOutPanel;
        private buttonCustom uploadFileBtn;
        private buttonCustom sendBtn;
        private buttonCustom centerAlignBtn;
        private buttonCustom rightAlignBtn;
        private buttonCustom leftAlignBtn;
    }
}