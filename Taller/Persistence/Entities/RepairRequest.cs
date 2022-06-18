using System.Collections.Generic;

namespace Taller.Persistence.Entities
{
    public enum EnumRepairStatus
    {
        Peding,
        Listed,
        BuyOrder,
        Repairing,
        Factured,
    }

    public class RepairRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public EnumRepairStatus Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid VehicleId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PolicyId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IncidentId { get; set; }

        public Guid? QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
