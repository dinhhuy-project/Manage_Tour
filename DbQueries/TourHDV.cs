using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class TourHDV
    {
        public TourHDV(SqlDataReader reader)
        {
            ma_tour = reader["ma_tour"].ToString();  
            ma_hdv = reader["ma_hdv"].ToString();  
        }
        public TourHDV(string Ma_tour, string Ma_hdv)
        {
            ma_tour = Ma_tour;
            ma_hdv = Ma_hdv;
        }
        public string ma_tour { get; set; }  
        public string ma_hdv { get; set; }  
    }
}
