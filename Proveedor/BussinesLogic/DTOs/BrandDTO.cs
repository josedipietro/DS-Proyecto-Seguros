using System;
using System.Collections.Generic;

namespace Proveedor.BussinesLogic.DTOs
{
    public class BrandDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateBrandDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
