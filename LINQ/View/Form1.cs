//using LINQ.BLL;
//using LINQ.DTO;
using LINQ.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ

{
    // Lop View KHONG duoc tuong tac truc tiep voi du lieu 
    // thong qua BLL-> thong qua DAL-> lay du lieu-> truyen nguoc lai len View
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
        }
       
        public void SetCBB()
        {
            cbLSH.Items.Add(new CBBItem { Text = "All", Value = 0 });
            foreach(CBBItem i in QLSVBLL.Instance.GetCBBItem())
            {
                cbLSH.Items.Add(i);
            }
            cbLSH.SelectedIndex = 0;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            int id_lop = ((CBBItem)cbLSH.SelectedItem).Value;
            Show(id_lop);
        }
        public void Show(int id_lop)
        {
            dataGridView2.DataSource = QLSVBLL.Instance.GetSVByIDLop(id_lop);
        }
     
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id_lop = ((CBBItem)cbLSH.SelectedItem).Value;
            dataGridView2.DataSource = QLSVBLL.Instance.SearchSVBLL(id_lop,txtSearch.Text.ToLower());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2("");
            f.d = new Form2.MyDel(Show);
            f.Show();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count ==1)
            {
                string mssv = dataGridView2.SelectedRows[0].Cells["MSSV"].Value.ToString();
                Form2 f = new Form2(mssv);
                f.d = new Form2.MyDel(Show);
                f.Show();
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow i in dataGridView2.SelectedRows)
            {
                string mssv = i.Cells["MSSV"].Value.ToString();
                QLSVBLL.Instance.DeleteSVBLL(mssv);
            }
            Show(0);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
             string attribute = comboBox2.SelectedItem.ToString();
             dataGridView2.DataSource = QLSVBLL.Instance.SortSVBLL(attribute);
        }
    }
}
