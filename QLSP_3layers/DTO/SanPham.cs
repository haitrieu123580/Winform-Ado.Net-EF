using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_3layers.DTO
{
    public class SanPham
    {
        // 1 san pham chi thuoc ve 1 nha cung cap
        [Key][StringLength(10)]
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double Gia { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SoLuong { get; set; }
        public int MaNCC { get; set; }
        //tao navigation property
        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }

    }
}
