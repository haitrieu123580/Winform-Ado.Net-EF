using QLSP_3layers.BLL;
using QLSP_3layers.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSP_3layers.View
{
    public partial class HuynhThanhHaiTrieu_MF : Form
    {
        QLSPContext context= new QLSPContext();
        public HuynhThanhHaiTrieu_MF()
        {
            InitializeComponent();
            SetCBBDiaChi();
            SetCBBSearch();
            Show("","All","");
        }
        public void SetCBBSearch()
        {
            cbbSearch.Items.Add(new CBBItem { Text = "Ten san pham" });
            cbbSearch.Items.Add(new CBBItem { Text = "Gia nhap" });
            cbbSearch.Items.Add(new CBBItem { Text = "Tinh trang" });
        }
        public void SetCBBDiaChi()
        {
            cbbCity.Items.Add(new CBBItem { Text = "All", Value = 0 });
            cbbCity.Items.AddRange(QLSPBLL.Instance.GetCBBDiaChiItems().ToArray());
            cbbCity.SelectedIndex = 0;
           
        }
        //cbbNCC phu thuoc vao cbbCity
        public void SetCBBNhaCC(string matinh)
        {
           
            if(matinh == "0")
            {
               cbbNCC.Items.Add(new CBBItem { Text ="", Value = 0 });
               cbbNCC.Items.AddRange(QLSPBLL.Instance.GetAllCBBNhaCCItems().ToArray());
            }
            else
            {
               cbbNCC.Items.Add(new CBBItem { Text = "", Value = 0 });
               cbbNCC.Items.AddRange(QLSPBLL.Instance.GetCBBNhaCCByMatinh(matinh).ToArray());

            }
            cbbNCC.SelectedIndex = 0;
        }

        private void cbbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maTinh = ((CBBItem)cbbCity.SelectedItem).Value.ToString();
            cbbNCC.Items.Clear();
            SetCBBNhaCC(maTinh);
        }
        //
        public void Show(string txt, string tenTinh,string tenNCC)
        {
            dataGridView1.DataSource = QLSPBLL.Instance.SearchSanPhamItems(txt, tenTinh, tenNCC);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string tenTinh = ((CBBItem)cbbCity.SelectedItem).Text;
            string tenNCC = ((CBBItem)cbbNCC.SelectedItem).Text;
            Show(txtSearch.Text,tenTinh,tenNCC);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string tenSP = i.Cells["TenSP"].Value.ToString();
                    string maSP = ((SanPham)QLSPBLL.Instance.GetSPByTenSP(tenSP)).MaSP; 
                    QLSPBLL.Instance.DeleteSPBLL(maSP);
                }
            }
            string tenTinh = ((CBBItem)cbbCity.SelectedItem).Text;
            string tenNCC = ((CBBItem)cbbNCC.SelectedItem).Text;
            Show(txtSearch.Text, tenTinh, tenNCC);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string thuoctinh = cbbSearch.SelectedItem.ToString();
            // sort toan bo danh sach
            dataGridView1.DataSource = QLSPBLL.Instance.ConvertSPtoSPItem(QLSPBLL.Instance.SortSVBLL(thuoctinh));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HuynhThanhHaiTrieu_DF f = new HuynhThanhHaiTrieu_DF("");
            f.d = new HuynhThanhHaiTrieu_DF.MyDel(Show);
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string tenSP = dataGridView1.SelectedRows[0].Cells["TenSP"].Value.ToString();
                HuynhThanhHaiTrieu_DF f = new HuynhThanhHaiTrieu_DF(QLSPBLL.Instance.GetSPByTenSP(tenSP).MaSP);
                f.d = new HuynhThanhHaiTrieu_DF.MyDel(Show);
                f.Show();
            }
        }

        private void cbbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenTinh = ((CBBItem)cbbCity.SelectedItem).Text;
            string tenNCC = ((CBBItem)cbbNCC.SelectedItem).Text;
            Show("", tenTinh, tenNCC);
        }
    }
}
