using Microsoft.EntityFrameworkCore;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public interface IRepairRequestDAO
    {
        Task<RepairRequest?> GetRepairRequest(Guid id);

        Task<List<RepairRequest>> GetRepairRequests();

        Task<RepairRequest> CreateRepairRequest(RepairRequestDTO repairRequestDTO);

        Task<RepairRequest?> UpdateRepairRequest(Guid id, RepairRequestDTO repairRequestDTO);
        bool RepairRequestExists(Guid id);
    }
}
