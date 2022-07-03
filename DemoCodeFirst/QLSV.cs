using System;
using System.Data.Entity;
using System.Linq;

namespace DemoCodeFirst
{
    public class QLSV : DbContext
    {
        // Your context has been configured to use a 'QLSV' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DemoCodeFirst.QLSV' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLSV' 
        // connection string in the application configuration file.
        public QLSV()
            : base("name=QLSV")
        {
            Database.SetInitializer<QLSV>(new CreateDB());
        }
        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<LSH> LSHes { get; set; }
        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}