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

    }
}
