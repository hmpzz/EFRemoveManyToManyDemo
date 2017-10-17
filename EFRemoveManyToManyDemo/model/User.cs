using System;
using System.Collections.Generic;

namespace EFRemoveManyToManyDemo.Model
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        
    }
}