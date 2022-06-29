using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IRepairRequestDAO
    {
        Task<RepairRequest?> GetRepairRequest(Guid id);
        Task<List<RepairRequest>> GetRepairRequests(Guid? IncidentId);
        Task<RepairRequest> CreateRepairRequest(RepairRequestDTO repairRequestDTO);
    }
}
