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
        public FormDashBroad(NhanVien nhanVien)
        {
            InitializeComponent();
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
    }
}
