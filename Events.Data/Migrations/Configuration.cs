namespace Events.Data.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    using Events.Common;
    using Events.Data.Repositories;
    using Events.Models.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    #endregion

    public sealed class Configuration : DbMigrationsConfiguration<EventsDbContext>
    {
        private EventsDbContext context;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EventsDbContext eventsDbContext)
        {
            this.context = eventsDbContext;
             
            //Create role
            this.CreateRole(GlobalConstants.AdminRole);

            //Create administrator
            this.CreateUser("mar0der", GlobalConstants.AdminRole);

            //Create several users
            for (int i = 1; i < 6; i++)
            {
                this.CreateUser("pesho" + i);
            }
        }

        private void CreateUser(string username, string role = null)
        {
            var userManager = new UserManager<User>(new UserStore<User>(this.context));
            if (userManager.FindByName(username) == null)
            {
                var user = new User()
                               {
                                   UserName = username,
                                   Email = username + "@gmail.com",
                                   PasswordHash = "ADDqeu799LPu2MFv/G9l9Dc3W5aM60JfeYUQx8JzZIkXL+IJ0SVahuH+m6/3efWFqw=="
                                   //pass is 123
                               };

                var result = userManager.Create(user);

                if (result.Succeeded == true && role != null)
                {
                    userManager.AddToRole(user.Id, role);
                }
            }
        }

        private void CreateRole(string roleName)
        {
            var roleManager =
                new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(this.context));
            if (!roleManager.RoleExists(roleName))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                roleManager.Create(role);
            }
        }
    }
}