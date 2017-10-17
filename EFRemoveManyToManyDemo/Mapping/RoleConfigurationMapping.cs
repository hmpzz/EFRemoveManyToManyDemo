using EFRemoveManyToManyDemo.Model;
using System.Data.Entity.ModelConfiguration;

namespace EFRemoveManyToManyDemo.Mapping
{
    public class RoleConfigurationMapping : EntityTypeConfiguration<Role>
    {
        public RoleConfigurationMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                    m.ToTable("LNK_User_Role");
                });
        }
    }
}