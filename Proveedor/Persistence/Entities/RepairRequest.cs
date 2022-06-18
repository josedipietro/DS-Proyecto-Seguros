using System.Collections.Generic;

namespace Proveedor.Persistence.Entities
{
    public class RepairRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
