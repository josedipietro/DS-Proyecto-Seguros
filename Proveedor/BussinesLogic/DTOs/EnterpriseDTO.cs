using System;
using System.Collections.Generic;
using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.DTOs
{
    public class EnterpriseDTO
    {
        public ICollection<string> Brands { get; set; }
        public ICollection<string> Users { get; set; }
        public ICollection<string> Participations { get; set; }
    }

    public class EnterpriseUpdateDTO
    {
        public ICollection<string> Brands { get; set; }
        public ICollection<string> Users { get; set; }
        public ICollection<string> Participations { get; set; }
    }
}
