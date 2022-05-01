using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT
{
    // moi 1 row trong dataTabe ung voi 1 sinh vien
    // tuy nhien khi lam viec thi can thong qua tang trung gian la class SV chu khong the chinh sua truc tiep len DataTable
    // co the xem day la 1 phan cua tang trung gian
    public class SV
    {
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        public string LopSH { get; set; }
        public bool Gender { get; set; }
        public double DTB { get; set; }
        public DateTime NS { get; set; }
        public bool Anh { get; set; }
        public bool HB { get; set; }
        public bool CCNN { get; set; }
    }
}
