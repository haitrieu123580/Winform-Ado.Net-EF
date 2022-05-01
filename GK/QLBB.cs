using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK
{
    public class QLBB
    {
        public List<BB> GetAllBB()
        {
            List<BB> data = new List<BB>();
            foreach (DataRow r in Data.Instance.DT.Rows)
            {
                data.Add(GetBBByRow(r));
            }
            return data;
        }
        public BB GetBBByRow(DataRow r)
        {
            BB bb = new BB();
            bb.MBB = r["MBB"].ToString() ;
            bb.TenBB = r["TenBB"].ToString();
            bb.TenTC = r["TenTC"].ToString();
            bb.TenTG = r["TenTG"].ToString();
            bb.LoaiTC = r["LoaiTC"].ToString();
            bb.NamXB = r["NamXB"].ToString();
            bb.NhaXB = r["NhaXB"].ToString();
            return bb;
        }
     
        public List<string> ListLoaiTC()
        {
            List<string> list = new List<string>();
            foreach (BB b in GetAllBB())
            {
                list.Add(b.LoaiTC);
            }
            return list; // chua distinct
        }
        public List<string> ListNamXB()
        {
            List<string> list = new List<string>();
            foreach (BB b in GetAllBB())
            {
                list.Add(b.NamXB);
            }
            return list; // chua distinct
        }
        public List<string> ListNhaXB()
        {
            List<string> list = new List<string>();
            foreach (BB b in GetAllBB())
            {
                list.Add(b.NhaXB);
            }
            return list; // chua distinct
        }
       
        public BB GetBBByMBB(string mbb)
        {
            BB b = new BB();
            foreach (BB i in GetAllBB())
            {
                if (i.MBB == mbb)
                    b = i;
                break;
            }
            return b;
        }
        public List<BB> SearchBB(string ltc, string nhaxb, string namxb, string txt)
        {
            // chua search ( chi moi show)
            List<BB> data = new List<BB>();
            if (ltc == "All" && nhaxb =="All" && namxb =="All")
            {
                foreach (BB i in GetAllBB())
                {
                    if (i.TenBB.Contains(txt))
                    {
                        data.Add(i);
                    }
                }
            }
            else
            {
                foreach (BB i in GetAllBB())
                {
                    if (i.LoaiTC == ltc && i.NamXB == namxb && i.NhaXB == nhaxb && i.TenBB.Contains(txt))
                    {
                        data.Add(i);
                    }
                    //if(ltc=="All")
                    //{
                    //    if (i.NamXB == namxb && i.NhaXB == nhaxb && i.TenBB.Contains(txt))
                    //    {
                    //        data.Add(i);
                    //    }
                    //}
                }
            }
            return data;
        }
        // del
        public void DelBB(List<string> MBBdel)
        {
            foreach (string i in MBBdel)
            {
                Data.Instance.DelDT(i);
            }
        }
        // add
        public void AddBB(BB s)
        {
            Data.Instance.AddDT(s);
        }

    }
}
