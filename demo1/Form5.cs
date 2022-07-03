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
    public partial class Form5 : Form
    {
        Point ps;
        public Form5()
        {
            InitializeComponent();
        }
     

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Left)
            //{
            //    Graphics g = this.CreateGraphics();
            //    Pen p = new Pen(Color.Red, 2f);
            //    g.DrawLine(p, ps, e.Location);
            //}
        }

        private void Form5_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.Red, 2f);
                g.DrawLine(p, ps, e.Location);
            }
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ps = e.Location;
            }
        }  

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            label2.Text = "KeyCode = " + e.KeyCode + ", KeyData = " + e.KeyData
               + ", KeyValue = " + e.KeyValue  /* + ", KeyModifier = " + e.Modifiers*/;
            //switch (e.KeyCode)
            //{
            //    case Keys.D1:
            //        //btnNum1.PerformClick();
            //        break;
            //}

        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = "KeyChar = " + e.KeyChar;
        }

        //private void True(object sender, PreviewKeyDownEventArgs e)
        //{

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = true;
            o.Filter = "Doc| *.doc| All |*.*";
            DialogResult r;
            r = o.ShowDialog();
            if (r == DialogResult.OK)
            {
                MessageBox.Show("A");
            }
            else
            {
                MessageBox.Show("B");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
