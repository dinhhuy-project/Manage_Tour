using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class TourDTQModel
    {
        public TourDTQModel(SqlDataReader reader)
        {
            ma_tour = reader["ma_tour"].ToString();  
            ma_diem_tham_quan = reader["ma_diem_tham_quan"].ToString();  
        }


        public TourDTQModel(string Ma_tour, string Ma_diem_tham_quan)
        {
            ma_tour = Ma_tour;
            ma_diem_tham_quan = Ma_diem_tham_quan;
        }
        public string ma_tour { get; set; }  
        public string ma_diem_tham_quan { get; set; }  
    }
}
