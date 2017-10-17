namespace EFRemoveManyToManyDemo.Migrations
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFRemoveManyToManyDemo.ManyToManyRemoveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFRemoveManyToManyDemo.ManyToManyRemoveContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var roles = new List<Role> {
                new Role{ Id=1,Name="超级管理员" },
                new Role{ Id=2,Name="管理员" },
                new Role{ Id=3,Name="一般用户" }
            };

            var users = new List<User> {
                new User {Id=1,FirstName="Kobe",LastName="Bryant",CreatedOn=DateTime.Now,Roles=roles },
                 new User {Id=2,FirstName="Chris",LastName="Paul",CreatedOn=DateTime.Now,Roles=roles.Where(x=>x.Id==2).ToList() },
                 new User {Id=3,FirstName="Jerimy",LastName="Lin",CreatedOn=DateTime.Now,Roles=roles.Take(2).ToList()}
            };



            foreach (Role item in roles)
            {
                context.Roles.Add(item);
            }


            foreach (User item in users)
            {
                context.Users.AddOrUpdate(item);

            }
        }
    }
}
