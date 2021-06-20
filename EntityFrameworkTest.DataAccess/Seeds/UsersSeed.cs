using EntityFrameworkTest.DataAccess.Entities;
using System.Linq;

namespace EntityFrameworkTest.DataAccess.Seeds
{
    public class UsersSeed
    {
        public void Seed(MyContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Id = 1,
                    Name = "User1",
                    GroupId = 1
                });

                context.Users.Add(new User
                {
                    Id = 2,
                    Name = "User2",
                    GroupId = 1
                });

                context.Users.Add(new User
                {
                    Id = 3,
                    Name = "User3",
                    GroupId = 2
                });

                context.Users.Add(new User
                {
                    Id = 4,
                    Name = "User4",
                    GroupId = 2
                });

                context.Users.Add(new User
                {
                    Id = 5,
                    Name = "User5",
                    GroupId = 2
                });

                context.Users.Add(new User
                {
                    Id = 6,
                    Name = "User6",
                    GroupId = 3
                });

                context.Users.Add(new User
                {
                    Id = 7,
                    Name = "User7",
                });
                context.SaveChanges();
            }
        }
    }
}