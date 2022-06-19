using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
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
        [Precision(precision:10, scale:2)]
        public decimal UnitPrice { get; set; }
        public bool Original { get; set; }
        public EnumPartQuotationStatus Status { get; set; } = EnumPartQuotationStatus.Listed;
        public EnumDeliveryTime DeliveryTime { get; set; }
        [Precision(precision:5, scale:2)]
        public decimal discount_percentage { get; set; }
        public DateTime? DeliveryStartDate { get; set; }
        public DateTime? DeliveryEndDate { get; set; }
        public Guid PartId { get; set; }
        public virtual Part Part { get; set; }
    }
}
