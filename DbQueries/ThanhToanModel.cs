using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class ThanhToanModel
    {
        public ThanhToanModel(SqlDataReader reader)
        {
            ma_thanh_toan = reader["ma_thanh_toan"].ToString();  
            ma_dat_tour = reader["ma_dat_tour"].ToString();  
            ngay_thanh_toan = reader["ngay_thanh_toan"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_thanh_toan"]) : DateTime.MinValue;  
            hinh_thuc = reader["hinh_thuc"].ToString();  
            tong_tien = reader["tong_tien"] != DBNull.Value ? Convert.ToDecimal(reader["tong_tien"]) : 0;  
        }


        public ThanhToanModel(string Ma_thanh_toan, string Ma_dat_tour, DateTime Ngay_thanh_toan, string Hinh_thuc, decimal Tong_tien)
        {
            ma_thanh_toan = Ma_thanh_toan;
            ma_dat_tour = Ma_dat_tour;
            ngay_thanh_toan = Ngay_thanh_toan;
            hinh_thuc = Hinh_thuc;
            tong_tien = Tong_tien;
        }

        public string ma_thanh_toan { get; set; } 
        public string ma_dat_tour { get; set; } 
        public DateTime ngay_thanh_toan { get; set; }  
        public string hinh_thuc { get; set; }  
        public decimal tong_tien { get; set; }  
    }
}
