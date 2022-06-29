using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class PartDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumPartStatus Status { get; set; } = EnumPartStatus.PendingReview;
        public int Quantity { get; set; }
        public Guid RepairRequestId { get; set; }
    }
}
