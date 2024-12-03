using Manage_tour.DbQueries;
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
    public partial class FormDashBroad : Form
    {
        private Panel childPanel;
        string currentButton;
        public FormDashBroad(NhanVienModel nhanVien)
        {
            InitializeComponent(nhanVien);
            panel_thontintaikhoan.Visible = false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Thoát toàn bộ ứng dụng khi form này bị đóng
            Application.Exit();
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

        private void panel_thontintaikhoan_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool isPanelVisible = false; //theo doi bam chuot
        private void panel2_Click(object sender, EventArgs e)
        {
            // bam de hien thi thongtintaikhoan
            isPanelVisible = !isPanelVisible;
            panel_thontintaikhoan.Visible = isPanelVisible;
        }

        private void logOutIcon_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị form mới
            Entrymain newForm = new Entrymain();
            newForm.Show();

            // Tắt form hiện tại
            this.Hide();
        }

        private void tourButton_Click(object sender, EventArgs e)
        {
            if (currentButton == tourButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new Tour();
                currentButton = tourButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            if (currentButton == customerButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new customer();
                currentButton = customerButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void HDVButton_Click(object sender, EventArgs e)
        {
            if (currentButton == HDVButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new HDV();
                currentButton = HDVButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void DTQButton_Click(object sender, EventArgs e)
        {
            if (currentButton == DTQButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new DTQ();
                currentButton = DTQButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void TourHDVButton_Click(object sender, EventArgs e)
        {
            if (currentButton == TourHDVButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new Tour_HDV();
                currentButton = TourHDVButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void TourDTQButton_Click(object sender, EventArgs e)
        {
            if (currentButton == TourDTQButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new Tour_DTQ();
                currentButton = TourDTQButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void listBookedButton_Click(object sender, EventArgs e)
        {
            if (currentButton == listBookedButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new listbooked();
                currentButton = listBookedButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void bookTourButton_Click(object sender, EventArgs e)
        {
            if (currentButton == bookTourButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new booktour();
                currentButton = bookTourButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void listPaymentButton_Click(object sender, EventArgs e)
        {
            if (currentButton == listPaymentButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new listpayment();
                currentButton = listPaymentButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }

        private void employeeButton_Click(object sender, EventArgs e)
        {
            if (currentButton == employeeButton.Text)
            {
                this.splitContainer1.Panel2.Controls.Remove(childPanel);
                currentButton = "";
            }
            else
            {
                if (this.splitContainer1.Panel2.Contains(childPanel))
                {
                    this.splitContainer1.Panel2.Controls.Remove(childPanel);
                }
                childPanel = new Employee();
                currentButton = employeeButton.Text;
                this.splitContainer1.Panel2.Controls.Add(childPanel);
            }
        }
    }
}
