using QLTD.DTO;
using QLTD.BLL;
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
    public partial class DetailForm : Form
    {
        public string Ma { get; set; }
        public int MaMonAn { get; set; }
        public delegate void MyDel(int maMon, string txt);
        public MyDel d;
        
        public DetailForm(string maMA_NL, int maMonAn)
        {
            InitializeComponent();
            Ma = maMA_NL;
            MaMonAn = maMonAn;
            MaMonAn = maMonAn;
            LoadCBBTenNL(); 
            SetCBBTinhTrang(); 
            GUI();
            //
        }
        public void LoadCBBTenNL()
        {
            cbTenNL.Items.AddRange(QLTDBLL.Instance.getAllCBBItemNguyenLieu().ToArray());            
        }
        private void SetCBBTinhTrang()
        {
            cbTinhTrang.Items.Clear();
            cbTinhTrang.Items.Add(new CBBItem { Text = "Chua duoc nhap", Value = 0 });
            cbTinhTrang.Items.Add(new CBBItem { Text ="Da duoc nhap", Value =1});
        }

        public void GUI()
        {
            if(!QLTDBLL.Instance.Check(Ma))
            {
                // load cac nguyen lieu lien quan den mon an 
                MonAn_NguyenLieu temp = QLTDBLL.Instance.getMA_NLByMa(Ma);
                foreach(CBBItem i in QLTDBLL.Instance.getAllCBBItemNguyenLieu())
                {
                    //tim CBBTenNguyenLieu ung voi ma nguyen lieu
                    if(i.Value == temp.MaNguyenLieu)
                    {
                        this.cbTenNL.Text = i.Text;
                        break;
                    }
                   
                }
                txtSL.Text = temp.SoLuong.ToString();
                cbDonVi.Text = temp.DonViTinh.ToString();
                foreach(NguyenLieu i in QLTDBLL.Instance.getAllNguyenLieu())
                {
                    //lay Tinh trang cua nguyen lieu tim dc -> cbTinhTrang
                    if(temp.MaNguyenLieu== i.MaNguyenLieu)
                    {
                        if(i.TinhTrang)
                        {
                            this.cbTinhTrang.Text = "Da duoc nhap";
                        }
                        else
                        {
                            this.cbTinhTrang.Text = "Chua duoc nhap";
                        }
                        break;
                    }
                    
                }
            }
          
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // update lai obj 
            //ma = ma moi
            // so luong = moi
            //don vi tinh = moi
            //maMonAn = maMonAn
            //MaNL == tenNL-> maNL
            // them MA_NL moi -> csdl
            MonAn_NguyenLieu s = new MonAn_NguyenLieu();
            if(QLTDBLL.Instance.Check(Ma))
            {
                s.Ma = "Ma" + DateTime.Now.Millisecond.ToString();
                MessageBox.Show(s.Ma);
            }
            else
            {
                s.Ma = Ma;
            }
            
            s.SoLuong = Convert.ToInt32(txtSL.Text);
            s.DonViTinh = cbDonVi.Text;
            s.MaMonAn = MaMonAn;
            s.MaNguyenLieu = ((CBBItem)cbTenNL.SelectedItem).Value;
            QLTDBLL.Instance.AddUpdate(s);
            d(MaMonAn, "");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
