using _3_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer.DAL
{
    // lay du lieu tu cac DB -> tra ve List<> cac doi tuong, 1 record = 1 doi tuong
    // thuoc tang DAL: thuc hien truy van va thuc thi
    
    public class QLSVDAL
    {
        // tao khoa _Instance
        private static QLSVDAL _Instance;
        public static QLSVDAL Instance 
        { get 
            { 
                if(_Instance == null)
                {
                    _Instance = new QLSVDAL();
                }
                return _Instance; 
            } 
        }
        public QLSVDAL()
        {

        }
        
        public List<SV> GetAllSVDAL() // lay tat ca cac record trong SV -> List<SV> de thuc hien nghiep vu
        {
            List<SV> data = new List<SV>();
            foreach(DataRow i in DBHelper.Instance.GetRecords("select * from SV ").Rows)
            {
                data.Add(GetSVByDataRow(i));
            }
            return data;
        }
        
        public SV GetSVByDataRow(DataRow i) // chuyen cac record -> doi tuong SV
        {
            return new SV
            {
                MSSV = i["MSSV"].ToString(),
                NameSV = i["NameSV"].ToString(),
                ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString()),
                DTB = Convert.ToDouble(i["DTB"].ToString())
            };
        }

        public List<LSH> GetAllLSHDAL() // lay tat ca cac record trong LopSH -> List<LSH> de thuc hien nghiep vu
        {
            List<LSH> data = new List<LSH>();
            foreach (DataRow i in DBHelper.Instance.GetRecords("select * from LopSH ").Rows)
            {
                data.Add(GetLSHByDataRow(i));
            }
            return data;
        }

        public LSH GetLSHByDataRow(DataRow i) // chuyen cac record -> doi tuong LSH
        {
            return new LSH
            {
               
                ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString()),
                NameLop = i["NameLop"].ToString()
            };
        }
        //public List<SV_View> GetAllSVViews()
        //{
        //    List<SV_View> data = new List<SV_View>();
        //    foreach (DataRow i in DBHelper.Instance.GetRecords("select * from SV").Rows)
        //    {
        //        string namelop = "";
        //        foreach (LSH j in QLSVDAL.Instance.GetAllLSHDAL())
        //        {
        //            if (Convert.ToInt32(i["ID_lop"].ToString()) == j.ID_Lop)
        //            {
        //                namelop = j.NameLop;
        //            }
        //        }
        //        data.Add(new SV_View
        //        {
        //            MSSV = i["MSSV"].ToString(),
        //            NameSV = i["NameSV"].ToString(),
        //            NameLop = namelop,
        //            DTB = Convert.ToDouble(i["DTB"].ToString())
        //        });
        //    }
        //    return data;
        //}
        public void AddSVDAL(SV s)// them doi tuong SV vao DB
        {
            string query = "insert into SV (MSSV, NameSV, ID_Lop, DTB) values ( '" + s.MSSV +"', " +"'" +s.NameSV +"', " + s.ID_Lop +", " + s.DTB +")";
            DBHelper.Instance.ExecuteDB(query);
        }
       public void UpdateSVDAL(SV s)// update doi tuong SV 
       {
            string query = "update SV set NameSV = '" + s.NameSV + "', ID_Lop = " + s.ID_Lop + ", DTB = " + s.DTB + " where MSSV = '" + s.MSSV + "'";
            DBHelper.Instance.ExecuteDB(query);
       }
        public List<SV> SearchSVDAL(int id_lop, string txt )
        {
            string query = "";
            List<SV> data = new List<SV>();
            if(id_lop ==0 ) // truong hop tim trong tat ca cac record SV
            {
                 query = "select * from SV where NameSV like '%" + txt + "%'";
            }
            else
            {
                query = "select * from SV where ID_Lop = " + id_lop + " and NameSV like '%" + txt + "%'";
                
            }
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(GetSVByDataRow(i));
            }
            return data;
        }
        public void DeleteSVDAL(string mssv)
        {
            string query = "delete from SV where MSSV = '" + mssv + "'";
            DBHelper.Instance.ExecuteDB(query);
        }
        public List<SV> SortSVDAL(string attrivbute)
        {
            string query = "select * from SV ORDER BY " + attrivbute + " desc";
            List<SV> data = new List<SV>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(GetSVByDataRow(i));
            }
            return data;
        }
    }
}
