using QLSP_3layers.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_3layers.DAL
{
    public class CreateDB 
        : CreateDatabaseIfNotExists<QLSPContext>
    {
        protected override void Seed(QLSPContext context)
        {
            context.SanPhams.AddRange(new SanPham[]
                {
                    new SanPham{ MaSP = "SP01",TenSP="Pepsi", MaNCC=1, Gia=100.5, NgayNhap=DateTime.Now, SoLuong= 100 },
                    new SanPham{ MaSP = "SP02",TenSP="CocaCola", MaNCC=2, Gia=100, NgayNhap=DateTime.Now, SoLuong= 200 },
                }) ;
            context.NhaCungCaps.AddRange(new NhaCungCap[]
                {
                    new NhaCungCap{ MaNCC = 1, TenNCC="NCC01", MaTinh="43"},
                    new NhaCungCap{ MaNCC = 2, TenNCC="NCC02", MaTinh="92"},
                });
            context.DiaChis.AddRange(new DiaChi[]
                {
                    new DiaChi{MaTinh = "43", TenTinh="Da Nang"},
                    new DiaChi{MaTinh = "92", TenTinh="Quang Nam"},
                });

        }
    }
}
