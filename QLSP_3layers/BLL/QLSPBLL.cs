using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSP_3layers.DTO;
namespace QLSP_3layers.BLL
{ 
    public class QLSPBLL
    {
        QLSPContext db = new QLSPContext();
        private static QLSPBLL _Instance;
        public static QLSPBLL Instance 
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSPBLL();
                }
                return _Instance;
            }
        }
        public QLSPBLL(){   }
        // ham GetCBBITem
        public List<CBBItem> GetCBBDiaChiItems()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach(DiaChi i in db.DiaChis.ToList())
            { 
                list.Add(new CBBItem
                {
                    Text = i.TenTinh,
                    Value = Convert.ToInt32(i.MaTinh)
                }) ;
            }
            return list;
        }
        // tim cac NCC co maNCC -> dua thanh cac CBBItems
        public List<CBBItem> GetAllCBBNhaCCItems()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach (NhaCungCap i in db.NhaCungCaps.ToList())
            {
                list.Add(new CBBItem
                {
                    Text = i.TenNCC,
                    Value = i.MaNCC
                });
            }
            return list;
        }
        public List<CBBItem>GetCBBNhaCCByMatinh(string maTinh)
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach(NhaCungCap i in db.NhaCungCaps.ToList())
            {
                if(i.MaTinh == maTinh)
                {
                    list.Add(new CBBItem { Text = i.TenNCC, Value = i.MaNCC });
                }
            }
            return list;
        }
        public DiaChi getDiaChiByNhaCC(int maNCC)
        {
            DiaChi diaChi = new DiaChi();
            foreach(DiaChi i in db.DiaChis.ToList())
            {
                if(i.MaTinh== db.NhaCungCaps.Find(maNCC).MaTinh)
                {
                    diaChi = i;
                }
            }
            return diaChi;
        }
        public SanPham GetSPByTenSP(string tenSP)
        {
           
            foreach(SanPham i in db.SanPhams.ToList())
            {
                if(i.TenSP == tenSP)
                {
                    return i;
                }
            }
            return null;
        }
        public SanPham GetSPByMaSP(string maSP)
        {
            foreach (SanPham i in db.SanPhams.ToList())
            {
                if (i.MaSP == maSP)
                {
                    return i;
                }
            }
            return null;
        }
        public List<SanPhamItem> ConvertSPtoSPItem(List<SanPham> data)
        {
            bool tinhtrang = true;
            string tenNCC = "";
            string tenTinh = "";
            List<SanPhamItem> list = new List<SanPhamItem>();
            foreach(SanPham item in data)
            {
                if(item.SoLuong==0)
                {
                    tinhtrang=false;
                }
                foreach (NhaCungCap i in db.NhaCungCaps.ToList())
                {
                    if(i.MaNCC==item.MaNCC)
                    {
                        tenNCC = i.TenNCC;
                        foreach (DiaChi j in db.DiaChis.ToList())
                        {
                            if (j.MaTinh==i.MaTinh)
                            {
                                tenTinh = j.TenTinh;
                            }
                        }
                    }
                }
               
                list.Add(new SanPhamItem
                {
                    TenSP = item.TenSP,
                    Gia = item.Gia,
                    NgayNhap = item.NgayNhap,
                    TinhTrang = tinhtrang,
                    TenNCC = tenNCC,
                    TenTinh=tenTinh,
                }) ;
            }
            return list;
        }
        public List<SanPhamItem> getSPItemByTenTinh(string tenTinh)
        {
            List<SanPhamItem> list = new List<SanPhamItem>();
            foreach (SanPhamItem i in QLSPBLL.Instance.ConvertSPtoSPItem(db.SanPhams.ToList()))
            {
                if (i.TenTinh == tenTinh)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public List<SanPhamItem> getSPItemByTenNCC(string tenNCC)
        {
            List<SanPhamItem> list = new List<SanPhamItem>();
            foreach (SanPhamItem i in QLSPBLL.Instance.ConvertSPtoSPItem(db.SanPhams.ToList()))
            {
                if (i.TenNCC == tenNCC)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public List<SanPhamItem> SearchSanPhamItems(string txt, string tenTinh, string tenNCC)
        {
            List<SanPhamItem> data = new List<SanPhamItem>();
            if(txt == "")
            {
                if(tenTinh =="All"&&tenNCC =="")
                {
                    return ConvertSPtoSPItem(db.SanPhams.ToList());
                }
                if(tenTinh!="All" && tenNCC!="") // lam them cho cbbNCC
                {
                    foreach (SanPhamItem i in getSPItemByTenNCC(tenNCC))
                    {
                        if (i.TenSP.Contains(txt))
                        {
                            data.Add(i);
                        }
                        else if (i.Gia.ToString() == txt)
                        {
                            data.Add(i);
                        }
                    }
                }
                if (tenTinh == "All" && tenNCC != "")
                {
                    foreach (SanPhamItem i in getSPItemByTenNCC(tenNCC))
                    {
                        if (i.TenSP.Contains(txt))
                        {
                            data.Add(i);
                        }
                        else if (i.Gia.ToString() == txt)
                        {
                            data.Add(i);
                        }
                    }
                }
            }
            else
            {
                if(tenTinh == "All" && tenNCC == "")
                {
                    foreach (SanPhamItem i in QLSPBLL.Instance.ConvertSPtoSPItem(db.SanPhams.ToList()))
                    {
                        if (i.TenTinh == txt)
                        {
                            data.Add(i);
                        }
                        else if(i.TenNCC == txt)
                        {
                            data.Add(i);
                        }
                        else if(i.TenSP.Contains(txt))
                        {
                            data.Add(i);
                        }
                        else if(i.Gia.ToString()==txt)
                        {
                            data.Add(i);
                        }    
                    }
                }
                if(tenTinh=="All" && tenNCC !="")
                {
                    foreach(SanPhamItem i in getSPItemByTenNCC(tenNCC))
                    {
                        if(i.TenSP.Contains(txt))
                        {
                            data.Add(i);
                        }
                        else if(i.Gia.ToString() == txt)
                        {
                            data.Add(i);
                        }
                    }
                }
                if(tenTinh!="All"&&tenNCC!="")
                {
                    foreach(SanPhamItem i in getSPItemByTenNCC(tenNCC))
                    {
                        if(i.TenSP.Contains(txt))
                        {
                            data.Add(i);
                        }
                        if(i.Gia.ToString() == txt)
                        {
                            data.Add(i);
                        }
                    }
                }
                if(tenTinh!="All" && tenNCC=="")
                {
                    foreach(SanPhamItem i in getSPItemByTenTinh(tenTinh))
                    {
                        if(i.TenSP.Contains(txt))
                        {
                            data.Add(i);
                        }
                        else if(i.Gia.ToString() == txt)
                        {
                            data.Add(i);
                        }
                        else if(i.TenNCC==txt)
                        {
                            data.Add(i);
                        }
                    }
                }
            }
            return data;
        }
        public void DeleteSPBLL(string maSP)
        {
            var sp = db.SanPhams.Find(maSP);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
        } 
        public List<SanPham> SortSVBLL(string attribute)
        {
            List<SanPham> data = new List<SanPham>();
            if (attribute == "Ten san pham")
            {
                data = db.SanPhams.OrderByDescending(q => q.TenSP).ToList();
            }
            if (attribute == "Gia nhap")
            {
                data = db.SanPhams.OrderByDescending(q => q.Gia).ToList();
            }
            if (attribute == "Tinh trang") // tinh trang phu thuoc vao so luong     
            {
                data = db.SanPhams.OrderByDescending(q => q.SoLuong).ToList();
            }
            return data;
        }
        public void AddUpdate(SanPham sp)
        {
            if (Check(sp.MaSP))
            {

                db.SanPhams.Add(sp);
                db.SaveChanges();

            }
            else
            {
                var temp = db.SanPhams.Where(q => q.MaSP == sp.MaSP).FirstOrDefault();
                temp.TenSP = sp.TenSP;
                temp.MaNCC = sp.MaNCC;
                temp.NgayNhap= sp.NgayNhap;
                temp.SoLuong=sp.SoLuong;
                temp.Gia = sp.Gia;
                temp.MaNCC = sp.MaNCC;
                db.SaveChanges();
            }
        }
        public bool Check(string maSP)
        {
            //true = add, false = update
            bool result = true;
            foreach (SanPham i in db.SanPhams.ToList())
            {
                if (i.MaSP == maSP)
                {
                    result = false;
                }
            }
            return result;
        }

    }
}
