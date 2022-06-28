using Microsoft.EntityFrameworkCore;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Database;
using Taller.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public class RepairRequestDAO
    {
        private readonly TallerDbContext _context;

        public RepairRequestDAO(TallerDbContext proveedorDbContext)
        {
            _context = proveedorDbContext;
        }

        public bool RepairRequestExist(Guid id)
        {
            return (_context.RepairRequests?.Any(e => e.Id == id)).GetValueOrDefault();
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
            var partQ = new RepairRequest
            {
                VehicleId = repairRequestDTO.VehicleId,
                PolicyId = repairRequestDTO.PolicyId,
                IncidentId = repairRequestDTO.IncidentId,
                QuotationId = repairRequestDTO.QuotationId,
                Quotation = repairRequestDTO.Quotation,
                Parts = repairRequestDTO.Parts
            };
            _context.RepairRequests.Add(partQ);
            await _context.SaveChangesAsync();

            return partQ;
        }

        public async Task<RepairRequest?> UpdateRepairRequest(Guid id, RepairRequestDTO repairRequestDTO)
        {
            var repairRequest = await _context.RepairRequests.FindAsync(id);
            if (repairRequest == null) return null;

                repairRequest.VehicleId = repairRequestDTO.VehicleId;
                repairRequest.PolicyId = repairRequestDTO.PolicyId;
                repairRequest.IncidentId = repairRequestDTO.IncidentId;
                repairRequest.QuotationId = repairRequestDTO.QuotationId;
                repairRequest.Quotation = repairRequestDTO.Quotation;
                repairRequest.Parts = repairRequestDTO.Parts;

            _context.RepairRequests.Update(repairRequest);
            await _context.SaveChangesAsync();

            return repairRequest;
        }
    }
}
