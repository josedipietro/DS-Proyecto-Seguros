using Microsoft.EntityFrameworkCore;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public class RepairRequestDAO : IRepairRequestDAO
    {
        private readonly IPeritoDbContext _context;
        public RepairRequestDAO(IPeritoDbContext context)
        {
            _context = context;
        }
        public async Task<RepairRequest?> GetRepairRequest(Guid id)
        {
            return await _context.RepairRequests
                .FindAsync(id);
        }

        public async Task<List<RepairRequest>> GetRepairRequests()
        {
            return await _context.RepairRequests.ToListAsync();
        }

        public async Task<RepairRequest> CreateRepairRequest(RepairRequestDTO repairRequestDTO)
        {
            var parts = await _context.Parts.Where(p => p.IsActive && repairRequestDTO.Parts.Contains(p.Id.ToString())).ToListAsync();
            var repairRequest = new RepairRequest
            {
                BuyDate = repairRequestDTO.BuyDate,
                Incident = repairRequestDTO.Incident,
                Status = repairRequestDTO.Status,
                IncidentId = repairRequestDTO.IncidentId,
                Parts = parts,
                PolicyId = repairRequestDTO.PolicyId,
                VehicleId = repairRequestDTO.VehicleId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            };
            _context.RepairRequests.Add(repairRequest);
            await _context.DbContext.SaveChangesAsync();

            return repairRequest;
        }

        public async Task<RepairRequest?> UpdateRepairRequest(Guid id, RepairRequestDTO repairRequestDTO)
        {
            var repairRequest = await _context.RepairRequests.FindAsync(id);
            if (repairRequest == null) return null;

            var parts = await _context.Parts.Where(p => p.IsActive && repairRequestDTO.Parts.Contains(p.Id.ToString())).ToListAsync();

            repairRequest.Incident = repairRequestDTO.Incident;
            repairRequest.Status = repairRequestDTO.Status;
            repairRequest.IncidentId = repairRequestDTO.IncidentId;
            repairRequest.Parts = parts;
            repairRequest.PolicyId = repairRequestDTO.PolicyId;
            repairRequest.VehicleId = repairRequestDTO.VehicleId;

            _context.RepairRequests.Update(repairRequest);
            await _context.DbContext.SaveChangesAsync();

            return repairRequest;
        }

        public bool RepairRequestExists(Guid id)
        {
            return (_context.RepairRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
