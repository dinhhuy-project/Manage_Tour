using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manage_tour.DbQueries;

namespace Manage_tour
{
    public partial class Employee : Panel
    {
        public Employee()
        {
            InitializeComponent();
            dataGridView1.ClearSelection();
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            loadData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in NhanVienModel.selectAll())
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[5]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Del")
            {
                // Lấy thông tin từ hàng được chọn
                string ID = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                
                // Xác nhận xoá
                var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi hàm xoá
                    MessageBox.Show($"{DeleteEmployee(ID)} tourDTQ(s) deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int DeleteEmployee(string ID)
        {
            int rowAffected = NhanVienModel.delete(ID);
            loadData();
            return rowAffected;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy mã tour từ cột ma_tour
                string ID = row.Cells["ID"].Value?.ToString();
                
                if (!string.IsNullOrEmpty(ID))
                {
                    // Gọi phương thức EditTour để tải dữ liệu chi tiết
                    EditEmployee(ID);
                }
            }
        }

        private void EditEmployee(String ID)
        {
            NhanVienModel nv = NhanVienModel.selectByKey(ID);

            txtID.Text = nv.id;
            txtName.Text = nv.full_name;
            textCCCD.Text = nv.cccd;
            textEmail.Text = nv.email;
            txtRole.Text = nv.chuc_vu;

            txtID.Enabled = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String ID = txtID.Text;
            String Name = txtName.Text;
            String CCCD = textCCCD.Text;
            String Email=textEmail.Text;
            String Role = txtRole.Text;

            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(CCCD) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Role) )
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            UpdateEmployee();
            ClearInputFields();
            loadData();
        }

        private void UpdateEmployee()
        {
            NhanVienModel.update(txtName.Text, textCCCD.Text, textEmail.Text, txtRole.Text, txtID.Text);
        }

        private void ClearInputFields()
        {
            txtID.Text = string.Empty; ;
            txtName.Text = string.Empty; ;
            textCCCD.Text = string.Empty; ;
            textEmail.Text = string.Empty; ;
            txtRole.Text = string.Empty; ;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                loadData();
                return;
            }

            SearchEmployee(keyword);
        }

        private void SearchEmployee(string keyword)
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in NhanVienModel.selectLikeKey(keyword))
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[5]);
            }
        }
    }
}
