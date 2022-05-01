using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    // thuc hiện việc thao tác với các câu lệnh query 
    // thực hiện câu lệnh class ExcuteCommand 
    // thực hiện lấy các record theo dạng DataTable từ class DataAdapter
    public class DBHelper
    {
        private SqlConnection cnn;
        public DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        // xử lý câu lệnh Insert, Update, Delete
        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery(); // sử dụng câu lệnh Command thay vì dùng câu lệnh của lớp Adapter
            cnn.Close();
        }
        // xử lý câu lệnh Select ( tra tat ca record can chon ve 1 dataTable)
        public DataTable GetRecord(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
    }
}
