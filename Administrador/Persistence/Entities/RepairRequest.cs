using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Administrador.Persistence.Entities
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
        public Guid QuotationId { get; set; }
        public EnumRepairStatus Status { get; set; } = EnumRepairStatus.Peding;
        public Guid? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public Guid IncidentId { get; set; }
        public virtual Incident Incident { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
