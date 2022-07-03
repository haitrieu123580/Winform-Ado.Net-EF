using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_3layers.DTO
{
    // hien thi thong tin len DataGridView1
    public  class SanPhamItem
    {
       // public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double Gia { get; set; }
        public DateTime NgayNhap { get; set; }
        //public int SoLuong { get; set; }
        public bool TinhTrang { get; set; }
       // public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string TenTinh { get; set; }
    }
}
