using Microsoft.EntityFrameworkCore;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Database;
using Taller.Persistence.Entities;

namespace Taller.Persistence.DAOs
{
    public class PartDAO: IPartDAO
    {

        private readonly TallerDbContext _context;

        public PartDAO(TallerDbContext context)
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
                Quantity = partDTO.Quantity,
                Status = partDTO.Status,
                RepairRequest = partDTO.RepairRequest,
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
