using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer.DTO
{
    // trong DB SV ID_Lop co dang string :(
    public  class SV
    {
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        public int ID_Lop { get; set; }
        public double DTB { get; set; }
    }
}
