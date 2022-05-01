using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT
{
    public partial class mainform : Form
    {
        QLSV bll = new QLSV();
        public mainform()
        {
            InitializeComponent();
            comboBox1.Items.Add("All");
            foreach(string lsh in bll.ListLSH().Distinct()) // them cac LSH ( da distinct) vao comboBox1
            {
                comboBox1.Items.Add(lsh);
            }
            comboBox2.Items.Add("MSSV");
            comboBox2.Items.Add("NameSV");
            comboBox2.Items.Add("DTB");
        }

        
        private void butShow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.GetSVByLSH(comboBox1.SelectedItem.ToString());
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            detailform f = new detailform("");
            f.d = new detailform.MyDel(ShowAllSV); //??????
            f.Show();

        }
        private void butUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                detailform f = new detailform(mssv);
                f.d = new detailform.MyDel(ShowAllSV); //??????
                f.Show();
            }
          

        }

        private void butDel_Click(object sender, EventArgs e)
        {
            List<string> MSSVdel = new List<string>();
            if(dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    MSSVdel.Add(i.Cells["MSSV"].Value.ToString());
                }
                bll.DelSV(MSSVdel);
                ShowAllSV(comboBox1.SelectedItem.ToString(), ""); //
            }
        }
        private void butSort_Click(object sender, EventArgs e)
        {
         
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
        

        }
     
        // ShowAllSV : thuc hien show DTSV hien tai theo LopSH va thuoc tinh txt
        public void ShowAllSV(string LSH, string txt)
        {
            dataGridView1.DataSource = bll.SearchSV(comboBox1.SelectedItem.ToString(), txt);
        }



    }
}
