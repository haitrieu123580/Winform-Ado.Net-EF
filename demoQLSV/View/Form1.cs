using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demoQLSV.BLL;
using demoQLSV.DTO;
using demoQLSV.View;

namespace demoQLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            cbbLSH.Items.Add(new CBBItem { Text = "All", Value = 0 });
            foreach (CBBItem i in QLSVBLL.Instance.GetCBBItem() )
            {
                cbbLSH.Items.Add(i);
            }
            cbbLSH.SelectedIndex = 0;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            int id_lop = ((CBBItem)cbbLSH.SelectedItem).Value;
            Show(id_lop);
        }
        public void Show(int ID_Lop)
        {
           
            dataGridView1.DataSource = QLSVBLL.Instance.GetSV_ViewByIDLop(ID_Lop);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2("");
            f.d = new Form2.MyDel(Show);
            f.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                Form2 f = new Form2(mssv);
                f.d = new Form2.MyDel(Show);
                f.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string mssv = i.Cells["MSSV"].Value.ToString();
                    QLSVBLL.Instance.DeleteSVBLL(mssv);
                }
            }
            Show(0);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string attribute = comboBox1.SelectedItem.ToString();
            List<SV> data = QLSVBLL.Instance.SortSVBLL(attribute);
            dataGridView1.DataSource = QLSVBLL.Instance.SVtoSV_View(data);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id_lop = ((CBBItem)cbbLSH.SelectedItem).Value;
            List<SV> data = QLSVBLL.Instance.SearchSVBLL(id_lop, txtSearch.Text.ToLower());
            dataGridView1.DataSource = QLSVBLL.Instance.SVtoSV_View(data);
        }
    }
}
