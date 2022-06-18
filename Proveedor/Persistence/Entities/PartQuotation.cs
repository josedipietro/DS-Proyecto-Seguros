using System.Collections.Generic;

namespace Proveedor.Persistence.Entities
{
    public enum EnumPartQuotationStatus
    {
        Listed,
        BuyOrder,
        Factured,
    }

    public enum EnumDeliveryTime
    {
        Immediate,
        TwoToThreeDays,
        MoreThanThreeDays,
    }

    public class PartQuotation : BaseEntity
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
        public virtual Part Part { get; set; }
    }
}
