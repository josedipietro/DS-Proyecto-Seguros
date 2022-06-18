using System.Collections.Generic;

namespace Proveedor.Persistence.Entities
{
    public class Part
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RepairRequestId { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
        public virtual ICollection<PartQuotation> PartQuotations { get; set; }
    }
}
