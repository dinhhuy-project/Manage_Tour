using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class NhanVienModel
    {
        public NhanVienModel(SqlDataReader reader)
        {
            id = reader["id"].ToString();
            full_name = reader["full_name"].ToString();
            cccd = reader["cccd"].ToString();
            email = reader["email"].ToString();
            pass_word = reader["pass_word"].ToString();
            chuc_vu = reader["chuc_vu"].ToString();
        }
        public NhanVienModel(string Id, string Fullname, string Cccd, string Email, string Password, string Chucvu)
        {
            id = Id;
            full_name = Fullname;
            cccd = Cccd;
            email = Email;
            pass_word = Password;
            chuc_vu = Chucvu;
        }

        public string id { get; set; }
        public string full_name { get; set; }
        public string cccd { get; set; }
        public string email { get; set; }
        public string pass_word { get; set; }
        public string chuc_vu { get; set; }
    }
}
