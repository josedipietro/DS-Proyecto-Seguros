using System.Collections.Generic;

namespace Taller.Persistence.Entities
{
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Enterprise> Enterprises { get; set; }
    }
}
