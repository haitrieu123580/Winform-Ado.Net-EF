using _3_Layer.DAL;
using _3_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer.BLL
{
    public class QLSVBLL
    {
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
        public List<CBBItem> GetCBBItem()
        {
            List<CBBItem> data = new List<CBBItem>();
            foreach(LSH i in QLSVDAL.Instance.GetAllLSHDAL())
            {
                data.Add(new CBBItem
                {
                    Text = i.NameLop,
                    Value = i.ID_Lop
                }) ;
            }
            return data;
        }
        public List<SV> GetSVByIDLop(int id_lop) // thong qua QLSVDAL ( tang DAL) de lay List<SV>
        {
            if(id_lop == 0 )
            {
                return QLSVDAL.Instance.GetAllSVDAL();
            }
            else
            {
                List<SV> data = new List<SV>();
                foreach(SV i in QLSVDAL.Instance.GetAllSVDAL())
                {
                    if (i.ID_Lop == id_lop)
                    {
                        data.Add(i);
                    }
                }
                return data;
            }
        }
        public List<SV_View> GetSVViewByIDLop(int id_lop)
        {
            List<SV_View> data = new List<SV_View>();
            foreach(SV i in QLSVBLL.Instance.GetSVByIDLop(id_lop))
            {
                string nameLop = "";
                foreach (LSH j in QLSVDAL.Instance.GetAllLSHDAL())  // tim trong LSH  Lop co id_lop
                {
                    if (j.ID_Lop == id_lop)
                    {
                        nameLop = j.NameLop;
                        break;
                    }
                }
                data.Add(new SV_View
                {
                    MSSV = i.MSSV,
                    NameSV = i.NameSV,
                   
                    NameLop = nameLop,
                    DTB = i.DTB,
                }) ;
               
            }
            return data;
        }
       
        public void AddUpdate(SV s)
        {
            if (Check(s.MSSV))
            {
                QLSVDAL.Instance.AddSVDAL(s);
            }
            else
            {
                QLSVDAL.Instance.UpdateSVDAL(s);
            }
        }
        public bool Check(string mssv)
        {
            //true = add, false = update
            bool result = true;
           foreach(SV i in QLSVDAL.Instance.GetAllSVDAL())
            {
                if(i.MSSV == mssv)
                {
                    result = false;
                }
            }
                return result;
        }
        public SV GetSVByMSSV(string mssv)
        {
            SV sv = new SV();
            foreach (SV i in QLSVDAL.Instance.GetAllSVDAL())
            {
                if (i.MSSV == mssv)
                {
                    sv = i;
                    break;
                }
            }
            return sv;
        }
        public void DeleteSVBLL(string mssv)
        {
            QLSVDAL.Instance.DeleteSVDAL(mssv);
        }
        public List<SV> SortSVBLL(string attribute)
        {
            return QLSVDAL.Instance.SortSVDAL(attribute);
        }
        public List<SV> SearchSVBLL(int id_lop, string txt)
        {
            return QLSVDAL.Instance.SearchSVDAL(id_lop, txt);
        }
        public List<SV_View> SVtoSV_View(List<SV> list)
        {
            List<SV_View> data = new List<SV_View>();
            foreach (SV sv in list )
            {
                string namelop = "";
                foreach(CBBItem i in QLSVBLL.Instance.GetCBBItem())
                {
                    if(i.Value == sv.ID_Lop)
                    {
                        namelop = i.Text;
                    }
                }
                data.Add(new SV_View
                {
                    MSSV = sv.MSSV,
                    NameSV = sv.NameSV,
                    NameLop = namelop,
                    DTB = sv.DTB
                });
            }
            return data;
        }
    }

}
