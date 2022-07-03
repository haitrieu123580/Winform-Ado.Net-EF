using QLTD.DAL;
using QLTD.DTO;
using System;
using System.Data.Entity;
using System.Linq;

namespace QLTD
{
    public class QLTDContext : DbContext
    {
        // Your context has been configured to use a 'QLTDContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLTD.QLTDContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLTDContext' 
        // connection string in the application configuration file.
        public QLTDContext()
            : base("name=QLTDContext")
        {
            Database.SetInitializer<QLTDContext>(new CreateDB());
            
        }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }
        public virtual DbSet<MonAn_NguyenLieu> MonAn_Nguyens { get; set; }

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