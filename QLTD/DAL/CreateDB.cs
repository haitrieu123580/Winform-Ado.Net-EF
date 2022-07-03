using QLTD.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTD.DAL
{
    public class CreateDB
        : CreateDatabaseIfNotExists<QLTDContext>
    {
        protected override void Seed(QLTDContext context)
        {
            context.NguyenLieus.AddRange(new NguyenLieu[]
            {
                new NguyenLieu{ MaNguyenLieu = 1, TenNguyenLieu ="Bot mi", TinhTrang = true},
                new NguyenLieu{ MaNguyenLieu = 2, TenNguyenLieu ="Bot gao", TinhTrang = true},
            });
            context.MonAns.AddRange(new MonAn[]
            {
                new MonAn{MaMonAn = 1, TenMonAn="Banh mi"},
                 new MonAn{MaMonAn = 2, TenMonAn="Banh gao"},
            });
            context.MonAn_Nguyens.AddRange(new MonAn_NguyenLieu[]
                {
                    new MonAn_NguyenLieu{Ma ="TD001", MaMonAn= 1, DonViTinh="gram", MaNguyenLieu = 1, SoLuong = 10},
                    new MonAn_NguyenLieu{Ma ="TD002", MaMonAn= 2, DonViTinh="gram", MaNguyenLieu = 2, SoLuong = 20},
                });
            base.Seed(context);
        }
    }
}
