using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTD_3layers.DTO
{
    public class MonAn_NguyenLieu
    {
        public MonAn_NguyenLieu()
        {
            this.MonAns = new HashSet<MonAn>();
            this.NguyenLieus = new HashSet<NguyenLieu>();
        }
        [Key][StringLength(5)][Required]
        public string MaMonAn_NguyenLieu { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        //[Required]
        public int MaMonAn { get; set; }
        //[Required]
        public int MaNguyenLieu { get; set; }
        [ForeignKey("MaMonAn")]     
        public virtual ICollection<MonAn>MonAns { get; set; }
        [ForeignKey("MaNguyenLieu")]
        public virtual ICollection<NguyenLieu> NguyenLieus { get; set; }
    }
}
