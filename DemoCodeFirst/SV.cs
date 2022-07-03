using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst
{
    [Table("SinhVien")] // thay doi ten Table ( mac dinh ten Table giong voi ten Class)
    public class SV
    {
        [Key][StringLength(9)][Required]// dinh nghia khoa chinh - do dai 
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        [Required] // yeu cau NotNull
        public int ID_Lop { get; set; }
        public double DTB { get; set; }
        [ForeignKey("ID_Lop")] // quan he giua cac bang can phai thong qua khoa ngoai
        public virtual LSH LSH { get; set; } //tao navigation properties

    }
}
