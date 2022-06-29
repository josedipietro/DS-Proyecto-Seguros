using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;
using Administrador.BussinesLogic.DTOs;

namespace Administrador.Persistence.DAOs
{
    public class PartDAO : IPartDAO
    {
        private readonly IAdministradorDbContext _context;

        public PartDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<Part?> GetPart(Guid id)
        {
            return await _context.Parts.FindAsync(id);
        }

        public async Task<List<Part>> GetParts(Guid? repairRequestId)
        {
            return await _context.Parts
                .Where(
                    e => (repairRequestId.HasValue ? e.RepairRequestId == repairRequestId : true)
                )
                .ToListAsync();
        }

        public async Task<Part> UpdateStatus(Part part, EnumPartStatus status)
        {
            part.Status = status;
            _context.Parts.Update(part);
            await _context.SaveChangesAsync();
            return part;
        }

        public async Task<Part> CreatePart(PartDTO partDTO)
        {
            var part = new Part
            {
                Id = partDTO.Id,
                Name = partDTO.Name,
                Quantity = partDTO.Quantity,
                RepairRequestId = partDTO.RepairRequestId,
                Status = partDTO.Status
            };

            _context.Parts.Add(part);
            await _context.SaveChangesAsync();

            return part;
        }
    }
}
