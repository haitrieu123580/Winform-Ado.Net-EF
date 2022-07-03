using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTD_3layers.View
{
    public partial class HuynhThanhHaiTrieu_MF : Form
    {
        QLTDContext db = new QLTDContext();
        public HuynhThanhHaiTrieu_MF()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.monAns.ToList();
        }
    }
}
