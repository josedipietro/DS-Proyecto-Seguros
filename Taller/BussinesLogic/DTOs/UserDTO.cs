using System;
using System.Collections.Generic;
using Taller.Persistence.Entities;

namespace Taller.BussinesLogic.DTOs
{
    public class UserDTO {

        //public Guid Id { get; set; }
        public string LdapID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
