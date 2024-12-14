using System.Windows.Forms;

namespace Manage_tour
{
    partial class Tour_HDV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtGuideID = new System.Windows.Forms.TextBox();
            this.txtTourID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.box = new System.Windows.Forms.GroupBox();
            this.Addresstxt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PhoneNumbertxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.CCCDtxt = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.GuideNametxt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.GuideIDtxt = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.EDtxt = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SDtxt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Pricetxt = new System.Windows.Forms.Label();
            this.TourNametxt = new System.Windows.Forms.Label();
            this.TourIDtxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.TourID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuideID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEL1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(125, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 448);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.box);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(677, 398);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtGuideID);
            this.groupBox3.Controls.Add(this.txtTourID);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 401);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Form input";
            // 
            // txtGuideID
            // 
            this.txtGuideID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuideID.Location = new System.Drawing.Point(87, 135);
            this.txtGuideID.Name = "txtGuideID";
            this.txtGuideID.Size = new System.Drawing.Size(129, 26);
            this.txtGuideID.TabIndex = 5;
            // 
            // txtTourID
            // 
            this.txtTourID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTourID.Location = new System.Drawing.Point(87, 70);
            this.txtTourID.Name = "txtTourID";
            this.txtTourID.Size = new System.Drawing.Size(129, 26);
            this.txtTourID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Guide ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "TourID";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(130, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSave.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(22, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // box
            // 
            this.box.BackColor = System.Drawing.Color.White;
            this.box.Controls.Add(this.Addresstxt);
            this.box.Controls.Add(this.label6);
            this.box.Controls.Add(this.PhoneNumbertxt);
            this.box.Controls.Add(this.label1);
            this.box.Controls.Add(this.button1);
            this.box.Controls.Add(this.label20);
            this.box.Controls.Add(this.CCCDtxt);
            this.box.Controls.Add(this.label18);
            this.box.Controls.Add(this.GuideNametxt);
            this.box.Controls.Add(this.label16);
            this.box.Controls.Add(this.GuideIDtxt);
            this.box.Controls.Add(this.label14);
            this.box.Controls.Add(this.EDtxt);
            this.box.Controls.Add(this.label12);
            this.box.Controls.Add(this.SDtxt);
            this.box.Controls.Add(this.label10);
            this.box.Controls.Add(this.label9);
            this.box.Controls.Add(this.Pricetxt);
            this.box.Controls.Add(this.TourNametxt);
            this.box.Controls.Add(this.TourIDtxt);
            this.box.Controls.Add(this.label5);
            this.box.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box.Location = new System.Drawing.Point(0, -3);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(451, 405);
            this.box.TabIndex = 2;
            this.box.TabStop = false;
            this.box.Text = "Detail Information";
            // 
            // Addresstxt
            // 
            this.Addresstxt.AutoSize = true;
            this.Addresstxt.Location = new System.Drawing.Point(188, 339);
            this.Addresstxt.Name = "Addresstxt";
            this.Addresstxt.Size = new System.Drawing.Size(131, 21);
            this.Addresstxt.TabIndex = 21;
            this.Addresstxt.Text = " Phone Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 21);
            this.label6.TabIndex = 20;
            this.label6.Text = "Address :";
            // 
            // PhoneNumbertxt
            // 
            this.PhoneNumbertxt.AutoSize = true;
            this.PhoneNumbertxt.Location = new System.Drawing.Point(188, 306);
            this.PhoneNumbertxt.Name = "PhoneNumbertxt";
            this.PhoneNumbertxt.Size = new System.Drawing.Size(71, 21);
            this.PhoneNumbertxt.TabIndex = 19;
            this.PhoneNumbertxt.Text = "CCCD :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = " Phone Number:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(382, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 32);
            this.button1.TabIndex = 17;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(33, 272);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 21);
            this.label20.TabIndex = 16;
            this.label20.Text = "CCCD :";
            // 
            // CCCDtxt
            // 
            this.CCCDtxt.AutoSize = true;
            this.CCCDtxt.Location = new System.Drawing.Point(188, 272);
            this.CCCDtxt.Name = "CCCDtxt";
            this.CCCDtxt.Size = new System.Drawing.Size(79, 21);
            this.CCCDtxt.TabIndex = 15;
            this.CCCDtxt.Text = "Tour ID :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(31, 240);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 21);
            this.label18.TabIndex = 14;
            this.label18.Text = "GuideName  :";
            // 
            // GuideNametxt
            // 
            this.GuideNametxt.AutoSize = true;
            this.GuideNametxt.Location = new System.Drawing.Point(188, 240);
            this.GuideNametxt.Name = "GuideNametxt";
            this.GuideNametxt.Size = new System.Drawing.Size(79, 21);
            this.GuideNametxt.TabIndex = 13;
            this.GuideNametxt.Text = "Tour ID :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 21);
            this.label16.TabIndex = 12;
            this.label16.Text = "Guide ID :";
            // 
            // GuideIDtxt
            // 
            this.GuideIDtxt.AutoSize = true;
            this.GuideIDtxt.Location = new System.Drawing.Point(188, 205);
            this.GuideIDtxt.Name = "GuideIDtxt";
            this.GuideIDtxt.Size = new System.Drawing.Size(79, 21);
            this.GuideIDtxt.TabIndex = 11;
            this.GuideIDtxt.Text = "Tour ID :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 171);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 21);
            this.label14.TabIndex = 10;
            this.label14.Text = "End Date :";
            // 
            // EDtxt
            // 
            this.EDtxt.AutoSize = true;
            this.EDtxt.Location = new System.Drawing.Point(188, 171);
            this.EDtxt.Name = "EDtxt";
            this.EDtxt.Size = new System.Drawing.Size(79, 21);
            this.EDtxt.TabIndex = 9;
            this.EDtxt.Text = "Tour ID :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 21);
            this.label12.TabIndex = 8;
            this.label12.Text = "Start Date :";
            // 
            // SDtxt
            // 
            this.SDtxt.AutoSize = true;
            this.SDtxt.Location = new System.Drawing.Point(188, 135);
            this.SDtxt.Name = "SDtxt";
            this.SDtxt.Size = new System.Drawing.Size(79, 21);
            this.SDtxt.TabIndex = 7;
            this.SDtxt.Text = "Tour ID :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 21);
            this.label10.TabIndex = 6;
            this.label10.Text = "Tour Name :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "Price :";
            // 
            // Pricetxt
            // 
            this.Pricetxt.AutoSize = true;
            this.Pricetxt.Location = new System.Drawing.Point(188, 103);
            this.Pricetxt.Name = "Pricetxt";
            this.Pricetxt.Size = new System.Drawing.Size(79, 21);
            this.Pricetxt.TabIndex = 4;
            this.Pricetxt.Text = "Tour ID :";
            // 
            // TourNametxt
            // 
            this.TourNametxt.AutoSize = true;
            this.TourNametxt.Location = new System.Drawing.Point(188, 69);
            this.TourNametxt.Name = "TourNametxt";
            this.TourNametxt.Size = new System.Drawing.Size(79, 21);
            this.TourNametxt.TabIndex = 3;
            this.TourNametxt.Text = "Tour ID :";
            // 
            // TourIDtxt
            // 
            this.TourIDtxt.AutoSize = true;
            this.TourIDtxt.Location = new System.Drawing.Point(188, 35);
            this.TourIDtxt.Name = "TourIDtxt";
            this.TourIDtxt.Size = new System.Drawing.Size(79, 21);
            this.TourIDtxt.TabIndex = 2;
            this.TourIDtxt.Text = "Tour ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tour ID :";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TourID1,
            this.GuideID1,
            this.DEL1});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(445, 398);
            this.dataGridView2.TabIndex = 0;
            // 
            // TourID1
            // 
            this.TourID1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TourID1.HeaderText = "TourID";
            this.TourID1.Name = "TourID1";
            this.TourID1.ReadOnly = true;
            // 
            // GuideID1
            // 
            this.GuideID1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GuideID1.HeaderText = "GuideID";
            this.GuideID1.Name = "GuideID1";
            this.GuideID1.ReadOnly = true;
            // 
            // DEL1
            // 
            this.DEL1.HeaderText = "Del";
            this.DEL1.Image = global::Manage_tour.Properties.Resources.Group_68;
            this.DEL1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DEL1.Name = "DEL1";
            this.DEL1.ReadOnly = true;
            this.DEL1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DEL1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DEL1.Width = 50;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtKeyword);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 44);
            this.panel2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(453, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 27);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(228, 7);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(209, 26);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Tour_HDV
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.panel1);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Size = new System.Drawing.Size(879, 526);
            this.Text = "Tour_HDV";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.box.ResumeLayout(false);
            this.box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtGuideID;
        private System.Windows.Forms.TextBox txtTourID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.GroupBox groupBox1;
        private GroupBox box;
        private Button button1;
        private Label label20;
        private Label CCCDtxt;
        private Label label18;
        private Label GuideNametxt;
        private Label label16;
        private Label GuideIDtxt;
        private Label label14;
        private Label EDtxt;
        private Label label12;
        private Label SDtxt;
        private Label label10;
        private Label label9;
        private Label Pricetxt;
        private Label TourNametxt;
        private Label TourIDtxt;
        private Label label5;
        private Label Addresstxt;
        private Label label6;
        private Label PhoneNumbertxt;
        private Label label1;
        private DataGridViewTextBoxColumn TourID1;
        private DataGridViewTextBoxColumn GuideID1;
        private DataGridViewImageColumn DEL1;
    }
}