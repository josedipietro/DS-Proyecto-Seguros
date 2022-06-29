using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Perito.Persistence.Entities
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public EnumIncidentStatus Status { get; set; } = EnumIncidentStatus.PendingProficient;
        public bool? IsGuilty { get; set; }
        public string? RevisionDescription { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<RepairRequest> RepairRequests { get; set; }
    }
}
