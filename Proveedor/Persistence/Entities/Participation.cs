using System.Collections.Generic;

namespace Proveedor.Persistence.Entities
{
    public enum EnumParticipationStatus
    {
        Pending,
        Accepted,
        Rejected,
        Listed,
        BuyOrder,
        Invoiced,
    }

    public class Participation : BaseEntity
    {
        public Guid RepairRequestId { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }

        public Guid EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }

        public EnumParticipationStatus Status { get; set; } = EnumParticipationStatus.Pending;
    }
}
