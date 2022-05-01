using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK
{
    public class Data
    {
        private static Data _Instance; // doi tuong duy nhat cua lop Data
        public static Data Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Data();
                }
                return _Instance;
            }
            set { }
        }
        public DataTable DT;
        public Data()
        {
            DT = new DataTable();
            DT.Columns.AddRange(new DataColumn[] {
                new DataColumn{DataType = typeof(string),ColumnName = "MBB" },
                new DataColumn{DataType = typeof(string),ColumnName = "TenBB" },
                new DataColumn{DataType = typeof(string),ColumnName = "TenTG" },
                new DataColumn{DataType = typeof(string),ColumnName = "TenTC" },
                new DataColumn{DataType = typeof(string),ColumnName = "LoaiTC" },
                new DataColumn{DataType = typeof(string),ColumnName = "NamXB" },
                new DataColumn{DataType = typeof(string),ColumnName = "NhaXB" },
            });
            DT.Rows.Add("001", "BBA", "NVA","01", "TC1", "2020", "NXB1");
            DT.Rows.Add("002", "BBB", "NVB","02", "TC2", "2021", "NXB2");
            DT.Rows.Add("003", "BBC", "NVC", "03", "TC3","2022", "NXB3");
        }
        public void AddDT(BB s)
        {
            DT.Rows.Add(s.MBB,s.TenBB, s.TenTG, s.TenTC, s.LoaiTC, s.NamXB, s.NhaXB);
        }
        //update row cua DT
        public void UpdateDT(BB s)
        {
           
        }
        public void DelDT(string mbb) // xoa row 
        {
            foreach (DataRow dr in DT.Rows)
            {
                if (dr["MBB"].ToString() == mbb)
                {
                    DT.Rows.Remove(dr);
                    DT.AcceptChanges();
                    break;
                }
            }
        }

    }
}
