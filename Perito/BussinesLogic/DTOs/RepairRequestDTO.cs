using Perito.Persistence.Entities;

namespace Perito.BussinesLogic.DTOs
{
    public class RepairRequestDTO
    {
        public Guid VehicleId { get; set; }
        public Guid PolicyId { get; set; }
        public EnumRepairStatus Status { get; set; } = EnumRepairStatus.Peding;
        public Guid IncidentId { get; set; }
        public Incident Incident { get; set; }
        public ICollection<string> Parts { get; set; }
    }
}
