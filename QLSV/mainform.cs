using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class mainform : Form
    {
        public static string s = @"Data Source=Chill\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
        DBHelper db = new DBHelper(s);
        public mainform()
        {

            InitializeComponent();
            SetCBB1();
            SetCBB2();
            
        }
       public void SetCBB1()
        {
            cbbLSH.Items.Add(new CBBItem{ Text = "All" , Value = 0});
            string query = "select * from LopSH";
            foreach(DataRow i in db.GetRecord(query).Rows)
            {
                cbbLSH.Items.Add( new CBBItem 
                { 
                    Value = Convert.ToInt32(i["ID_Lop"].ToString()),
                    Text = i["NameLop"].ToString() 
                } );
            }
            cbbLSH.SelectedIndex = 0;
        }
        private void butShow_Click(object sender, EventArgs e)
        {
            // để thực hiện show cần biết ID_Lop
            // cần setCBB trước tiên
            int id_lop = ((CBBItem)cbbLSH.SelectedItem).Value;
            ShowSV(id_lop);
        }
        // show cac SV cung ID_Lop
        public void ShowSV(int ID_Lop)
        {
            string query = "";
            if(ID_Lop == 0)
            {
                query = "select * from SV";
                dataGridView1.DataSource = db.GetRecord(query);
            }
            else
            {
                query = "select from SV where ID_Lop = " + ID_Lop;
            }
            dataGridView1.DataSource = db.GetRecord(query);
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            detailform f = new detailform("");
            f.d = new detailform.Mydel(ShowSV); // dung de show DataGridView sau khi Add sv ngay lap tuc
            f.Show();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                detailform f = new detailform(mssv);
                f.d = new detailform.Mydel(ShowSV);
                f.Show();
            }

        }

        private void butDel_Click(object sender, EventArgs e)
        {
         
           //muốn xoá được SV thì phải biết MSSV 
         
           if(dataGridView1.SelectedRows.Count>0)
            {
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string mssv = i.Cells["MSSV"].Value.ToString();
                    string query = "delete from SV where MSSV = '" + mssv + "'";
                    db.ExcuteDB(query);
                }
            }
           ShowSV(0);   
        }
        public void SetCBB2()
        {
            comboBox2.Items.Add("MSSV");
            comboBox2.Items.Add("ID_Lop");
            comboBox2.Items.Add("NameSV");
            comboBox2.Items.Add("Gender");
            comboBox2.Items.Add("NS");
            comboBox2.Items.Add("DTB");
            comboBox2.Items.Add("Anh");
            comboBox2.Items.Add("HocBa");
            comboBox2.Items.Add("CCNN");

        }
        private void butSort_Click(object sender, EventArgs e)
        {
            // sort dựa trên các thuộc tính thuộc cbb2
            // cần set các Item trong comboBox2
            string query = "select * from SV order by " + comboBox2.SelectedItem.ToString() + " desc";
            dataGridView1.DataSource = db.GetRecord(query);
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            // search theo comboBox2Item va txtSearch  
            string query = "select * from SV where " + comboBox2.SelectedItem.ToString()+ " LIKE '%" + txtSearch.Text +"%'";
            dataGridView1.DataSource = db.GetRecord(query);
        }
    }
}
