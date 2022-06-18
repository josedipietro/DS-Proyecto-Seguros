using System.Collections.Generic;

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
        public Decimal UnitPrice { get; set; }
        public EnumPartQuotationStatus Status { get; set; }
        public EnumDeliveryTime DeliveryTime { get; set; }
        public Guid PartId { get; set; }
        public virtual Part Part { get; set; }
        public Guid EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
