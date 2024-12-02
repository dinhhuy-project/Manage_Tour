using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Manage_tour.DbQueries
{
    public class Tour
    {
        public Tour(SqlDataReader reader)
        {
            ma_tour = reader["ma_tour"].ToString();  
            ten_tour = reader["ten_tour"].ToString();  
            gia = reader["gia"] != DBNull.Value ? Convert.ToDecimal(reader["gia"]) : 0;
            ngay_bd = reader["ngay_bd"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_bd"]) : DateTime.MinValue;
            ngay_kt = reader["ngay_kt"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_kt"]) : DateTime.MinValue;
        }

        public Tour(string Ma_tour, string Ten_tour, string Gia, string Ngay_bd, string Ngay_kt)
        {
            ma_tour = Ma_tour;
            ten_tour = Ten_tour;

            // Chuyển đổi string Gia thành decimal
            gia = !string.IsNullOrEmpty(Gia) ? Convert.ToDecimal(Gia) : 0;

            // Chuyển đổi string Ngay_bd và Ngay_kt thành DateTime
            ngay_bd = !string.IsNullOrEmpty(Ngay_bd) ? Convert.ToDateTime(Ngay_bd) : DateTime.MinValue;
            ngay_kt = !string.IsNullOrEmpty(Ngay_kt) ? Convert.ToDateTime(Ngay_kt) : DateTime.MinValue;
        }

        public string ma_tour { get; set; }
        public string ten_tour { get; set; }
        public decimal gia { get; set; }
        public DateTime ngay_bd { get; set; }
        public DateTime ngay_kt { get; set; }
    }
}
