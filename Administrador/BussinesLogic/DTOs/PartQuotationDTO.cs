using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class PartQuotationDTO
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public bool Original { get; set; }

        public Decimal UnitPrice { get; set; }

        public decimal discount_percentage { get; set; }
        public EnumPartQuotationStatus Status { get; set; } = EnumPartQuotationStatus.Listed;
        public EnumDeliveryTime DeliveryTime { get; set; }
        public Guid PartId { get; set; }
        public Guid EnterpriseId { get; set; }
    }
}
