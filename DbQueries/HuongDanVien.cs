using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class HuongDanVien
    {
        public HuongDanVien(SqlDataReader reader)
        {
            ma_hdv = reader["ma_hdv"].ToString();
            full_name = reader["full_name"].ToString();
            cccd = reader["cccd"].ToString();
            sdt = reader["sdt"].ToString();
            diachi = reader["diachi"].ToString();
        }
        public HuongDanVien(string Ma_hdv, string Fullname, string Cccd, string Sdt, string Diachi)
        {
            ma_hdv = Ma_hdv;
            full_name = Fullname;
            cccd = Cccd;
            sdt = Sdt;
            diachi = Diachi;
        }

        public string ma_hdv { get; set; }
        public string full_name { get; set; }
        public string cccd { get; set; }
        public string sdt { get; set; }
        public string diachi { get; set; }
    }
}
