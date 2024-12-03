using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class DiemThamQuanModel
    {
        public DiemThamQuanModel(SqlDataReader reader)
        {
            ma_diem_tham_quan = reader["ma_diem_tham_quan"].ToString();  
            ten_dia_diem = reader["ten_dia_diem"].ToString();  
            dia_chi = reader["dia_chi"].ToString();  
        }
        public DiemThamQuanModel(string Ma_diem_tham_quan, string Ten_dia_diem, string Dia_chi)
        {
            ma_diem_tham_quan = Ma_diem_tham_quan;
            ten_dia_diem = Ten_dia_diem;
            dia_chi = Dia_chi;
        }

        public string ma_diem_tham_quan { get; set; }  
        public string ten_dia_diem { get; set; }  
        public string dia_chi { get; set; }  
    }
}
