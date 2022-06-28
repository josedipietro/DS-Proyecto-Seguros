using Perito.Persistence.Entities;

namespace Perito.BussinesLogic.DTOs
{
    public class PartDTO
    {
        public string Name { get; set; }
        public EnumPartStatus Status { get; set; } = EnumPartStatus.PendingReview;
        public int Quantity { get; set; }
        public Guid RepairRequestId { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
    }
}
