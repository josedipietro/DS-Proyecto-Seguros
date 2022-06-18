using System.Collections.Generic;

namespace Administrador.Persistence.Entities
{
    public enum EnumPartStatus
    {
        Repair,
        PendingBuy,
        PendingSend,
        PerfectState,
        Received,
    }

    public class Part
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumPartStatus Status { get; set; }
        public int Quantity { get; set; }
        public Guid RepairRequestId { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
        public virtual ICollection<PartQuotation> PartQuotations { get; set; }
    }
}
