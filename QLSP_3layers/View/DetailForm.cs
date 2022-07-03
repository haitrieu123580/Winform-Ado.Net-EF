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
    public partial class HuynhThanhHaiTrieu_DF : Form
    {
        public delegate void MyDel(string txt, string tenTinh, string tenNCC);
        public MyDel d { get; set; }
        public string MaSP { get; set; }
        public HuynhThanhHaiTrieu_DF(string m)
        {
            InitializeComponent();
            MaSP = m;
            SetCBBDiaChi();
            
            GUI();
        }


        public void SetCBBDiaChi()
        {
            foreach (CBBItem item in QLSPBLL.Instance.GetCBBDiaChiItems())
            {
                cbbCity.Items.Add(item);
            }
        }

        //cbbNCC phu thuoc vao cbbCity
        public void SetCBBNhaCC(string matinh)
        {
            foreach (CBBItem item in QLSPBLL.Instance.GetCBBNhaCCByMatinh(matinh))
            {
                cbbNCC.Items.Add(item);
            }
        }



        public void GUI()
        {
            if (!QLSPBLL.Instance.Check(MaSP))
            {
                txtMSP.Text = QLSPBLL.Instance.GetSPByMaSP(MaSP).MaSP;
                txtMSP.Enabled = false;
                txtTSP.Text = QLSPBLL.Instance.GetSPByMaSP(MaSP).TenSP;
                txtGia.Text = QLSPBLL.Instance.GetSPByMaSP(MaSP).Gia.ToString();
                dateTimePicker1.Value = QLSPBLL.Instance.GetSPByMaSP(MaSP).NgayNhap;
                foreach (CBBItem i in QLSPBLL.Instance.GetAllCBBNhaCCItems())
                {
                    if (QLSPBLL.Instance.GetSPByMaSP(MaSP).MaNCC == i.Value) // value cbbNCC = maNCC
                    {
                       
                        foreach (CBBItem j in cbbCity.Items)
                        {
                            if (j.Value.ToString() == QLSPBLL.Instance.getDiaChiByNhaCC(i.Value).MaTinh.ToString()) // tim maTinh
                            {
                                cbbCity.SelectedItem = j;
                                foreach (CBBItem k in cbbNCC.Items)
                                {
                                    if (QLSPBLL.Instance.GetSPByMaSP(MaSP).MaNCC == k.Value)
                                    {
                                        cbbNCC.SelectedItem = k;
                                    }
                                }
                            }
                        }
                  
                        break;
                    }
                }
            }
        }
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            SanPham s = new SanPham();
            s.MaSP = txtMSP.Text;
            s.TenSP = txtTSP.Text;
            s.MaNCC = ((CBBItem)cbbNCC.SelectedItem).Value;
            s.NgayNhap = dateTimePicker1.Value;
            s.Gia = Convert.ToDouble(txtGia.Text);
            QLSPBLL.Instance.AddUpdate(s);
            d("", "All", "");
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maTinh = ((CBBItem)cbbCity.SelectedItem).Value.ToString();
            cbbNCC.Items.Clear();
            SetCBBNhaCC(maTinh);
        }
    }
}
