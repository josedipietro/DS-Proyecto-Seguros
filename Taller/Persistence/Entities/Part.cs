using System.Collections.Generic;

namespace Taller.Persistence.Entities
{
    public enum EnumPartStatus
    {
        PendingReview,
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
    }
}
