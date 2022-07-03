using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCodeFirst
{
    public partial class Form1 : Form
    {
        QLSV db = new QLSV();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.SVs.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SV s = new SV { MSSV = "4", NameSV = "NVD", ID_Lop = 2, DTB = 4.4 };
            db.SVs.Add(s);
            db.SaveChanges();
            dataGridView1.DataSource = db.SVs.ToList();

        }
    }
}
