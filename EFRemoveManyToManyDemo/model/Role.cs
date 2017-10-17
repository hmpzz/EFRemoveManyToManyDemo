using System.Collections.Generic;

namespace EFRemoveManyToManyDemo.Model
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}