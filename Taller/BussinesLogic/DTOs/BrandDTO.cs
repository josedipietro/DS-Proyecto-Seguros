using System;
using System.Collections.Generic;
using Taller.Persistence.Entities;

namespace Taller.BussinesLogic.DTOs
{
    public class BrandDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Enterprise> Enterprises { get; set; }
    }

    public class UpdateBrandDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
