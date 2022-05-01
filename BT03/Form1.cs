using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT03
{
    public partial class Form1 : Form
    {
        DataTable[] dt = new DataTable[] {
                new DataTable(),
                new DataTable(),
                new DataTable(),
                new DataTable(),
                new DataTable(),
         };

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            InitTalbe();
        }
        public void InitTalbe()
        {
            for (int i = 0; i < dt.Length; i++)
            {
                dt[i].Columns.Add("FoodName", typeof(string));
                dt[i].Columns.Add("Quality", typeof(int));
            }
        }
        public void Add(string Namefood)
        {

            if (dataGridView1.Rows.Count == 1)
            {
                DataRow dr = dt[comboBox1.SelectedIndex].NewRow();
                dr[0] = Namefood;
                dr[1] = 1;
                dt[comboBox1.SelectedIndex].Rows.Add(dr);
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == Namefood)
                    {
                        int count = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        dataGridView1.Rows[i].Cells[1].Value = count + 1;
                        return;
                    }
                }
                DataRow dr = dt[comboBox1.SelectedIndex].NewRow();
                dr[0] = Namefood;
                dr[1] = 1;
                dt[comboBox1.SelectedIndex].Rows.Add(dr);
                {

                }
            }
        }
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dt[0];
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dt[1];

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = dt[2];

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.DataSource = dt[3];

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                dataGridView1.DataSource = dt[4];

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Add(btn.Text);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            dt[comboBox1.SelectedIndex].Clear();
        }
    }
}
    
