using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_3layers.DTO
{
    public class NhaCungCap
    {
        // 1 nha cung cap chi thuoc ve 1 dia chi
        // 1 nha cung cap co nhieu san pham
        public NhaCungCap()
        {
            this.SanPhams = new HashSet<SanPham>();   
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNCC { get; set; } //tu tang
        public string TenNCC { get; set; }
        public string MaTinh { get; set; }
        [ForeignKey("MaTinh")]
        public virtual DiaChi DiaChi { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }


    }
}
