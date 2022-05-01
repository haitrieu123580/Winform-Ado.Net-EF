using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT
{
    public partial class detailform : Form
    {
     
        public delegate void MyDel(string LSH, string txt);
        public MyDel d { get; set; } // dung de tro den ham ShowAllSV
        private QLSV bll = new QLSV();
        public string MSSV { get; set; }
        public detailform(string m) // add moi khi m ="" , update khi m = "LSH"
        {
            InitializeComponent();
            MSSV = m;
            foreach(string i in bll.ListLSH().Distinct())
            {
                cbbLSH.Items.Add(i);
            }
            // GUI() : hien thi thong tin cua Detailform hien tai ( add or update form)
            GUI();
        }
        public void GUI()
        {
            foreach(SV i in bll.GetAllSV())
            {
                if (MSSV != "") // detailform khi update
                {
                    SV s = new SV();
                    s = bll.GetSVByMSSV(MSSV);
                    txtMSSV.Enabled = false;
                    txtMSSV.Text = s.MSSV;
                    txtNameSV.Text = s.NameSV;
                    txtDTB.Text = s.DTB.ToString();
                    cbbLSH.SelectedItem = s.LopSH;
                    if (s.Gender)
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }
                    dateTimePicker1.Value = s.NS;
                    cbAnh.Checked = s.Anh;
                    cbHocBa.Checked = s.HB;
                    cbNN.Checked = s.CCNN;
                }
           
            }
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            SV s = new SV();
            s.MSSV = txtMSSV.Text;
            s.NameSV = txtNameSV.Text;  
            s.LopSH = cbbLSH.SelectedItem.ToString();
            s.Gender = rbMale.Checked ? rbMale.Checked : rbFemale.Checked;
            s.DTB = Convert.ToDouble(txtDTB.Text);
            s.NS = dateTimePicker1.Value;
            s.Anh = cbAnh.Checked;
            s.HB = cbHocBa.Checked;
            s.CCNN = cbNN.Checked;
            //bll.AddSV(s);
            bll.AddUpdate(s); // ko can viet model kiem tra do la AddSV(s) hay UpdateSV(s)
            // hien thi datagridview sau khi OK
            d("All", ""); // sau khi thao tac show toan bo SV co trong DTSV
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
