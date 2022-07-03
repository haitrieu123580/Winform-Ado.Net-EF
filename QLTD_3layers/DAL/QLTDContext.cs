using QLTD_3layers.DAL;
using QLTD_3layers.DTO;
using System;
using System.Data.Entity;
using System.Linq;

namespace QLTD_3layers
{
    public class QLTDContext : DbContext
    {
        // Your context has been configured to use a 'QLTD' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLTD_3layers.QLTD' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLTD' 
        // connection string in the application configuration file.
        public QLTDContext()
            : base("name=QLTD")
        {
            Database.SetInitializer<QLTDContext>(new CreateDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<MonAn> monAns { get; set; }
        public DbSet<NguyenLieu> nguyenLieus { get; set; }
        public DbSet<MonAn_NguyenLieu> monAn_NguyenLieus { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}