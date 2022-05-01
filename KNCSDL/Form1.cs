using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNCSDL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = @"Data Source = Chill\SQLEXPRESS; Initial Catalog = demo; Integrated Security = True";
               // SqlConnection cnn = new SqlConnection(s); // ket noi voi nguon du lieu
             ////string query = "select count (*) from SV";
             ////string query ="insert SV value('0000000004','nva','',1)";
             //SqlParameter p = new SqlParameter // truyen tham so vao cau lenh command
              //{
              //    ParameterName = "@Name", //ten bien
              //    Value = textBox1.Text //gia tri ma bien nhan duoc
               //};
            ////string query = "select * from SV where NameSV = '" + textBox1.Text +"'"; //cach 1
            ////string query = "select * from SV where NameSV = @Name"; // cach2

            //string query = "select * from SV"; // chon toan bo cac record 
            //SqlCommand cmd = new SqlCommand(query, cnn); // thuc hien cau lenh query ( trong csdl cnn ket noi den)
            //// cmd.Parameters.Add(p);
            //SqlDataReader r;
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[]
            //{
            //    new DataColumn{ColumnName="MSSV",DataType= typeof(string)},
            //    new DataColumn{ColumnName="NameSV",DataType= typeof(string)},
            //    new DataColumn{ColumnName="DTB",DataType= typeof(double)},
            //    new DataColumn{ColumnName="ID_Lop",DataType= typeof(int)},
            // });

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
            ////cmd.ExecuteNonQuery();
            ////int n = (int)cmd.ExecuteScalar(); // tra ve cac ban ghi khong bi thay doi du lieu
            //cnn.Close();
            //dataGridView1.DataSource = dt;
            ////MessageBox.Show(n.ToString());

            //------------ Data Provider 
            //DBHelper db = new DBHelper(s);
            //string query = "select * from SV";
            //dataGridView1.DataSource = db.GetRecordSV(query);

            //---------- sư dụng SQL adapter
            SqlConnection cnn = new SqlConnection(s);
            //string query = "select * from SV";
            //SqlDataAdapter da = new SqlDataAdapter(query, cnn); // 2 tham so gom : cau lenh query de truy van du lieu, cnn la doi tuong DB connect
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //cnn.Open(); // truy cap den DB

            ////c1: 
            ////da.Fill(ds); // truyen du lieu vao ds
            ////c2:
            ////da.Fill(ds,"SV");
            ////c3: 
            //da.Fill(dt); //truyen thang data -> dataTable

            //cnn.Close();
            //dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.DataSource = ds.Tables["SV"];
            // dataGridView1.DataSource = dt;
            DBHelper db = new DBHelper(s);
            string query = "select * from LopSH";
            dataGridView1.DataSource = db.GetRecord(query);


        }
    }
}
