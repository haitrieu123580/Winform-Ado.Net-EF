using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_3layers.DTO
{
    public class DiaChi
    {
        // 1 dia chi co the co nhieu nha cung cap
        public DiaChi()
        {
            this.NhaCungCaps =  new HashSet<NhaCungCap>();
        }
        [Key][StringLength(2)][Required]
        public string MaTinh { get; set; }  
        public string TenTinh { get; set; }
        public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; }
    }
}
