using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.DTOs
{
    public class PartQuotationDTO
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Original { get; set; }
        public EnumPartQuotationStatus Status { get; set; } = EnumPartQuotationStatus.Listed;
        public EnumDeliveryTime DeliveryTime { get; set; }
        public decimal discount_percentage { get; set; }
        public DateTime? DeliveryStartDate { get; set; }
        public DateTime? DeliveryEndDate { get; set; }
        public Guid PartId { get; set; }
        public Part Part { get; set; }
    }
}
