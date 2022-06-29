using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Administrador.Persistence.Entities
{
    public enum EnumIncidentStatus
    {
        PendingProficient,
        PendingWorkshop,
        PendingSupplier,
        PendingFix,
        Fixed,
    }

    public class Incident : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public EnumIncidentStatus Status { get; set; } = EnumIncidentStatus.PendingProficient;
        public string Address { get; set; }
        public int ParishId { get; set; }
        public virtual Parish Parish { get; set; }
        public Guid PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        public Guid? ThirdPolicyId { get; set; }
        public virtual Policy ThirdPolicy { get; set; }
        public virtual ICollection<RepairRequest> RepairRequests { get; set; }
    }
}
