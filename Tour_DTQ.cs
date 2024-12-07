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
    public partial class Tour_DTQ : Panel
    {
        private bool isEditMode = false;
        private string Old_DTQ = null;

        public Tour_DTQ()
        {
            InitializeComponent();
            dataGridView2.ClearSelection();
            // Đăng ký sự kiện CellClick
            dataGridView2.CellClick += dataGridView2_CellClick;
            loadDataTourDTQ();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Lấy mã tour từ cột ma_tour
                string tourId = row.Cells["TourID1"].Value?.ToString();
                string DTQId=row.Cells["DTQID1"].Value?.ToString();
                Old_DTQ = DTQId;
                if (!string.IsNullOrEmpty(tourId))
                {
                    // Gọi phương thức EditTour để tải dữ liệu chi tiết
                    isEditMode = true;
                    EditTourDTQ(tourId,DTQId);
                }
            }
        }

        private void EditTourDTQ(String tourId, String DTQid)
        {
            TourDTQModel TourDTQ= TourDTQModel.selectByKey(tourId,DTQid);

            txtTourID.Text = TourDTQ.ma_tour;
            txtDTQ.Text = TourDTQ.ma_diem_tham_quan;

            txtTourID.Enabled=false;

            
        }

        private void Tour_DTQ_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String TourID = txtTourID.Text;
            String DTQID = txtDTQ.Text;
            

            
            if (string.IsNullOrEmpty(TourID) || string.IsNullOrEmpty(DTQID))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }


            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                UpdateTourDTQ(); // Cập nhật tour
            }
            else
            {
                AddTourDTQ(TourID, DTQID); // Thêm mới tour
            }

            isEditMode = false;
            txtTourID.Enabled = true;
            ClearInputFields();
            loadDataTourDTQ();
        }

        private void UpdateTourDTQ()
        {
            TourDTQModel.update(txtDTQ.Text, txtTourID.Text,Old_DTQ);
        }
        private void AddTourDTQ(String TourID, String DTQID)
        {
            TourDTQModel.insert(TourID, DTQID);
        }

        private void ClearInputFields()
        {
            txtTourID.Text = String.Empty;
            txtDTQ.Text = String.Empty;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchID(keyword);
        }

        private void SearchID(string keyword)
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView2.Rows.Clear();
            foreach (object[] row in TourDTQModel.selectLikeKey(keyword))
            {
                dataGridView2.Rows.Add(row);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtTourID.Enabled = true;
            isEditMode = false;
            loadDataTourDTQ();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "DEL1")
            {
                // Lấy thông tin từ hàng được chọn
                string tourId = dataGridView2.Rows[e.RowIndex].Cells["TourID1"].Value.ToString();
                string DTQid = dataGridView2.Rows[e.RowIndex].Cells["DTQID1"].Value.ToString();
                // Xác nhận xoá
                var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi hàm xoá
                    MessageBox.Show($"{DeleteTourDTQ(tourId, DTQid)} tourDTQ(s) deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int DeleteTourDTQ(string tourId, string DTQid)
        {
            int rowAffected = TourDTQModel.delete(tourId,DTQid);
            loadDataTourDTQ();
            ClearInputFields();
            return rowAffected;
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadDataTourDTQ()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView2.Rows.Clear();
            foreach (object[] row in TourDTQModel.selectAll())
            {
                dataGridView2.Rows.Add(row);
            }
        }
    }
}
