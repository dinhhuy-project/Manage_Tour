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
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
            panel_signup.Visible = false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Thoát toàn bộ ứng dụng khi form này bị đóng
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void changeToSignUpButton_Click(object sender, EventArgs e)
        {
            panel_signup.Visible = true;
            panel_signin.Visible = false;
        }

        private void changeToSignInButton_Click(object sender, EventArgs e)
        {
            panel_signin.Visible = true;
            panel_signup.Visible = false;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            NhanVienModel nv = null;
            nv = DbQueries.Queries.logIn(signInEmailTextbox.Text, signInPasswordTextbox.Text);
            if (nv != null)
            {
                // Tạo và hiển thị form mới
                FormDashBroad newForm = new FormDashBroad(nv);
                newForm.Show();

                // Tắt form hiện tại
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong email or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if(DbQueries.Queries.signUp(nameTextbox.Text, identificationCardTextbox.Text, signUpEmailTextbox.Text, signUpPasswordTextbox.Text))
            {
                MessageBox.Show("Sign up successful", "True", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel_signin.Visible = true;
                panel_signup.Visible = false;
            }
            else
            {
                MessageBox.Show("Can't sign up!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
