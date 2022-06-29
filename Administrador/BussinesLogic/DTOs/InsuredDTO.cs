using System;
using System.Collections.Generic;
using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class InsuredDTO
    {
        public EnumInsuredTypeIdentification InsuredTypeIdentification { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
