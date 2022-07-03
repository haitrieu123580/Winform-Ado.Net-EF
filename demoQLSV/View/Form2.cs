using demoQLSV.BLL;
using demoQLSV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoQLSV.View
{

    public partial class Form2 : Form
    {
        public delegate void MyDel(int id_lop);
        public MyDel d { get; set; }
        public string MSSV { get; set; }

        public Form2(string m)
        {
            InitializeComponent();
            MSSV = m;
            //set CBB LopSH
            foreach (CBBItem i in QLSVBLL.Instance.GetCBBItem())
            {
                cbbLSH.Items.Add(i);
            }
            GUI();
        }

        public void GUI()
        {
            if (!QLSVBLL.Instance.Check(MSSV))
            {
                txtMSSV.Text = QLSVBLL.Instance.GetSVByMSSV(MSSV).MSSV.ToString();
                txtMSSV.Enabled = false;
                txtName.Text = QLSVBLL.Instance.GetSVByMSSV(MSSV).NameSV.ToString();
                txtDTB.Text = QLSVBLL.Instance.GetSVByMSSV(MSSV).DTB.ToString();
                foreach (CBBItem i in cbbLSH.Items)
                {
                    if (QLSVBLL.Instance.GetSVByMSSV(MSSV).ID_Lop == i.Value)
                    {
                        cbbLSH.SelectedItem = i;
                        break;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SV s = new SV();
            s.MSSV = txtMSSV.Text;
            s.ID_Lop = ((CBBItem)cbbLSH.SelectedItem).Value;
            s.NameSV = txtName.Text;
            s.DTB = Convert.ToDouble(txtDTB.Text);
            QLSVBLL.Instance.AddUpdate(s);
            // thuc hien show lai ds sau khi nhan ok
            d(0);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
