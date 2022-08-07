using Perito.Persistence.Entities;

namespace Perito.BussinesLogic.DTOs
{
    public class IncidentDTO
    {
        public EnumIncidentStatus Status { get; set; } = EnumIncidentStatus.PendingProficient;
        public bool? IsGuilty { get; set; }
        public string? RevisionDescription { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<string> RepairRequests { get; set; }
    }
}
