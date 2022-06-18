using System.Collections.Generic;

namespace Administrador.Persistence.Entities
{
    public class Brand
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Enterprise> Enterprises { get; set; }
    }
}
