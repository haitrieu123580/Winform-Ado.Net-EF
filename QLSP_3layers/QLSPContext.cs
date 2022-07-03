using QLSP_3layers.DAL;
using QLSP_3layers.DTO;
using System;
using System.Data.Entity;
using System.Linq;

namespace QLSP_3layers
{
    public class QLSPContext : DbContext
    {
        // Your context has been configured to use a 'QLSP' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLSP_3layers.QLSP' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLSP' 
        // connection string in the application configuration file.
        public QLSPContext()
            : base("name=QLSP")
        {
            //khoi tao du lieu ban dau cho cac bang
            Database.SetInitializer<QLSPContext>(new CreateDB());
        }
        //khai bao cac Bang 
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}