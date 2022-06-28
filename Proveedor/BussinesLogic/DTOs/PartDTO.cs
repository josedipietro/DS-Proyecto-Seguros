using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.DTOs
{
    public class PartDTO
    {
        public string Name { get; set; }
        public Guid RepairRequestId { get; set; }
        public RepairRequest RepairRequest { get; set; }
        public ICollection<PartQuotation> PartQuotations { get; set; }
    }
}
