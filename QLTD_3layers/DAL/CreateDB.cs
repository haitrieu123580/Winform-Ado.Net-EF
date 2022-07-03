using QLTD_3layers.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTD_3layers.DAL
{
    public class CreateDB
        :CreateDatabaseIfNotExists<QLTDContext>
    {
        protected override void Seed(QLTDContext context)
        {
            context.nguyenLieus.AddRange(new NguyenLieu[]
            {
                new NguyenLieu{ MaNguyenLieu=1, TenNguyenLieu="Bot mi", TinhTrang = true},
                new NguyenLieu{ MaNguyenLieu=2,TenNguyenLieu ="Bot gao", TinhTrang = true},
            });
            context.monAns.AddRange(new MonAn[]
            {
                new MonAn{ MaMonAn = 1,TenMonAn="Banh mi"},
                new MonAn{MaMonAn = 2, TenMonAn="Banh gao"},
            });
            context.monAn_NguyenLieus.AddRange(new MonAn_NguyenLieu[]
            {
                new MonAn_NguyenLieu{ MaMonAn_NguyenLieu="TD01", SoLuong=10, DonViTinh="gram", MaMonAn=1, MaNguyenLieu=1 },
                new MonAn_NguyenLieu{ MaMonAn_NguyenLieu="TD02", SoLuong=20, DonViTinh="gram", MaMonAn=2, MaNguyenLieu=2 },
            });
        }
    }
}
