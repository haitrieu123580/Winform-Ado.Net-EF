using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCSDL
{
    public class DBHelper
    {
        private SqlConnection cnn;
        public DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        public void ExcuteDB(string query)
        {
            SqlCommand cmd =new SqlCommand(query,cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable GetRecord(string query)
        {
            DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[]
            //{
            //    new DataColumn{ColumnName="MSSV",DataType= typeof(string)},
            //    new DataColumn{ColumnName="NameSV",DataType= typeof(string)},
            //    new DataColumn{ColumnName="DTB",DataType= typeof(double)},
            //    new DataColumn{ColumnName="ID_Lop",DataType= typeof(int)},
            // });

            //SqlCommand cmd = new SqlCommand(query, cnn);
            //SqlDataReader r;
            //cnn.Open();
            //r = cmd.ExecuteReader();
            //while (r.Read())
            //{
            //    dt.Rows.Add(
            //        r[0].ToString(),
            //        r["NameSV"].ToString(),
            //        Convert.ToDouble(r[2].ToString()),
            //        Convert.ToInt32(r[3].ToString())
            //        );
            //}
            //cnn.Close();
            //-------
            SqlDataAdapter da = new SqlDataAdapter(query, cnn );
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
    }
}
