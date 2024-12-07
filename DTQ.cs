using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manage_tour.DbQueries;

namespace Manage_tour
{
    public partial class DTQ : Panel
    {
        private bool isEditMode = false;

        public DTQ()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            loadDataDTQ();
            dataGridViewDTQ.ClearSelection();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Search(keyword);
        }

        private void Search(string keyword)
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridViewDTQ.Rows.Clear();
            foreach (object[] row in DiemThamQuanModel.selectLikeKey(keyword))
            {
                dataGridViewDTQ.Rows.Add(row);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột là "Sửa"
            if (dataGridViewDTQ.Columns["Edit"] != null && e.ColumnIndex == dataGridViewDTQ.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string DTQID = dataGridViewDTQ.Rows[e.RowIndex].Cells["DTQID"].Value.ToString();

                // Gọi hàm để xử lý sửa

                EditDTQ(DTQID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridViewDTQ.Columns["Del"] != null && e.ColumnIndex == dataGridViewDTQ.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string DTQID = dataGridViewDTQ.Rows[e.RowIndex].Cells["DTQID"].Value.ToString();

                MessageBox.Show($"{DeleteTour(DTQID)} DTQ deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
            }

            if (e.RowIndex < 0) return;

        }

        private void EditDTQ(string DTQID)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
            isEditMode = true;
            DiemThamQuanModel DTQ= DiemThamQuanModel.selectByKey(DTQID);

            txtDTQID.Text = DTQ.ma_diem_tham_quan;
            txtDTQName.Text= DTQ.ten_dia_diem;
            txtAddress.Text = DTQ.dia_chi;

            txtDTQID.Enabled = false;
        }

        private void AdjustDataGridView()
        {
            // Tính toán chiều cao khả dụng cho DataGridView
            int availableHeight = 400; // 20 là khoảng cách trống phía dưới

            if (tableLayoutPanel1.Visible)
            {
                // Nếu bảng hiển thị, giảm chiều cao DataGridView
                ADD.Visible = false;
                dataGridViewDTQ.Height = availableHeight - tableLayoutPanel1.Height + 100; // Giảm thêm để có khoảng trống nút Add
            }
            else
            {
                // Nếu bảng ẩn, tăng chiều cao DataGridView
                ADD.Visible = true;
                dataGridViewDTQ.Height = availableHeight;
            }

            // Cập nhật vị trí nút Add dựa trên DataGridView
            ADD.Top = dataGridViewDTQ.Bottom + 5; // Cách DataGridView 10px

            ClearInputFields();
        }
        private void ClearInputFields()
        {
            txtDTQID.Text = String.Empty;
            txtDTQName.Text = String.Empty;
            txtAddress.Text = String.Empty;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String DTQID = txtDTQID.Text;
            String DTQName = txtDTQName.Text;
            String Address = txtAddress.Text;

            
            if (string.IsNullOrEmpty(DTQID) || string.IsNullOrEmpty(DTQName) || string.IsNullOrEmpty(Address))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }



            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                UpdateDTQ(); // Cập nhật tour
                AdjustDataGridView();
            }
            else
            {
                AddDTQ(DTQID, DTQName, Address); // Thêm mới tour
            }

            isEditMode = false;
            txtDTQID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            loadDataDTQ();
        }

        private void UpdateDTQ()
        {
            DiemThamQuanModel.update(txtDTQName.Text, txtAddress.Text, txtDTQID.Text);
        }

        private void AddDTQ(String DTQID, String DTQName, String Address)
        {
            DiemThamQuanModel.insert(DTQID, DTQName, Address);
        }

        private int DeleteTour(string idDTQ)
        {
            int rowAffected = DiemThamQuanModel.delete(idDTQ);
            loadDataDTQ();
            return rowAffected;
        }

        private void loadDataDTQ()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridViewDTQ.Rows.Clear();
            foreach (object[] row in DiemThamQuanModel.selectAll())
            {
                dataGridViewDTQ.Rows.Add(row);
            }
        }
        private void ADD_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewDTQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột là "Sửa"
            if (dataGridViewDTQ.Columns["Edit"] != null && e.ColumnIndex == dataGridViewDTQ.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string DTQID = dataGridViewDTQ.Rows[e.RowIndex].Cells["DTQID"].Value.ToString();

                // Gọi hàm để xử lý sửa

                EditDTQ(DTQID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridViewDTQ.Columns["Del"] != null && e.ColumnIndex == dataGridViewDTQ.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string DTQID = dataGridViewDTQ.Rows[e.RowIndex].Cells["DTQID"].Value.ToString();

                MessageBox.Show($"{DeleteTour(DTQID)} DTQ deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
        }
    }
}
