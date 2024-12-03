using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class HuongDanVienModel
    {
        public HuongDanVienModel(object[] dataRow)
        {
            ma_hdv = dataRow[0].ToString();
            full_name = dataRow[1].ToString();
            cccd = dataRow[2].ToString();
            sdt = dataRow[3].ToString();
            diachi = dataRow[4].ToString();
        }

        public HuongDanVienModel(string Ma_hdv, string Fullname, string Cccd, string Sdt, string Diachi)
        {
            ma_hdv = Ma_hdv;
            full_name = Fullname;
            cccd = Cccd;
            sdt = Sdt;
            diachi = Diachi;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        public static HuongDanVienModel selectByKey(string id)
        {
            HuongDanVienModel huongDanVienModel = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id))
            {
                huongDanVienModel = new HuongDanVienModel(dataRow);
            }
            return huongDanVienModel;
        }

        public static int insert(HuongDanVienModel huongDanVienModel)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT,
                huongDanVienModel.ma_hdv,
                huongDanVienModel.full_name,
                huongDanVienModel.cccd,
                huongDanVienModel.sdt,
                huongDanVienModel.diachi);
            return result;
        }

        public static int insert(string ma_hdv, string fullName, string cccd, string sdt, string diachi)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT,
                ma_hdv,
                fullName,
                cccd,
                sdt,
                diachi);
            return result;
        }

        public static int update(HuongDanVienModel huongDanVienModel)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,
                huongDanVienModel.full_name,
                huongDanVienModel.cccd,
                huongDanVienModel.sdt,
                huongDanVienModel.diachi,
                huongDanVienModel.ma_hdv);
            return result;
        }

        public static int update(string fullName, string cccd, string sdt, string diachi, string ma_hdv)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,
                fullName,
                cccd,
                sdt,
                diachi,
                ma_hdv);
            return result;
        }

        public static int delete(HuongDanVienModel huongDanVienModel)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, huongDanVienModel.ma_hdv);
        }

        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }

        public static String TABLE = "HuongDanVien";
        public static String FIELD_MA_HDV = "ma_hdv";
        public static String FIELD_FULL_NAME = "full_name";
        public static String FIELD_CCCD = "cccd";
        public static String FIELD_SDT = "sdt";
        public static String FIELD_DIA_CHI = "diachi";

        public static String QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static String QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_HDV} = @p1";
        public static String QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_HDV}, {FIELD_FULL_NAME}, {FIELD_CCCD}, {FIELD_SDT}, {FIELD_DIA_CHI}) VALUES (@p1, @p2, @p3, @p4, @p5)";
        public static String QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_FULL_NAME}=@p1, {FIELD_CCCD}=@p2, {FIELD_SDT}=@p3, {FIELD_DIA_CHI}=@p4 WHERE {FIELD_MA_HDV} = @p5";
        public static String QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_HDV} = @p1";


        public string ma_hdv { get; set; }
        public string full_name { get; set; }
        public string cccd { get; set; }
        public string sdt { get; set; }
        public string diachi { get; set; }
    }
}
