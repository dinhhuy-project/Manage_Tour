using Manage_tour.DbQueries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Manage_tour
{
    public partial class Tour : Panel
    {
        public Tour()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            loadData();
            dataGridView1.ClearSelection();
        }
        private bool isEditMode = false;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            // Kiểm tra nếu cột là "Sửa"
            if (dataGridView1.Columns["Edit"] != null && e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string tourId = dataGridView1.Rows[e.RowIndex].Cells["TourID"].Value.ToString();

                // Gọi hàm để xử lý sửa
                //EditTour(tourId);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridView1.Columns["Del"] != null && e.ColumnIndex == dataGridView1.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string tourId = dataGridView1.Rows[e.RowIndex].Cells["TourID"].Value.ToString();

                // Gọi hàm để xử lý xoá
                //DeleteTour(tourId);
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void AdjustDataGridView()
        {
            // Tính toán chiều cao khả dụng cho DataGridView
            int availableHeight = 400; // 20 là khoảng cách trống phía dưới

            if (tableLayoutPanel1.Visible)
            {
                // Nếu bảng hiển thị, giảm chiều cao DataGridView
                ADD.Visible = false;
                dataGridView1.Height = availableHeight - tableLayoutPanel1.Height + 100; // Giảm thêm để có khoảng trống nút Add
            }
            else
            {
                // Nếu bảng ẩn, tăng chiều cao DataGridView
                ADD.Visible = true;
                dataGridView1.Height = availableHeight;
            }

            // Cập nhật vị trí nút Add dựa trên DataGridView
            ADD.Top = dataGridView1.Bottom + 10; // Cách DataGridView 10px

            ClearInputFields();
        }   

        private void ClearInputFields()
        {
            txtTourID.Text = string.Empty;
            txtTourName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            String TourID = txtTourID.Text;
            String TourName = txtTourName.Text;
            DateTime startDateT = startDate.Value;
            DateTime endDateT = endDate.Value;
            float PriceT;

            // Kiểm tra nếu các trường tourID và tourName bị rỗng
            if (string.IsNullOrEmpty(TourID) || string.IsNullOrEmpty(TourName))
            {
                    MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }


            // Kiểm tra nếu ngày bắt đầu lớn hơn ngày kết thúc
            if (startDateT > endDateT)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                return;
            }

            // Kiểm tra giá trị Price hợp lệ
            try
            {
                PriceT = float.Parse(txtPrice.Text);

                if (PriceT <= 0)
                {
                    MessageBox.Show("The tour price must be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid tour price!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                //UpdateTour(); // Cập nhật tour
                AdjustDataGridView();
            }
            else
            {
                //AddTour(TourID, TourName, startDateT, endDateT, PriceT); // Thêm mới tour
            }

            isEditMode = false;
            txtTourID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //SearchTours(keyword);
        }

        private void loadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in TourModel.selectByKey("tour02"))
            {
                dataGridView1.Rows.Add(row);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
