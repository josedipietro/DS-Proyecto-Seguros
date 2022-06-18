namespace Perito.Persistence.Entities
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

    public class Part : BaseEntity
    {
        public string Name { get; set; }
        public EnumPartStatus Status { get; set; }
        public int Quantity { get; set; }
        public Guid RepairRequestId { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
    }
}
