using EFRemoveManyToManyDemo.Model;
using System.Data.Entity.ModelConfiguration;

namespace EFRemoveManyToManyDemo.Mapping
{
    public class UserConfigurationMapping : EntityTypeConfiguration<User>
    {
        public UserConfigurationMapping()
        {
            Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            Property(x => x.LastName).HasMaxLength(50).IsRequired();
        }
    }
}