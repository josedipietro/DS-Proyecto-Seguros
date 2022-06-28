using Microsoft.EntityFrameworkCore;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public class PartDAO
    {

        private readonly PeritoDbContext _context;

        public PartDAO(PeritoDbContext context)
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
                RepairRequestId = partDTO.RepairRequestId,
                Quantity = partDTO.Quantity,
                Status = partDTO.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
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
