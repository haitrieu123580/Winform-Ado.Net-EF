using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT
{

    //class QLSV la lop thuc hien cac chuc nang nghiep vu
    // la lop dung de thao voi du lieu ( o day la cac sinh vien) (quan li cac doi tuong sinh vien)
    // class QLSV khong tham gia vao chinh sua du lieu tren DataTable DTSV
    public class QLSV
    {
       // lay danh sach SV trong DataTable DTSV
       public List<SV> GetAllSV()
       {
            List<SV> data = new List<SV>();
            foreach(DataRow r in DataSV.Instance.DTSV.Rows)
            {
                data.Add(GetSVByRow(r));
            }
            return data;
       }
        // lay SV tu row trong DTSV
        public SV GetSVByRow(DataRow r)
        {
            SV sv = new SV();
            sv.MSSV = r["MSSV"].ToString();
            sv.NameSV = r["NameSV"].ToString();
            sv.LopSH = r["LopSH"].ToString();
            sv.Gender = Convert.ToBoolean(r["Gender"].ToString());
            sv.NS = Convert.ToDateTime(r["NS"].ToString());
            sv.DTB = Convert.ToDouble(r["DTB"].ToString());
            sv.Anh = Convert.ToBoolean(r["Anh"].ToString());
            sv.HB = Convert.ToBoolean(r["HB"].ToString());
            sv.CCNN = Convert.ToBoolean(r["CCNN"].ToString());
            return sv;
        }
        //Lay cac lopSH tu danh sach SV
        public List<string> ListLSH()
        {
            List<string> list = new List<string>();
            foreach(SV sv in GetAllSV())
            {
                list.Add(sv.LopSH);
            }
            return list; // chua distinct
        }
        // tra ve list cac SV co cung LopSH ( chuc nang Show)
        public List<SV> GetSVByLSH(string LSH)
        {
            List<SV> data = new List<SV>(); // data cho DataGridView
            if(LSH =="All")
            {
                data = GetAllSV();
            }
            else
            {
                foreach (SV sv in GetAllSV())
                {
                   if(sv.LopSH == LSH)
                    {
                        data.Add(sv);
                    }
                }
            }
            return data;
        }
        // them SV vao DTSV 
        public void AddSV(SV s)
        {
            DataSV.Instance.AddDTSV(s);
        }
        // lay SV theo MSSV 
        public SV GetSVByMSSV(string mssv)
        {
            SV s = new SV();
            foreach(SV sv in GetAllSV())
            {
                if(sv.MSSV == mssv)
                    s = sv;
                break;
            }
            return s;
        }
        // search cac SV co cung LSH va txt dieu kien 
        public List<SV> SearchSV(string LSH, string txt)
        {
            List<SV> data = new List<SV>();
            if(LSH =="All")
            {
                foreach(SV sv in GetAllSV())
                {
                    data.Add(sv);
                }
            }
            else
            {
                foreach(SV s in GetAllSV())
                {
                    if(s.LopSH==LSH && s.MSSV == txt)
                    {
                        data.Add(s);
                    }
                }
            }
            return data;
        }
        // Update: 
        public void UpdateSV(SV s)
        {
            DataSV.Instance.UpdateDTSV(s);
        }
        public void AddUpdate(SV s)
        {
            bool add = true;
            foreach(SV sv in GetAllSV())
            {
                if(sv.MSSV == s.MSSV)
                {
                    add = false;
                    break;
                }
                if(add)
                    AddSV(s);
                else
                    UpdateSV(s);
            }
        }
        // DelSV : -> xoa SV khoi DTSV theo MSSV
        public void DelSV(List<string> MSSVdel)
        {
            foreach (string i in MSSVdel)
            {
                DataSV.Instance.DelDTSV(i);
            }
        }
       
    }
}
