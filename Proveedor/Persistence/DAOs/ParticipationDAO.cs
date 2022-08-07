using Proveedor.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Entities;
using Proveedor.BussinesLogic.DTOs;

namespace Proveedor.Persistence.DAOs
{
    public class ParticipationDAO
    {
        private readonly ProveedorDbContext _context;

        public ParticipationDAO(ProveedorDbContext context)
        {
            _context = context;
        }

        public bool ParticipationExists(Guid id)
        {
            return (_context.Participations?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<Participation?> GetParticipation(Guid id)
        {
            return await _context.Participations
                .FindAsync(id);
        }

        public async Task<List<Participation>> GetParticipations()
        {
            return await _context.Participations.ToListAsync();
        }

        public async Task<Participation> CreateParticipation(ParticipationDTO participationDTO)
        {
            var part = new Participation
            {
                Enterprise = participationDTO.Enterprise,
                EnterpriseId = participationDTO.EnterpriseId,
                RepairRequest  = participationDTO.RepairRequest,
                RepairRequestId = participationDTO.RepairRequestId,
                Status = EnumParticipationStatus.Pending,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            _context.Participations.Add(part);
            await _context.SaveChangesAsync();

            return part;
        }

        public async Task<Participation?> UpdateParticipation(Guid id, ParticipationDTO participationDTO)
        {
            var participation = await _context.Participations.FindAsync(id);
            if (participation == null) return null;

            participation.Enterprise = participationDTO.Enterprise;
            participation.EnterpriseId = participationDTO.EnterpriseId;
            participation.RepairRequest = participationDTO.RepairRequest;
            participation.RepairRequestId = participationDTO.RepairRequestId;
            participation.Status = EnumParticipationStatus.Pending;

            _context.Participations.Update(participation);
            await _context.SaveChangesAsync();

            return participation;
        }


    }
}
