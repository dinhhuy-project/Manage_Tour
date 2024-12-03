using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_tour
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
            panel_chuyenkhoan.Visible = false;
            panel_viettinbank.Visible = false;
            panel_bidv.Visible = false;
        }
      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void payment_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu checkbox "chuyển khoản" được chọn
            if (checkBox_chuyenkhoan.Checked)
            {
                checkBox_tienmat.Checked = false; // Bỏ chọn checkbox "tiền mặt"
                panel_chuyenkhoan.Visible = true; // Hiển thị panel chuyển khoản
            }
            else
            {
                panel_chuyenkhoan.Visible = false; // Ẩn panel chuyển khoản
                panel_bidv.Visible=false;
                panel_viettinbank.Visible=false;
            }
        }

        private void checkBox_tienmat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_tienmat.Checked)
            {
                checkBox_chuyenkhoan.Checked = false;
            }
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel_viettinbank_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox_viettinbank_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_viettinbank.Checked) 
            {
                checkBox_bidv.Checked = false; 
                panel_viettinbank.Visible = true; 
                panel_bidv.Visible = false; 
            }
            else 
            {
                panel_viettinbank.Visible = false; 
            }
        }

        private void checkBox_bidv_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_bidv.Checked)
            {
                checkBox_viettinbank.Checked = false;
                panel_bidv.Visible = true;
                panel_viettinbank.Visible = false;
            }
            else
            {
                panel_bidv.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
