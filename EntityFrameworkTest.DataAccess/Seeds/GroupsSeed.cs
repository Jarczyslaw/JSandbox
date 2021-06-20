using EntityFrameworkTest.DataAccess.Entities;
using System.Linq;

namespace EntityFrameworkTest.DataAccess.Seeds
{
    public class GroupsSeed
    {
        public void Seed(MyContext context)
        {
            if (!context.Groups.Any())
            {
                context.Groups.Add(new Group
                {
                    Id = 1,
                    Name = "Group1"
                });
                context.Groups.Add(new Group
                {
                    Id = 2,
                    Name = "Group2"
                });
                context.Groups.Add(new Group
                {
                    Id = 3,
                    Name = "Group3"
                });
                context.SaveChanges();
            }
        }
    }
}