using System;
using System.Collections.Generic;
using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class EnterpriseDTO
    {
        public string Rif { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public EnumEnterpriseType EnterpriseType { get; set; }

        public int? ParishId { get; set; }

        public ICollection<string> Brands { get; set; }
    }

    public class EnterpriseUpdateDTO
    {
        public string Rif { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int? ParishId { get; set; }

        public ICollection<string> Brands { get; set; }
    }
}
