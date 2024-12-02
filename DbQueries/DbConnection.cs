using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    internal class DbConnection
    {
        //sửa db ở đây để kết nối
        private readonly string _connectionString = "Data Source=DIEN-DIEN\\SQLEXPRESS;Initial Catalog=dulich_thi;Persist Security Info=True;User ID=sa;Password=123456";
        public SqlConnection connection;
        public DbConnection() 
        {
            connection = null;
            connection = new SqlConnection(_connectionString);
        }
        public SqlConnection GetSqlConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(_connectionString);
            }
            return connection;
        }
        private class DBConnectionHolder
        {
            public static DbConnection INSTANCE = new DbConnection();
        }
        public static DbConnection getInstance()
        {
            return DBConnectionHolder.INSTANCE;
        }
    }
}
