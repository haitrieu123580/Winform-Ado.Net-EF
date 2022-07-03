using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst
{
    public class LSH
    {
        public LSH()
        {
            this.SVs = new HashSet<SV>(); // yeu cau phai co LSH truoc, add record SV sau   
        }
        [Key]
        public int ID_Lop { get; set; }
        public string NameLop { get; set; }
        public virtual ICollection<SV> SVs { get; set; } // quan he 1...*
    }
}
