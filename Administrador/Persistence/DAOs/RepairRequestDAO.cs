using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;
using Administrador.BussinesLogic.DTOs;

namespace Administrador.Persistence.DAOs
{
    public class RepairRequestDAO : IRepairRequestDAO
    {
        private readonly IAdministradorDbContext _context;

        public RepairRequestDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<RepairRequest?> GetRepairRequest(Guid id)
        {
            return await _context.RepairRequests.FindAsync(id);
        }

        public async Task<List<RepairRequest>> GetRepairRequests(Guid? IncidentId)
        {
            return await _context.RepairRequests
                .Where(x => IncidentId.HasValue ? x.IncidentId == IncidentId : true)
                .ToListAsync();
        }

        public async Task<RepairRequest> CreateRepairRequest(RepairRequestDTO repairRequestDTO)
        {
            var repairRequest = new RepairRequest
            {
                Id = repairRequestDTO.Id,
                IncidentId = repairRequestDTO.IncidentId,
                QuotationId = repairRequestDTO.QuotationId,
                Status = repairRequestDTO.Status,
                VehicleId = repairRequestDTO.VehicleId
            };

            _context.RepairRequests.Add(repairRequest);
            await _context.SaveChangesAsync();

            return repairRequest;
        }
    }
}
