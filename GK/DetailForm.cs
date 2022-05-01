using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK
{
    public partial class DetailForm : Form
    {
        public delegate void MyDel(string ltc, string nhaxb, string nxb, string txt);
        public MyDel d { get; set; }
        private QLBB bll = new QLBB();
        public string MBB{  get; set;  }
        public DetailForm(string mbb)
        {
            MBB = mbb;
            InitializeComponent();
            foreach (string ltc in bll.ListLoaiTC().Distinct())
            {
                cbbLoaiTC.Items.Add(ltc);
            }
            foreach (string nxb in bll.ListNhaXB().Distinct())
            {
                cbbNhaXB.Items.Add(nxb);
            }
            foreach (string nam in bll.ListNamXB().Distinct())
            {
                cbbNamXB.Items.Add(nam);
            }
            GUI();
        }

        public void GUI()
        {
            //
            if (MBB != "")
            {
                txtMaBB.Text = MBB;
                txtMaBB.Enabled = false;
                txtTenBB.Text = bll.GetBBByMBB(MBB).TenBB;
                txtTenTG.Text = bll.GetBBByMBB(MBB).TenTG;
                cbbLoaiTC.SelectedItem= bll.GetBBByMBB(MBB).LoaiTC;
                cbbTenTC.SelectedItem = bll.GetBBByMBB(MBB).TenTC;
                cbbNamXB.SelectedItem= bll.GetBBByMBB(MBB).NamXB;
                cbbNhaXB.SelectedItem= bll.GetBBByMBB(MBB).NhaXB;
            }
        }
        private void DetailForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // loi ???
            BB s = new BB
            {
                MBB = txtMaBB.Text,
                TenBB = txtTenBB.Text,
                TenTG= txtTenTG.Text,
                LoaiTC= cbbLoaiTC.SelectedItem.ToString(),
                //TenTC= cbbTenTC.SelectedItem.ToString(),
                NamXB=cbbNamXB.SelectedItem.ToString(),
                NhaXB= cbbNhaXB.SelectedItem.ToString(),

            };
            bll.AddBB(s);
            d("All","All","All", "");
            this.Close();
        }
    }
}
