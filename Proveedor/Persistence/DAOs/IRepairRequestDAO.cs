using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public interface IRepairRequestDAO
    {
        Task<RepairRequest?> GetRepairRequest(Guid id);
        Task<List<RepairRequest>> GetRepairRequests();
        Task<RepairRequest> CreateRepairRequest(RepairRequestDTO repairRequestDTO);

        Task<RepairRequest?> UpdateRepairRequests(Guid id, RepairRequestDTO repairRequestDTO);
    }
}