
using QLTD.BLL;
using QLTD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTD.View
{
    public partial class MainForm : Form
    {
        QLTDBLL bll = new QLTDBLL();  
        public MainForm()
        {
            InitializeComponent();
            SetCBBMonAn();
            setCBBSort();
            Show(0, "");
        }
        public void SetCBBMonAn()
        {
            cbbMon.Items.Add(new CBBItem { Text = "", Value = 0 });
            cbbMon.Items.AddRange(QLTDBLL.Instance.GetAllCBBMonAn().ToArray());
            cbbMon.SelectedIndex = 0;
        }

        public void Show(int maMonAn, string txt)
        {
           
            dataGridView1.DataSource = QLTDBLL.Instance.MonAn_NLtoItemView(QLTDBLL.Instance.SearchByMonAn(maMonAn, txt));
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int maMonAn = ((CBBItem)cbbMon.SelectedItem).Value;
            Show(maMonAn,txtSearch.Text);
        }
        // chinh sua lai

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maMonAn = ((CBBItem)cbbMon.SelectedItem).Value;
            if(maMonAn != 0)
            {
                DetailForm f = new DetailForm("", ((CBBItem)cbbMon.SelectedItem).Value);
                f.d = new DetailForm.MyDel(Show);
                f.Show();
            }
            else
            {
                MessageBox.Show("Chon mon an");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //string tenNguyenLieu = ""
            string ma = "";
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string tenNL = dataGridView1.SelectedRows[0].Cells["TenNguyenLieu"].Value.ToString();
                int maMonAn = ((CBBItem)cbbMon.SelectedItem).Value;
                if(maMonAn!=0)
                {
                    DetailForm f = new DetailForm(QLTDBLL.Instance.getMA_NLByTen(tenNL).Ma, maMonAn);
                    f.d = new DetailForm.MyDel(Show);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Chon mon an");
                }
               
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                   
                    bool tinhtrang =Convert.ToBoolean(i.Cells["TinhTrang"].Value.ToString());
                    if(tinhtrang == false)
                    {
                        string tenNguyenLieu = i.Cells["TenNguyenLieu"].Value.ToString();
                        QLTDBLL.Instance.Delete(tenNguyenLieu);
                    }
                    else
                    {
                        MessageBox.Show("Nguyen lieu da nhap ve");
                    }
                }
            }
            
            Show(0, "");
        }
        public void setCBBSort()
        {
            cbbSort.Items.Add(new CBBItem { Text = "Tennguyenlieu" , Value=0});
            cbbSort.Items.Add(new CBBItem { Text = "Soluong", Value = 1 });
            cbbSort.Items.Add(new CBBItem { Text = "Donvitinh", Value = 2 });
            cbbSort.Items.Add(new CBBItem { Text = "Tinhtrang", Value = 3});

        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            int thuoctinh = ((CBBItem)cbbMon.SelectedItem).Value;
            int maMonAn = ((CBBItem)cbbMon.SelectedItem).Value;
            dataGridView1.DataSource = QLTDBLL.Instance.Sort(thuoctinh, maMonAn);
        }

        private void cbbMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maMonAn = ((CBBItem)cbbMon.SelectedItem).Value;
            Show(maMonAn, "");
        }
    }
}
