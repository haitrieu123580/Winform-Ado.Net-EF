using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// class dung de them cac record
namespace DemoCodeFirst
{
    
    public class CreateDB :
        CreateDatabaseIfNotExists<QLSV> // tap DB moi neu chua co
        //DropCreateDatabaseIfModelChanges<QLSV> // xoa DB cu tao lai DB moi neu co thay doi quan he
       // DropCreateDatabaseAlways<QLSV>

    {
        protected override void Seed(QLSV context)
        {
           context.LSHes.AddRange(new LSH[]
               {
                new LSH { ID_Lop = 1, NameLop = "DT1"},
                new LSH { ID_Lop = 2, NameLop = "DT2" },
            });
            context.SVs.AddRange(new SV[]
                {
                    new SV{MSSV = "1", ID_Lop = 1, NameSV= "NVA", DTB = 1.1},
                    new SV{MSSV = "2", ID_Lop = 2, NameSV= "NVB", DTB = 2.2},
                    new SV{MSSV = "3", ID_Lop = 1, NameSV ="NVC", DTB = 3.3}
                });

        }
    }
}
