using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
   
    public partial class detailform : Form
    {
        // create DBHelper to excute
        DBHelper db = new DBHelper(@"Data Source=Chill\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True");
        //using it when Adding or Updating ( that need MSSV)
        private string MSSV { get; set; }
        public delegate void Mydel(int ID_lop);
        public Mydel d { set; get; }
        public detailform(string m)
        {
            InitializeComponent();
            MSSV = m;
            // truyen cac Item vao cbbLSH
            string query = "select * from LopSH";
            foreach(DataRow i in db.GetRecord(query).Rows)
            {
                cbbLSH.Items.Add(new CBBItem
                {
                    Value = Convert.ToInt32(i["ID_Lop"].ToString()),
                    Text = i["NameLop"].ToString()
                });
            }
            GUI();
        }
        //tao giao dien khi detail form đuọc gọi
        public void GUI()
        {
            if (Check(MSSV)) // neu la Update  
            {
                //hien thi thong tin da co
                string query = "Select * from SV where MSSV ='" + MSSV + "'";
                txtMSSV.Text = db.GetRecord(query).Rows[0]["MSSV"].ToString();
                txtMSSV.Enabled = false;
                txtNameSV.Text = db.GetRecord(query).Rows[0]["NameSV"].ToString();
                txtDTB.Text = db.GetRecord(query).Rows[0]["DTB"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(db.GetRecord(query).Rows[0]["NS"].ToString());
                int id_Lop = Convert.ToInt32(db.GetRecord(query).Rows[0]["ID_Lop"].ToString());
                // hien thi cbbLopSH theo Id_Lop
                foreach (CBBItem i in cbbLSH.Items) //???? co cung kieu doi tuong hay khong ?
                {

                    if (i.Value == id_Lop)
                    {
                        cbbLSH.SelectedItem = i;
                    }
                }

                if (Convert.ToBoolean(db.GetRecord(query).Rows[0]["Gender"].ToString()) == true)
                {
                    rbMale.Checked = true;
                }
                else rbFemale.Checked = true;
                cbAnh.Checked = Convert.ToBoolean(db.GetRecord(query).Rows[0]["Anh"].ToString());
                cbHocBa.Checked = Convert.ToBoolean(db.GetRecord(query).Rows[0]["HocBa"].ToString());
                cbNN.Checked = Convert.ToBoolean(db.GetRecord(query).Rows[0]["CCNN"].ToString());
            }
        }
        //kiem tra SV da ton tai ?
        public bool Check(string mssv)
        {
            string query = "Select * from SV where MSSV ='" + MSSV + "'";
            if(db.GetRecord(query).Rows.Count == 1)
            {
                return true;
            }
            else
            {
               return false;
            }       
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            // dua cac gia tri hien thi tren GUI vao 
            string query = "";
            // kiem tra da dien day du thong tin 
            if(txtMSSV.Text=="" || txtDTB.Text== ""  ||txtNameSV.Text=="" || cbbLSH.SelectedItem == null)
            {
                MessageBox.Show("Thong tin con thieu");
            }
            else //thuc hien Add or Update
            {
                int gender, anh, hocba, ccnn;
                gender = (rbMale.Checked) ? 1 : 0;
                anh = (cbAnh.Checked) ? 1 : 0;
                hocba = (cbHocBa.Checked) ? 1 : 0;
                ccnn = (cbNN.Checked) ? 1 : 0;
                string date = "'" + dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "'";
                if (Check(txtMSSV.Text)) // da ton tai -> Update
                {
                    query = "update SV set NameSV = '" + txtNameSV.Text + "'" + ","
                        + " ID_Lop = " + ((CBBItem)cbbLSH.SelectedItem).Value + ","
                    + " Gender = " + gender + ","
                    + " Anh = " + anh + ","
                    + " HocBa = " + hocba + ","
                    + " CCNN = " + ccnn + ","
                    + " NS = " + date + ","
                    + " DTB = " + txtDTB.Text 
                    + " where (MSSV ='" + MSSV + "')"; //
                }
                else // chua ton tai -> Add
                {
                    query = "Insert into SV  values (" + "'" + txtMSSV.Text + "'" + ","
                     + "'" + ((CBBItem)cbbLSH.SelectedItem).Value + "'" + ","
                     + "'" + txtNameSV.Text + "'" + ","
                     + date + ","
                     + txtDTB.Text + ","
                     + gender + ","
                     + anh + ","
                     + hocba + ","
                     + ccnn + ")";
                }
                db.ExcuteDB(query);
                d(0); //???
            }
            this.Close();

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
