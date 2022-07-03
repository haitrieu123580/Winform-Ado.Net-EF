using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer.DAL
{
    // thuc thi cac cau lenh query
    public class DBHelper
    {
      // tao _Instance
      private static DBHelper _Instance;
        public static DBHelper Instance { 
            get 
            { if(_Instance == null )
                {
                    string s = @"Data Source=Chill\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
                    _Instance = new DBHelper(s);
                }
                return _Instance; 
            } 
            private set {  }
        }
        private SqlConnection cnn; 
        public DBHelper(string s)
        { 
            // ket noi den he quan tri csdl
            cnn = new SqlConnection(s);
        }
        public void ExecuteDB(string query)
        {
            SqlCommand cmm = new SqlCommand(query, cnn );
            cnn.Open();
            cmm.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable GetRecords(string query)
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
