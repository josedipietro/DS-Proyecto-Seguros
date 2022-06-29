using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Administrador.Persistence.Entities
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

    public class PartQuotation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public bool Original { get; set; }
        [Precision(precision:10, scale:2)]
        public Decimal UnitPrice { get; set; }
        [Precision(precision:5, scale:2)]
        public decimal discount_percentage { get; set; }
        public EnumPartQuotationStatus Status { get; set; } = EnumPartQuotationStatus.Listed;
        public EnumDeliveryTime DeliveryTime { get; set; }
        public Guid PartId { get; set; }
        public virtual Part Part { get; set; }
        public Guid EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
