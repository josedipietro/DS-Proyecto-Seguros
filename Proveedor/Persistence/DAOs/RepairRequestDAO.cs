using Microsoft.EntityFrameworkCore;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Database;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public class RepairRequestDAO
    {
        private readonly ProveedorDbContext _context;

        public RepairRequestDAO(ProveedorDbContext proveedorDbContext)
        {
            _context = proveedorDbContext;
        }

        public bool RepairRequestExist(Guid id)
        {
            return (_context.RepairRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<RepairRequest?> GetPartQuotation(Guid id)
        {
            return await _context.RepairRequests
                .FindAsync(id);
        }

        public async Task<List<RepairRequest>> GetPartQuotations()
        {
            return await _context.RepairRequests.ToListAsync();
        }

        public async Task<RepairRequest> CreateParticipation(RepairRequestDTO repairRequestDTO)
        {
            var partQ = new RepairRequest
            {
                Parts = repairRequestDTO.Parts
            };
            _context.RepairRequests.Add(partQ);
            await _context.SaveChangesAsync();

            return partQ;
        }

        public async Task<RepairRequest?> UpdatePartQuotation(Guid id, RepairRequestDTO repairRequestDTO)
        {
            var repairRequest = await _context.RepairRequests.FindAsync(id);
            if (repairRequest == null) return null;

            repairRequest.Parts = repairRequestDTO.Parts;

            _context.RepairRequests.Update(repairRequest);
            await _context.SaveChangesAsync();

            return repairRequest;
        }
    }
}
