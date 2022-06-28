using System;
using System.Collections.Generic;
using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.DTOs
{
    public class UserDTO { 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LdapID { get; set; }
        public string Email { get; set; }
        public Guid EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
