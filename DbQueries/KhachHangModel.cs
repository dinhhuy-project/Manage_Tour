using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class KhachHangModel
    {
        public KhachHangModel(SqlDataReader reader)
        {
            ma_kh = reader["ma_kh"].ToString();  
            ten_kh = reader["ten_kh"].ToString(); 
            sdt = reader["sdt"].ToString(); 
            cccd = reader["cccd"].ToString(); 
            dia_chi = reader["dia_chi"].ToString(); 
        }

        public KhachHangModel(string Ma_kh, string Ten_kh, string Sdt, string Cccd, string Dia_chi)
        {
            ma_kh = Ma_kh;
            ten_kh = Ten_kh;
            sdt = Sdt;
            cccd = Cccd;
            dia_chi = Dia_chi;
        }

        public string ma_kh { get; set; }  
        public string ten_kh { get; set; }  
        public string sdt { get; set; }  
        public string cccd { get; set; } 
        public string dia_chi { get; set; } 
    }
}
