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
    public partial class listpayment : Panel
    {
        public listpayment()
        {
            InitializeComponent();
            loadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in ThanhToanModel.selectAll())
            {
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Tìm kiếm theo mã đặt tour, mã tour hoặc mã khách hàng
                SearchTours(searchTerm);
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, tải lại tất cả dữ liệu
                loadData();
            }
        }
        private void SearchTours(string keyword)
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in ThanhToanModel.selectLikeKey(keyword))
            {
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
