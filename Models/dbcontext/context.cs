
using Microsoft.EntityFrameworkCore;

namespace sms{

  public class context:DbContext
  {

         public DbSet<tbl_user> tblUsers { get; set; }
         public DbSet<tbl_sms> tbl_smss { get; set; }


         protected override void OnConfiguring(DbContextOptionsBuilder db)
         {
            db.UseSqlServer("data source=.;initial catalog=shop;integrated security=true;");
         }

  }

}