using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTD.DTO
{
    public class MonAn_NguyenLieu
    {
        public MonAn_NguyenLieu()
        {
           
        }
        [Key][StringLength(5)]
        public string Ma { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        
        public int MaMonAn { get; set; }
        
        public int MaNguyenLieu { get; set; } 
        [ForeignKey("MaMonAn")]
        public virtual MonAn MonAn { get; set; }
        [ForeignKey("MaNguyenLieu")]
        public virtual NguyenLieu NguyenLieus { get; set; }
    }
}
