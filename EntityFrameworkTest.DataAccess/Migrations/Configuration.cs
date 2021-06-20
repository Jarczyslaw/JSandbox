namespace EntityFrameworkTest.DataAccess.Migrations
{
    using EntityFrameworkTest.DataAccess.Seeds;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkTest.DataAccess.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyContext context)
        {
            var groups = new GroupsSeed();
            var users = new UsersSeed();

            groups.Seed(context);
            users.Seed(context);

            base.Seed(context);
        }
    }
}