using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ShowDGV()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                    new DataColumn{DataType = typeof(string),ColumnName = "MSSV"},
                    new DataColumn{DataType = typeof(string),ColumnName = "NameSV"},
                    new DataColumn{DataType = typeof(bool),ColumnName = "Gender"},
                    new DataColumn{DataType = typeof(string),ColumnName = "NameLop"},
             });
        }
    }
}
