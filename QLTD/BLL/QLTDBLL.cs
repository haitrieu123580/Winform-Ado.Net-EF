using QLTD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTD.BLL
{
    public  class QLTDBLL
    {
        private QLTDContext db = new QLTDContext();
        private static QLTDBLL _Instance;
        public static QLTDBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLTDBLL();
                }
                return _Instance;
            }
        }
        public List<CBBItem> GetAllCBBMonAn()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach(MonAn i in db.MonAns.ToList())
            {
                list.Add(new CBBItem
                {
                    Text = i.TenMonAn,
                    Value = i.MaMonAn,
                });
            }
            return list;
        }
        public List<ItemView> MonAn_NLtoItemView(List<MonAn_NguyenLieu> data)
        {
            List <ItemView> list = new List<ItemView>();
            int stt = 0;
            foreach(MonAn_NguyenLieu i in data)
            {
                var temp = db.NguyenLieus.Where(q => q.MaNguyenLieu == i.MaNguyenLieu).FirstOrDefault();
                list.Add(new ItemView
                {   
                    STT = stt,
                    // tim ten nl tu ma nl 
                    TenNguyenLieu = temp.TenNguyenLieu,
                    SoLuong = i.SoLuong,
                    DonViTinh = i.DonViTinh,
                    // tinh trang = tinh trang cua nguyen lieu
                    TinhTrang = temp.TinhTrang,
                }) ;
                stt++;
            }
            return list;
        }
        public List<MonAn_NguyenLieu> SearchByMonAn(int maMonAn, string txt)
        {
            List<MonAn_NguyenLieu> list = new List<MonAn_NguyenLieu>();
            if(maMonAn == 0 && txt=="")
            {
                //show toan bo
                list = db.MonAn_Nguyens.ToList();
            }

            else if(maMonAn != 0 && txt!="")
            {
                foreach(MonAn_NguyenLieu i in db.MonAn_Nguyens.ToList())
                {
                    if(i.MaMonAn == maMonAn)
                    {
                        var temp = db.NguyenLieus.Where(q => q.MaNguyenLieu == i.MaNguyenLieu).FirstOrDefault();
                        if(temp.TenNguyenLieu.Contains(txt))
                        {
                            list.Add(i);
                        }
                        else if(i.SoLuong.ToString() == txt)
                        {
                            list.Add(i);
                        }
                        else if(i.DonViTinh == txt)
                        {
                            list.Add(i);
                        }
                    }
                }
            }
            else if (maMonAn != 0 && txt == "")
            {
                foreach (MonAn_NguyenLieu i in db.MonAn_Nguyens.ToList())
                {
                    if (i.MaMonAn == maMonAn)
                    {
                        list.Add(i);
                    }
                }
            }
                return list;
        }
        public void Delete(string tenNguyenLieu)
        {
            var temp = db.NguyenLieus.Where(p => p.TenNguyenLieu == tenNguyenLieu).FirstOrDefault();
            var row = db.MonAn_Nguyens.Where(p=>p.MaNguyenLieu==temp.MaNguyenLieu).FirstOrDefault();
            db.MonAn_Nguyens.Remove(row);
            db.SaveChanges();
        }
        public List<ItemView> Sort(int thuoctinh,int maMonAn)
        {
            List<ItemView> data = new List<ItemView>();
            List<MonAn_NguyenLieu> temp = SearchByMonAn(maMonAn, "");
            data = MonAn_NLtoItemView(temp);
            switch (thuoctinh)
            {
                case -1:
                    return data;
                    break;
                case 0:
                    return data.OrderBy(x => x.TenNguyenLieu).ToList();
                    break;
                case 1:
                    return data.OrderBy(x => x.SoLuong).ToList();
                    break;
                case 2:
                    return data.OrderBy(x => x.DonViTinh).ToList();
                    break;
                case 3:
                    return data.OrderBy(x => x.TinhTrang).ToList();
                    break;
                default:
                    return data;
            }
        }
        public void AddUpdate(MonAn_NguyenLieu s)
        {
            if (Check(s.Ma))
            {

                db.MonAn_Nguyens.Add(s);
                db.SaveChanges();

            }
            else
            {
                var temp = db.MonAn_Nguyens.Where(q => q.Ma == s.Ma).FirstOrDefault();
                temp.Ma = s.Ma;
                temp.DonViTinh = s.DonViTinh;
                temp.SoLuong = s.SoLuong;
                temp.MaMonAn = s.MaMonAn;
                temp.MaNguyenLieu= s.MaNguyenLieu;
                db.SaveChanges();
            }
        }
        public bool Check(string ma)
        {
            //true = add, false = update
            bool result = true;
            foreach(MonAn_NguyenLieu i in db.MonAn_Nguyens.ToList())
            {
                if(i.Ma == ma )
                {
                    result= false;
                    break;
                }
            }
            return result;
        }
        public MonAn_NguyenLieu getMA_NLByTen(string tenNL)
        {
            var temp = db.NguyenLieus.Where(p=>p.TenNguyenLieu ==tenNL).FirstOrDefault();
            return db.MonAn_Nguyens.Where(p=>p.MaNguyenLieu == temp.MaNguyenLieu).FirstOrDefault();
        }
        // dung cho DetailForm
        public MonAn_NguyenLieu getMA_NLByMa(string ma)
        {
            return db.MonAn_Nguyens.Where(p => p.Ma == ma).FirstOrDefault();
        }
        //dung cho loadCBBTenNL o Detailform
        public List<CBBItem> getAllCBBItemNguyenLieu()
        {
            List <CBBItem> list = new List<CBBItem>();
            foreach (NguyenLieu i in db.NguyenLieus.ToList())
            {
                list.Add(new CBBItem
                {
                    Text = i.TenNguyenLieu,
                    Value = i.MaNguyenLieu,
                });
            }
            return list;
        }
        public List<NguyenLieu> getAllNguyenLieu()
        {
            return db.NguyenLieus.ToList();
        }
        public List<MonAn_NguyenLieu> getAllMA_NL()
        {
            return db.MonAn_Nguyens.ToList();
        }
    }

}
