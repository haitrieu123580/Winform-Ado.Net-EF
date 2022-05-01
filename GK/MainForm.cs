using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK
{
    public partial class MainForm : Form
    {
        QLBB bll = new QLBB();
        public MainForm()
        {
            InitializeComponent();
            cbbLTC.Items.Add("All");
            foreach(string ltc in bll.ListLoaiTC().Distinct())
            {
                cbbLTC.Items.Add(ltc);
            }
            cbbNhaXB.Items.Add("All");
            foreach (string nxb in bll.ListNhaXB().Distinct())
            {
                cbbNhaXB.Items.Add(nxb);
            }
            cbbNam.Items.Add("All");
            foreach(string nam in bll.ListNamXB().Distinct())
            {
                cbbNam.Items.Add(nam);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
     
            string ltc = cbbLTC.SelectedItem.ToString();
            string nhaxb = cbbNhaXB.SelectedItem.ToString();
            string namxb = cbbNam.SelectedItem.ToString();
            string txt = txtSearch.Text;
            ShowAllBB(ltc, nhaxb, namxb, txt);
        }
        public void ShowAllBB(string ltc, string nhaxb, string namxb, string txt)
        {
            dataGridView1.DataSource = bll.SearchBB(cbbLTC.SelectedItem.ToString(),
                cbbNhaXB.SelectedItem.ToString(),
                cbbNam.SelectedItem.ToString(),txt);
        }
        //BtnDel
        private void btnDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ban co muon xoa khong? ");          
            List<string> del = new List<string>();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    del.Add(i.Cells["MBB"].Value.ToString());
                }
            }
            bll.DelBB(del);
            string ltc = cbbLTC.SelectedItem.ToString();
            string nhaxb = cbbNhaXB.SelectedItem.ToString();
            string namxb = cbbNam.SelectedItem.ToString();
            string txt = txtSearch.Text;
            ShowAllBB(ltc, nhaxb, namxb, txt);
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm f = new DetailForm("");
            f.d = new DetailForm.MyDel(ShowAllBB);
            f.Show();
        }
    }
}
