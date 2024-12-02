using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class DatTour
    {
        public DatTour(SqlDataReader reader)
        {
            ma_dat_tour = reader["ma_dat_tour"].ToString();  
            ma_tour = reader["ma_tour"].ToString(); 
            ma_kh = reader["ma_kh"].ToString();  
            ngay_dat = reader["ngay_dat"] != DBNull.Value ? Convert.ToDateTime(reader["ngay_dat"]) : DateTime.MinValue;  
            so_luong_nguoi = reader["so_luong_nguoi"] != DBNull.Value ? Convert.ToInt32(reader["so_luong_nguoi"]) : 0;  
            tong_tien = reader["tong_tien"] != DBNull.Value ? Convert.ToDecimal(reader["tong_tien"]) : 0; 
            trang_thai = reader["trang_thai"].ToString();  
        }

        public DatTour(string Ma_dat_tour, string Ma_tour, string Ma_kh, DateTime Ngay_dat, int So_luong_nguoi, decimal Tong_tien, string Trang_thai)
        {
            ma_dat_tour = Ma_dat_tour;
            ma_tour = Ma_tour;
            ma_kh = Ma_kh;
            ngay_dat = Ngay_dat;
            so_luong_nguoi = So_luong_nguoi;
            tong_tien = Tong_tien;
            trang_thai = Trang_thai;
        }

        public string ma_dat_tour { get; set; }  
        public string ma_tour { get; set; }  
        public string ma_kh { get; set; }  
        public DateTime ngay_dat { get; set; }  
        public int so_luong_nguoi { get; set; } 
        public decimal tong_tien { get; set; }  
        public string trang_thai { get; set; }  
    }
}
