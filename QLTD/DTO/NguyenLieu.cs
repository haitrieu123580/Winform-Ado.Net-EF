using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTD.DTO
{
    public class NguyenLieu
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public bool TinhTrang { get; set; }

    }
}
