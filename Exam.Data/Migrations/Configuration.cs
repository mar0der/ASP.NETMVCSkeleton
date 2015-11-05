namespace Exam.Data.Migrations
{
    #region

    using System.Data.Entity.Migrations;
    using System.Linq;

    using Exam.Common;
    using Exam.Data.Repositories;
    using Exam.Models.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    #endregion

    public sealed class Configuration : DbMigrationsConfiguration<ExamDbContext>
    {
        private ExamDbContext context;

        private RandomGenerator random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(ExamDbContext eventsDbContext)
        {
            this.context = eventsDbContext;

            // Create role
            this.CreateRole(GlobalConstants.AdminRole);

            // Create administrator
            this.CreateUser(GlobalConstants.AdminUsername, GlobalConstants.AdminRole);

            // Create several users
            for (var i = 0; i < GlobalConstants.MaxUsersCreated; i++)
            {
                this.CreateUser(GlobalConstants.UsernamePrefix + i);
            }

  

        }

        private void CreateUser(string username, string role = null)
        {
            var userManager = new UserManager<User>(new UserStore<User>(this.context));
            if (userManager.FindByName(username) == null)
            {
                var user = new User
                {
                    UserName = username,
                    Email = username + "@admin.com",
                    PasswordHash =
                        "ADDqeu799LPu2MFv/G9l9Dc3W5aM60JfeYUQx8JzZIkXL+IJ0SVahuH+m6/3efWFqw=="
                    // pass is 123
                };

                var result = userManager.Create(user);

                if (result.Succeeded && role != null)
                {
                    userManager.AddToRole(user.Id, role);
                }
            }
        }

        private void CreateRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole();
                role.Name = roleName;
                roleManager.Create(role);
            }
        }


        private User GetRandomUser(string namePrefix, int countUsers)
        {
            var username = namePrefix + this.random.RandomNumber(countUsers);
            var user = this.context.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                user = this.context.Users.First(u => u.UserName == GlobalConstants.AdminUsername);
            }
            return user;
        }

        /// ###############copy above ###########################3

    }
}