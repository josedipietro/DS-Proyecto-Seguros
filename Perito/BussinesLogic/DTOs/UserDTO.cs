using System;
using System.Collections.Generic;
using Perito.Persistence.Entities;

namespace Perito.BussinesLogic.DTOs
{
    public class UserDTO { 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LdapID { get; set; }
        public string Email { get; set; }
        public List<string> Incidents { get; set; }
    }
}
