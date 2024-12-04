using Manage_tour.DbQueries;

namespace Manage_tour
{
    partial class FormDashBroad
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
        private void InitializeComponent(NhanVienModel nhanvien = null)
        {
            nv = nhanvien;
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.logOutIcon = new System.Windows.Forms.Panel();
            this.accountIcon = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bookTourButton = new System.Windows.Forms.Button();
            this.listPaymentButton = new System.Windows.Forms.Button();
            this.listBookedButton = new System.Windows.Forms.Button();
            this.TourDTQButton = new System.Windows.Forms.Button();
            this.TourHDVButton = new System.Windows.Forms.Button();
            this.employeeButton = new System.Windows.Forms.Button();
            this.DTQButton = new System.Windows.Forms.Button();
            this.HDVButton = new System.Windows.Forms.Button();
            this.customerButton = new System.Windows.Forms.Button();
            this.tourButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_thontintaikhoan = new System.Windows.Forms.Panel();
            this.chucVuLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.maNVLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_thontintaikhoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(148)))), ((int)(((byte)(189)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.logOutIcon);
            this.panel1.Controls.Add(this.accountIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 73);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(142, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "DHC";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel4.BackgroundImage = global::Manage_tour.Properties.Resources.logo;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(60, 10);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(67, 52);
            this.panel4.TabIndex = 4;
            // 
            // logOutIcon
            // 
            this.logOutIcon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logOutIcon.BackgroundImage = global::Manage_tour.Properties.Resources.import;
            this.logOutIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logOutIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOutIcon.Location = new System.Drawing.Point(1200, 19);
            this.logOutIcon.Margin = new System.Windows.Forms.Padding(2);
            this.logOutIcon.Name = "logOutIcon";
            this.logOutIcon.Size = new System.Drawing.Size(32, 36);
            this.logOutIcon.TabIndex = 3;
            this.logOutIcon.Click += new System.EventHandler(this.logOutIcon_Click);
            // 
            // accountIcon
            // 
            this.accountIcon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.accountIcon.BackgroundImage = global::Manage_tour.Properties.Resources.user_thi;
            this.accountIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.accountIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountIcon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.accountIcon.Location = new System.Drawing.Point(1131, 19);
            this.accountIcon.Margin = new System.Windows.Forms.Padding(2);
            this.accountIcon.Name = "accountIcon";
            this.accountIcon.Size = new System.Drawing.Size(35, 36);
            this.accountIcon.TabIndex = 2;
            this.accountIcon.Click += new System.EventHandler(this.accountIcon_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 73);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(125)))), ((int)(((byte)(148)))));
            this.splitContainer1.Panel1.Controls.Add(this.bookTourButton);
            this.splitContainer1.Panel1.Controls.Add(this.listPaymentButton);
            this.splitContainer1.Panel1.Controls.Add(this.listBookedButton);
            this.splitContainer1.Panel1.Controls.Add(this.TourDTQButton);
            this.splitContainer1.Panel1.Controls.Add(this.TourHDVButton);
            this.splitContainer1.Panel1.Controls.Add(this.employeeButton);
            this.splitContainer1.Panel1.Controls.Add(this.DTQButton);
            this.splitContainer1.Panel1.Controls.Add(this.HDVButton);
            this.splitContainer1.Panel1.Controls.Add(this.customerButton);
            this.splitContainer1.Panel1.Controls.Add(this.tourButton);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Panel2.BackgroundImage = global::Manage_tour.Properties.Resources.dulichc_;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.panel_thontintaikhoan);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 738);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // bookTourButton
            // 
            this.bookTourButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookTourButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookTourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookTourButton.Location = new System.Drawing.Point(80, 594);
            this.bookTourButton.Margin = new System.Windows.Forms.Padding(2);
            this.bookTourButton.Name = "bookTourButton";
            this.bookTourButton.Size = new System.Drawing.Size(152, 33);
            this.bookTourButton.TabIndex = 10;
            this.bookTourButton.Text = "Đặt Tour";
            this.bookTourButton.UseVisualStyleBackColor = true;
            this.bookTourButton.Click += new System.EventHandler(this.bookTourButton_Click);
            // 
            // listPaymentButton
            // 
            this.listPaymentButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listPaymentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listPaymentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPaymentButton.Location = new System.Drawing.Point(80, 548);
            this.listPaymentButton.Margin = new System.Windows.Forms.Padding(2);
            this.listPaymentButton.Name = "listPaymentButton";
            this.listPaymentButton.Size = new System.Drawing.Size(152, 33);
            this.listPaymentButton.TabIndex = 9;
            this.listPaymentButton.Text = "Thông Tin Bill";
            this.listPaymentButton.UseVisualStyleBackColor = true;
            this.listPaymentButton.Click += new System.EventHandler(this.listPaymentButton_Click);
            // 
            // listBookedButton
            // 
            this.listBookedButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBookedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBookedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBookedButton.Location = new System.Drawing.Point(80, 503);
            this.listBookedButton.Margin = new System.Windows.Forms.Padding(2);
            this.listBookedButton.Name = "listBookedButton";
            this.listBookedButton.Size = new System.Drawing.Size(152, 33);
            this.listBookedButton.TabIndex = 8;
            this.listBookedButton.Text = "Chuyến Đi Đã Đặt";
            this.listBookedButton.UseVisualStyleBackColor = true;
            this.listBookedButton.Click += new System.EventHandler(this.listBookedButton_Click);
            // 
            // TourDTQButton
            // 
            this.TourDTQButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TourDTQButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TourDTQButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TourDTQButton.Location = new System.Drawing.Point(80, 456);
            this.TourDTQButton.Margin = new System.Windows.Forms.Padding(2);
            this.TourDTQButton.Name = "TourDTQButton";
            this.TourDTQButton.Size = new System.Drawing.Size(152, 33);
            this.TourDTQButton.TabIndex = 7;
            this.TourDTQButton.Text = "Tour DTQ";
            this.TourDTQButton.UseVisualStyleBackColor = true;
            this.TourDTQButton.Click += new System.EventHandler(this.TourDTQButton_Click);
            // 
            // TourHDVButton
            // 
            this.TourHDVButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TourHDVButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TourHDVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TourHDVButton.Location = new System.Drawing.Point(80, 411);
            this.TourHDVButton.Margin = new System.Windows.Forms.Padding(2);
            this.TourHDVButton.Name = "TourHDVButton";
            this.TourHDVButton.Size = new System.Drawing.Size(152, 33);
            this.TourHDVButton.TabIndex = 6;
            this.TourHDVButton.Text = "Hành Trình HDV";
            this.TourHDVButton.UseVisualStyleBackColor = true;
            this.TourHDVButton.Click += new System.EventHandler(this.TourHDVButton_Click);
            // 
            // employeeButton
            // 
            this.employeeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.employeeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.employeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeButton.Location = new System.Drawing.Point(80, 365);
            this.employeeButton.Margin = new System.Windows.Forms.Padding(2);
            this.employeeButton.Name = "employeeButton";
            this.employeeButton.Size = new System.Drawing.Size(152, 33);
            this.employeeButton.TabIndex = 5;
            this.employeeButton.Text = "Nhân Sự";
            this.employeeButton.UseVisualStyleBackColor = true;
            this.employeeButton.Click += new System.EventHandler(this.employeeButton_Click);
            // 
            // DTQButton
            // 
            this.DTQButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DTQButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DTQButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTQButton.Location = new System.Drawing.Point(80, 319);
            this.DTQButton.Margin = new System.Windows.Forms.Padding(2);
            this.DTQButton.Name = "DTQButton";
            this.DTQButton.Size = new System.Drawing.Size(152, 33);
            this.DTQButton.TabIndex = 4;
            this.DTQButton.Text = "Điểm Tham Quan";
            this.DTQButton.UseVisualStyleBackColor = true;
            this.DTQButton.Click += new System.EventHandler(this.DTQButton_Click);
            // 
            // HDVButton
            // 
            this.HDVButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HDVButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HDVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HDVButton.Location = new System.Drawing.Point(80, 273);
            this.HDVButton.Margin = new System.Windows.Forms.Padding(2);
            this.HDVButton.Name = "HDVButton";
            this.HDVButton.Size = new System.Drawing.Size(152, 33);
            this.HDVButton.TabIndex = 3;
            this.HDVButton.Text = "Hướng Dẫn Viên";
            this.HDVButton.UseVisualStyleBackColor = true;
            this.HDVButton.Click += new System.EventHandler(this.HDVButton_Click);
            // 
            // customerButton
            // 
            this.customerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerButton.Location = new System.Drawing.Point(80, 227);
            this.customerButton.Margin = new System.Windows.Forms.Padding(2);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(152, 33);
            this.customerButton.TabIndex = 2;
            this.customerButton.Text = "Khách Hàng";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // tourButton
            // 
            this.tourButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tourButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tourButton.Location = new System.Drawing.Point(80, 182);
            this.tourButton.Margin = new System.Windows.Forms.Padding(2);
            this.tourButton.Name = "tourButton";
            this.tourButton.Size = new System.Drawing.Size(152, 33);
            this.tourButton.TabIndex = 1;
            this.tourButton.Text = "Tour";
            this.tourButton.UseVisualStyleBackColor = true;
            this.tourButton.Click += new System.EventHandler(this.tourButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(75, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "DANH MỤC";
            // 
            // panel_thontintaikhoan
            // 
            this.panel_thontintaikhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_thontintaikhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(234)))), ((int)(((byte)(246)))));
            this.panel_thontintaikhoan.Controls.Add(this.chucVuLabel);
            this.panel_thontintaikhoan.Controls.Add(this.emailLabel);
            this.panel_thontintaikhoan.Controls.Add(this.fullNameLabel);
            this.panel_thontintaikhoan.Controls.Add(this.maNVLabel);
            this.panel_thontintaikhoan.Controls.Add(this.label10);
            this.panel_thontintaikhoan.Controls.Add(this.label9);
            this.panel_thontintaikhoan.Controls.Add(this.label8);
            this.panel_thontintaikhoan.Controls.Add(this.label7);
            this.panel_thontintaikhoan.Controls.Add(this.label6);
            this.panel_thontintaikhoan.Controls.Add(this.label5);
            this.panel_thontintaikhoan.Controls.Add(this.label4);
            this.panel_thontintaikhoan.Controls.Add(this.label3);
            this.panel_thontintaikhoan.Location = new System.Drawing.Point(566, 2);
            this.panel_thontintaikhoan.Margin = new System.Windows.Forms.Padding(2);
            this.panel_thontintaikhoan.Name = "panel_thontintaikhoan";
            this.panel_thontintaikhoan.Size = new System.Drawing.Size(405, 177);
            this.panel_thontintaikhoan.TabIndex = 0;
            this.panel_thontintaikhoan.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_thontintaikhoan_Paint);
            // 
            // chucVuLabel
            // 
            this.chucVuLabel.AutoSize = true;
            this.chucVuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chucVuLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.chucVuLabel.Location = new System.Drawing.Point(312, 133);
            this.chucVuLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.chucVuLabel.Name = "chucVuLabel";
            this.chucVuLabel.Size = new System.Drawing.Size(0, 18);
            this.chucVuLabel.TabIndex = 11;
            this.chucVuLabel.Text = nv.chuc_vu;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.emailLabel.Location = new System.Drawing.Point(201, 133);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(0, 18);
            this.emailLabel.TabIndex = 10;
            this.emailLabel.Text = nv.email;
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.fullNameLabel.Location = new System.Drawing.Point(111, 133);
            this.fullNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(0, 18);
            this.fullNameLabel.TabIndex = 9;
            this.fullNameLabel.Text = nv.full_name;
            // 
            // maNVLabel
            // 
            this.maNVLabel.AutoSize = true;
            this.maNVLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maNVLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.maNVLabel.Location = new System.Drawing.Point(28, 133);
            this.maNVLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maNVLabel.Name = "maNVLabel";
            this.maNVLabel.Size = new System.Drawing.Size(0, 18);
            this.maNVLabel.TabIndex = 8;
            this.maNVLabel.Text = nv.id;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label10.Location = new System.Drawing.Point(312, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = "Chức Vụ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label9.Location = new System.Drawing.Point(201, 98);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label8.Location = new System.Drawing.Point(111, 98);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 18);
            this.label8.TabIndex = 5;
            this.label8.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(28, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Mã NV";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(80, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Chúc Bạn Một Ngày Tốt Lành!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(143, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tên Nhân Viên";
            // 
            // label4
            // 
            this.label4.BackgroundImage = global::Manage_tour.Properties.Resources.user_thi;
            this.label4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.label4.Location = new System.Drawing.Point(22, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 41);
            this.label4.TabIndex = 1;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.label3.Location = new System.Drawing.Point(80, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Xin chào";
            // 
            // FormDashBroad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 811);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDashBroad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDashBroad";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_thontintaikhoan.ResumeLayout(false);
            this.panel_thontintaikhoan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel accountIcon;
        private System.Windows.Forms.Panel label4;
        private System.Windows.Forms.Panel logOutIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tourButton;
        private System.Windows.Forms.Button bookTourButton;
        private System.Windows.Forms.Button listPaymentButton;
        private System.Windows.Forms.Button listBookedButton;
        private System.Windows.Forms.Button TourDTQButton;
        private System.Windows.Forms.Button TourHDVButton;
        private System.Windows.Forms.Button employeeButton;
        private System.Windows.Forms.Button DTQButton;
        private System.Windows.Forms.Button HDVButton;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Panel panel_thontintaikhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label chucVuLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.Label maNVLabel;
        private System.Windows.Forms.Label label10;
        private NhanVienModel nv;
    }
}