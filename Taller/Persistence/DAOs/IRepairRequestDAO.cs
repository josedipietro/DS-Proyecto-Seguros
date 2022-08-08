using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Entities;

namespace Taller.Persistence.DAOs
{
    public interface IRepairRequestDAO
    {
        public bool RepairRequestExist(Guid id);
        public Task<RepairRequest?> GetRepairRequest(Guid id);
        public Task<List<RepairRequest>> GetRepairRequests();
        public Task<RepairRequest> CreateRepairRequest(RepairRequestDTO repairRequestDTO);
        public Task<RepairRequest?> UpdateRepairRequest(Guid id, RepairRequestDTO repairRequestDTO);
    }
}
