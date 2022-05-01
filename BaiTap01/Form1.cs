using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbTR.SelectedIndex = 0;
        }
        private double Tien()
        {
            double s = 0;
            if (ckCV.Checked)
                s += 1;
            if (ckTR.Checked)
                s += 1;
            if (ckCHR.Checked)
                s += 1;
            int sr = Convert.ToInt32(cbTR.SelectedItem.ToString());
            s += sr * 4;
            return s;
        }

        private void butTT_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                txtTotal.Text = Tien().ToString();
            }
            else
            {
                MessageBox.Show("Nhap ten di ");
            
            }
      
        }

        private void butT_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }
    }
}
