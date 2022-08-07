using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Perito.Persistence.Entities
{
    public enum EnumRepairStatus
    {
        Peding,
        Listed,
        BuyOrder,
        Repairing,
        Factured,
    }

    public class RepairRequest : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid VehicleId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PolicyId { get; set; }
        public EnumRepairStatus Status { get; set; }    = EnumRepairStatus.Peding;
        public Guid IncidentId { get; set; }
        public virtual Incident Incident { get; set; }
        public DateTime BuyDate { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
