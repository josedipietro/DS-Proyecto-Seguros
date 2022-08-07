using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.DTOs
{
    public class ParticipationDTO
    {
        public Guid RepairRequestId { get; set; }
        public RepairRequest RepairRequest { get; set; }

        public Guid EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }

        public EnumParticipationStatus Status { get; set; }
    }
}
