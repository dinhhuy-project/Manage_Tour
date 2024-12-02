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
    public partial class Entrymain : Form
    {
        public Entrymain()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Thoát toàn bộ ứng dụng khi form này bị đóng
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logInButton_Click(object sender, EventArgs e)
        {

            // Tạo và hiển thị form mới
            FormSignUp newForm = new FormSignUp();
            newForm.Show();
            newForm.panel_signin.Visible = true;
            newForm.panel_signup.Visible = false;

            // Tắt form hiện tại
            this.Hide();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị form mới
            FormSignUp newForm = new FormSignUp();
            newForm.Show();
            newForm.panel_signin.Visible = false;
            newForm.panel_signup.Visible = true;

            // Tắt form hiện tại
            this.Hide();
        }
    }
}
