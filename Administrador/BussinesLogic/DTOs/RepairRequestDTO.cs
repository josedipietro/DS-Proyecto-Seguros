using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class RepairRequestDTO
    {
        public Guid Id { get; set; }
        public Guid QuotationId { get; set; }
        public EnumRepairStatus Status { get; set; } = EnumRepairStatus.Peding;
        public Guid? VehicleId { get; set; }
        public Guid IncidentId { get; set; }
    }
}
