using demoQLSV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoQLSV.BLL
{
    public class QLSVBLL
    {
        public QLSV db = new QLSV();
        private static QLSVBLL _Instance;
        public static QLSVBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSVBLL();
                }
                return _Instance;
            }
        }
        public QLSVBLL()
        {

        }
        public List<SV_View> SVtoSV_View(List<SV> l)
        {
            List<SV_View> data = new List<SV_View>();
            foreach(SV s in l)
            {
                string namelop = "";
                foreach(CBBItem item in QLSVBLL.Instance.GetCBBItem())
                {
                    if(s.ID_Lop == item.Value )
                    {
                        namelop = item.Text;
                    }
                }

                data.Add(new SV_View
                {
                    MSSV = s.MSSV,
                    NameSV = s.NameSV,
                    DTB = (double)s.DTB,
                    NameLop = namelop
                }) ;

            }
            return data;
        }

        public List<CBBItem> GetCBBItem()
        {
            List<CBBItem> data = new List<CBBItem>();
     
            
            foreach(LopSH i in  db.LopSHes.Select(p=>p).ToList() )
            {
                data.Add(new CBBItem
                {
                    Text = i.NameLop,
                    Value = i.ID_Lop
                });
            }
            return data;
        }
  
        public List<SV> GetSVByIDLop(int id_lop)
        {

            List<SV> data = new List<SV>();
            if (id_lop == 0)
            {
                data = db.SVs.ToList();
            }
            else
            {
                foreach (SV i in db.SVs.ToList())
                {
                    if (i.ID_Lop == id_lop)
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public List<SV_View> GetSV_ViewByIDLop(int id_lop)
        {
            List<SV> data = QLSVBLL.Instance.GetSVByIDLop(id_lop);
            return QLSVBLL.Instance.SVtoSV_View(data);
        }

        public void AddUpdate(SV s)
        {
            if (Check(s.MSSV))
            {
              
                db.SVs.Add(s);
                db.SaveChanges();
                
            }
            else
            {
                var temp = db.SVs.Where(q => q.MSSV == s.MSSV).FirstOrDefault();
                temp.NameSV = s.NameSV;
                temp.ID_Lop = s.ID_Lop;
                temp.DTB = s.DTB;
                db.SaveChanges();
            }
        }
        public bool Check(string mssv)
        {
            //true = add, false = update
            bool result = true;
            foreach (SV i in db.SVs.ToList())
            {
                if (i.MSSV == mssv)
                {
                    result = false;
                }
            }
            return result;
        }
        public SV GetSVByMSSV(string mssv)
        {
            SV s = db.SVs.Find(mssv);
            return s;
        }
        public void DeleteSVBLL(string mssv)
        {
            var s = db.SVs.Find(mssv);
            db.SVs.Remove(s);
            db.SaveChanges();
        }
        public List<SV> SortSVBLL(string attribute)
        {
            List<SV> data = new List<SV>();
            if (attribute == "MSSV")
            {
                data = db.SVs.OrderByDescending(q => q.MSSV).ToList();
            }
            if (attribute == "NameSV")
            {
                data = db.SVs.OrderByDescending(q => q.NameSV).ToList();
            }
            if (attribute == "ID_Lop")
            {
                data = db.SVs.OrderByDescending(q => q.ID_Lop).ToList();
            }
            if(attribute == "DTB")
            {
                data = db.SVs.OrderByDescending(q => q.DTB).ToList();
            }
            return data;
        }
        public List<SV> SearchSVBLL(int id_lop, string txt)
        {
            List<SV> data = new List<SV>();


            if (id_lop == 0)
            {
                foreach (SV i in db.SVs.ToList())
                {
                    if (i.NameSV.Contains(txt))
                    {
                        data.Add(i);
                    }
                }
            }
            else
            {
                foreach (SV i in db.SVs.ToList())
                {
                    if (i.ID_Lop == id_lop && i.NameSV.Contains(txt))
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
    }
}
