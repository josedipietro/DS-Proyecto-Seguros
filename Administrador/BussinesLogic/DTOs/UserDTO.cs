using System;
using System.Collections.Generic;
using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class UserDTO { 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
        public EnumIdentificationType IdentificationType { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }
        public Guid? EnterpriseId { get; set; }
    }
}
