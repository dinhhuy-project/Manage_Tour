using System;
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
    public partial class HDV : Panel
    {
        private bool isEditMode = false;

        public HDV()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            //LoadData();
            dataGridViewHDV.ClearSelection();
            dataGridViewHDV.CellContentClick += dataGridViewHDV_CellContentClick;
        }

        

        private void SearchHDV_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Search(keyword);
        }

        private void dataGridViewHDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột là "Sửa"
            if (dataGridViewHDV.Columns["Edit"] != null && e.ColumnIndex == dataGridViewHDV.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string GuideID = dataGridViewHDV.Rows[e.RowIndex].Cells["GuideID"].Value.ToString();

                // Gọi hàm để xử lý sửa

                //EditHDV(GuideID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridViewHDV.Columns["Del"] != null && e.ColumnIndex == dataGridViewHDV.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string GuideID = dataGridViewHDV.Rows[e.RowIndex].Cells["GuideID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this attraction?",
                         "Delete Confirmation",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    //DeleteHDV(GuideID);
                }


            }

        }
        private void AdjustDataGridView()
        {
            // Tính toán chiều cao khả dụng cho DataGridView
            int availableHeight = 400; // 20 là khoảng cách trống phía dưới

            if (tableLayoutPanel1.Visible)
            {
                ADD.Visible = false;
                dataGridViewHDV.Height = availableHeight - tableLayoutPanel1.Height + 100; // Giảm thêm để có khoảng trống nút Add
            }
            else
            {
                // Nếu bảng ẩn, tăng chiều cao DataGridView
                ADD.Visible = true;
                dataGridViewHDV.Height = availableHeight;
            }

            // Cập nhật vị trí nút Add dựa trên DataGridView
            ADD.Top = dataGridViewHDV.Bottom + 5; // Cách DataGridView 10px

            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtGuideID.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtCCCD.Text = String.Empty;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String GuideID = txtGuideID.Text;
            String FullName = txtFullName.Text;
            String CCCD = txtCCCD.Text;


            if (string.IsNullOrEmpty(GuideID) || string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(CCCD))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }



            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                //UpdateHDV(); // Cập nhật tour
                AdjustDataGridView();
            }
            else
            {
                //AddHDV(GuideID, FullName, CCCD); // Thêm mới tour
            }

            isEditMode = false;
            txtGuideID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
        }
    }
}
