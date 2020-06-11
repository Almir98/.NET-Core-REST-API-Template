using System;
using System.Collections.Generic;

namespace REST_API.Web_API.Database
{
    public partial class Role
    {
        public Role()
        {
            CustomerRoles = new HashSet<CustomerRoles>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<CustomerRoles> CustomerRoles { get; set; }
    }
}
