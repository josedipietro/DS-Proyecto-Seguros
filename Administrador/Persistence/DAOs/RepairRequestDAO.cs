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
    }
}
