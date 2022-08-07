using Microsoft.EntityFrameworkCore;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Database;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public class PartDAO
    {

        private readonly ProveedorDbContext _context;

        public PartDAO(ProveedorDbContext context)
        {
            _context = context;
        }

        public async Task<Part?> GetPart(Guid id)
        {
            return await _context.Parts
                .FindAsync(id);
        }

        public async Task<List<Part>> GetParts()
        {
            return await _context.Parts.ToListAsync();
        }

        public async Task<Part> CreatePart(PartDTO partDTO)
        {
            var part = new Part
            {
                Name = partDTO.Name,
                RepairRequest = partDTO.RepairRequest,
                PartQuotations = partDTO.PartQuotations,
                RepairRequestId = partDTO.RepairRequestId,
            };
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();

            return part;
        }

        public bool PartExists(Guid id)
        {
            return (_context.Parts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
