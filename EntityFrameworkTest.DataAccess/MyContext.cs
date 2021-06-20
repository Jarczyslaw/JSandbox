using EntityFrameworkTest.DataAccess.Entities;
using EntityFrameworkTest.DataAccess.Migrations;
using System.Data.Entity;

namespace EntityFrameworkTest.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("EntityFrameworkTest")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, Configuration>());
            // inne initializery: CreateDatabaseIfNotExists (domyślny), DropCreateDatabaseWhenModelChanges, DropCreateDatabaseAlways

            modelBuilder.HasDefaultSchema(nameof(MyContext));
            base.OnModelCreating(modelBuilder);
        }
    }
}