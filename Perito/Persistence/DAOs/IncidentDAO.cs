using Microsoft.EntityFrameworkCore;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public class IncidentDAO
    {
        private readonly IPeritoDbContext _context;

        public IncidentDAO(IPeritoDbContext proveedorDbContext)
        {
            _context = proveedorDbContext;
        }

        public async Task<Incident?> GetIncident(Guid id)
        {
            return await _context.Incidents
                .FindAsync(id);
        }

        public async Task<List<Incident>> GetIncidents()
        {
            return await _context.Incidents.ToListAsync();
        }

        public async Task<Incident> CreateIncident(IncidentDTO incidentDTO)
        {
            var repairRequests = await _context.RepairRequests.Where(r => r.IsActive && incidentDTO.RepairRequests.Contains(r.Id.ToString())).ToListAsync();
            var incident= new Incident
            {
                IsGuilty =incidentDTO.IsGuilty, 
                RepairRequests = repairRequests,
                RevisionDescription = incidentDTO.RevisionDescription,
                Status = incidentDTO.Status,
                User = incidentDTO.User,
                UserId = incidentDTO.UserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            };

            _context.Incidents.Add(incident);
            await _context.DbContext.SaveChangesAsync();

            return incident;
        }

        public async Task<Incident?> UpdateIncident(Guid id, IncidentDTO incidentDTO)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null) return null;

            var repairRequests = await _context.RepairRequests.Where(r => r.IsActive && incidentDTO.RepairRequests.Contains(r.Id.ToString())).ToListAsync();

            incident.IsGuilty = incidentDTO.IsGuilty;
                incident.RepairRequests = repairRequests;
                incident.RevisionDescription = incidentDTO.RevisionDescription;
                incident.Status = incidentDTO.Status;
                incident.User = incidentDTO.User;
                incident.UserId = incidentDTO.UserId;

            _context.Incidents.Update(incident);
            await _context.DbContext.SaveChangesAsync();

            return incident;
        }

        public bool IncidentExists(Guid id)
        {
            return (_context.Incidents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
