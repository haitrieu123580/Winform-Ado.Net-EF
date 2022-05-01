using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            //DataListView();
            ShowDGV();
        }
        public void DataListView()
        {
            List<SV> data = new List<SV>();
            data.AddRange(new SV[] {
                new SV{MSSV = "102", NameSV = "NVA",Gender = true, NameLop = "20TCLC_DT1"},
                new SV{MSSV = "103", NameSV = "NVB",Gender = true, NameLop = "20TCLC_DT1"},
                new SV{MSSV = "104", NameSV = "NVC",Gender = false, NameLop = "20TCLC_DT2"},
                new SV{MSSV = "105", NameSV = "NVD",Gender = true, NameLop = "20TCLC_DT3"}
            });

            // add data to listview
            // create form of list view ( it has 4 col : MSSV, Name SV, Gender, NameLop)
            listView1.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader{Text = "MSSV"},
                new ColumnHeader{Text = "NameSV"},
                new ColumnHeader{Text = "Gender"},
                new ColumnHeader{Text = "NameLop"}
            });
            // add items
            foreach(SV i in data)
            {
                ListViewItem j = new ListViewItem(i.MSSV); // first cell of view  == 
                j.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem{Text = i.NameSV},
                    new ListViewItem.ListViewSubItem{Text = i.Gender.ToString()},
                    new ListViewItem.ListViewSubItem{Text = i.NameLop},
                });
                listView1.Items.Add(j);
            }
           
        }
        // process event when selecte item of list view
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                string data = "";
                foreach(ListViewItem i in listView1.SelectedItems)
                {
                    string MSSV = i.Text;
                    string NameSV = i.SubItems[1].Text;
                    bool Gender = Convert.ToBoolean(i.SubItems[2].Text);
                    string NameLop = i.SubItems[3].Text;
                    data += MSSV + ", " + NameSV + ", " +Gender.ToString() + ", " + NameLop +"\n";
                }
                MessageBox.Show(data);
            }
        }
        public void ShowDGV()
        {
            //// this only show what DataGridView have ( able to chance data of DGV)
            //List<SV> data = new List<SV>();
            //data.AddRange(new SV[] {
            //    new SV{MSSV = "102", NameSV = "NVA",Gender = true, NameLop = "20TCLC_DT1"},
            //    new SV{MSSV = "103", NameSV = "NVB",Gender = true, NameLop = "20TCLC_DT1"},
            //    new SV{MSSV = "104", NameSV = "NVC",Gender = false, NameLop = "20TCLC_DT2"},
            //    new SV{MSSV = "105", NameSV = "NVD",Gender = true, NameLop = "20TCLC_DT3"}
            //});
            //dataGridView1.DataSource = data;

            // use DataTable to store data of List<SV> ( unable to chance data of DGV bc now DGV just show data not store)
            List<SV> data = new List<SV>();
            data.AddRange(new SV[] {
                new SV{MSSV = "102", NameSV = "NVA",Gender = true, NameLop = "20TCLC_DT1"},
                new SV{MSSV = "103", NameSV = "NVB",Gender = true, NameLop = "20TCLC_DT1"},
                new SV{MSSV = "104", NameSV = "NVC",Gender = false, NameLop = "20TCLC_DT2"},
                new SV{MSSV = "105", NameSV = "NVD",Gender = true, NameLop = "20TCLC_DT3"}
            });
            DataTable dt = new DataTable();
            // create DataTable 
            dt.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn{DataType = typeof(string),ColumnName = "MSSV"},
                    new DataColumn{DataType = typeof(string),ColumnName = "NameSV"},
                    new DataColumn{DataType = typeof(bool),ColumnName = "Gender"},
                    new DataColumn{DataType = typeof(string),ColumnName = "NameLop"},
                });
            // add data to rows of DataTable
            foreach (SV i in data)
            {
                dt.Rows.Add(i.MSSV, i.NameSV, i.Gender, i.NameLop);
            }
            dataGridView1.DataSource = dt;

        }
    }
}
