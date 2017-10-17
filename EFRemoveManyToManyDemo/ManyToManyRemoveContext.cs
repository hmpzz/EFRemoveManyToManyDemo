using EFRemoveManyToManyDemo.Mapping;
using EFRemoveManyToManyDemo.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFRemoveManyToManyDemo
{
    public class ManyToManyRemoveContext : DbContext
    {
        public ManyToManyRemoveContext() : base("ManyToManyRemoveContext")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//将Entity Framework Code First在实体类生成对应表时去掉表名的复数用的

            modelBuilder.Configurations.Add(new UserConfigurationMapping());
            modelBuilder.Configurations.Add(new RoleConfigurationMapping());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}