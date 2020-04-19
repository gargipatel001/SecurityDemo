using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginConsole.User;

namespace LoginConsole.DbAccess
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContextString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Migrations.Configuration>());
        }
      
        public virtual DbSet<User.User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

    }
}
