using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BT02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtSecurityCode.MaxLength = 4;
            Load_Log();


        }
        private void Load_Log()
        {
            if(!File.Exists("AccessLog.txt"))
            {
                File.Create("AccessLog.txt").Dispose();
            }
            string line;
            System.IO.StreamReader LoadFile = new System.IO.StreamReader("AccessLog.txt");
            while((line = LoadFile.ReadLine()) != null) 
            {
                lbAccessLog.Items.Add(line);    
            }
            LoadFile.Dispose();
        }   
        private void label1_Click(object sender, EventArgs e)
        {

        }
        void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(txtSecurityCode.TextLength <4)
            {
                txtSecurityCode.Text += btn.Text;
            }
            
            //txtSecurityCode.Text.Length += 1;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtSecurityCode.Clear();

        }

        private void btnHashTag_Click(object sender, EventArgs e)
        {
            bool access = false;
            DateTime dateTime = DateTime.Now;
            if (txtSecurityCode.Text =="1645" || txtSecurityCode.Text=="1689")
            {
                lbAccessLog.Items.Add(dateTime.ToString("dd/MM/yyyy MM:mm:ss tt") + "\t Technicians");
                access = true;
            }
            if(txtSecurityCode.Text =="8345")
            {
                lbAccessLog.Items.Add(dateTime.ToString("dd/MM/yyyy MM:mm:ss tt")+ "\t Custodians");
                access=true;
            }
            if(txtSecurityCode.Text=="9998" || txtSecurityCode.Text=="1006" || txtSecurityCode.Text == "1007" || txtSecurityCode.Text == "1008")
            {
                lbAccessLog.Items.Add(dateTime.ToString("dd/MM/yyyy MM:mm:ss tt") + "\t Scientist");
                access=true;
            }
            if (txtSecurityCode.TextLength == 1)
            {
                lbAccessLog.Items.Add(dateTime.ToString("dd/MM/yyyy MM:mm:ss tt") + "\t Restricted Access");
                access = true;
            }
            if (access == false )
            {
                lbAccessLog.Items.Add("Access Denied");
            }
           }
        private void save_Log()
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("AccessLog.txt");
            foreach(var item in lbAccessLog.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();
        }
    }
}
