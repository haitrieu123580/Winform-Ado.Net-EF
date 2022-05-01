using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// class DataSV : stora
namespace BT
{
    // dung de khoi tao co so du lieu; co khoa static la _Instance dung de tao duy nhat 1 co so du lieu
    // la DataTable
    public class DataSV
    {
        // class DataSV co bien static _Instance 
        // de tao duy nhat 1 Co so du lieu 
        public static DataSV _Instance; 
        public static DataSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataSV();
                }
                return _Instance;
            }
            set { }
        }
        public DataTable DTSV;
        public DataSV()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[] {
                new DataColumn{DataType = typeof(string),ColumnName = "MSSV" },
                new DataColumn{DataType = typeof(string),ColumnName = "NameSV" },
                new DataColumn{DataType = typeof(string),ColumnName = "LopSH" },
                new DataColumn{DataType = typeof(bool),ColumnName = "Gender" },
                new DataColumn{DataType = typeof(DateTime),ColumnName = "NS" },
                new DataColumn{DataType = typeof(double),ColumnName = "DTB" },
                new DataColumn{DataType = typeof(bool),ColumnName = "Anh" },
                new DataColumn{DataType = typeof(bool),ColumnName = "HB" },
                new DataColumn{DataType = typeof(bool),ColumnName = "CCNN" },
            });
            DTSV.Rows.Add("001","A","20T",true, DateTime.Now, 3,true, true, true );
            DTSV.Rows.Add("002", "K", "21T", true, DateTime.Now, 1, false, true, true);
            DTSV.Rows.Add("003", "C", "19T", false, DateTime.Now, 10, false, true, false);
        }
        // them row (SV) vao DTSV
        public void AddDTSV(SV s)
        {
            DTSV.Rows.Add(s.MSSV, s.NameSV, s.LopSH, s.Gender, s.NS, s.DTB, s.Anh, s.HB, s.CCNN);
        }
        //update row cua DTSV
        public void UpdateDTSV(SV s)
        {
            foreach (DataRow dr in DTSV.Rows)
            {
                if (dr["MSSV"].ToString() == s.MSSV)
                {
                    dr["NameSV"] = s.NameSV;
                    dr["lopSH"] = s.NameSV;
                    dr["Gender"] = s.Gender;
                    dr["DTB"] = s.DTB;
                    dr["NS"] = s.NS;
                    dr["Anh"] = s.Anh;
                    dr["HB"] = s.Anh;
                    dr["CCNN"] = s.CCNN;
                    break;
                }
            }
        }
        public void DelDTSV(string mssv) // xoa row co MSSV = txtMSSV
        {
            foreach(DataRow dr in DTSV.Rows)
            {
                if(dr["MSSV"].ToString() == mssv)
                {
                   DTSV.Rows.Remove(dr);
                   DTSV.AcceptChanges();
                    break;
                }
            }
        }
    }
} 