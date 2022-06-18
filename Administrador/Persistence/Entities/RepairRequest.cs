using System.Collections.Generic;

namespace Administrador.Persistence.Entities
{
    public enum EnumRepairStatus
    {
        Peding,
        Listed,
        BuyOrder,
        Factured,
    }

    public class RepairRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public Guid QuotationId { get; set; }
        public EnumRepairStatus Status { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public Guid IncidentId { get; set; }
        public virtual Incident Incident { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
