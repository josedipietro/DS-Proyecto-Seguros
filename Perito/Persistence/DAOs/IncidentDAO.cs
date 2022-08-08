using Base.Exceptions;
using Microsoft.EntityFrameworkCore;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public class IncidentDAO: IIncidentDAO
    {
        private readonly IPeritoDbContext _context;

        public IncidentDAO(IPeritoDbContext proveedorDbContext)
        {
            _context = proveedorDbContext;
        }

        public async Task<IncidentDTO> Get(string id)
        {   
            var inc = await _context.Incidents.FindAsync(id);
            if (inc == null) throw new RCVException("No se encontro el incidente");

            var repairRequests = new List<String>();
            foreach (var rr in inc.RepairRequests)
            {
                repairRequests.Add(rr.Id.ToString());
            };
            return new IncidentDTO
            {
                IsGuilty = inc.IsGuilty,
                RepairRequests = repairRequests,
                RevisionDescription = inc.RevisionDescription,
                Status = inc.Status,
                UserId = inc.UserId,
                User = inc.User
            };
        }

        public async Task<List<IncidentDTO>> List()
        {
            var incidents = await _context.Incidents.ToListAsync();
            var incidentsDTO = new List<IncidentDTO>();
            foreach (var inc in incidents)
            {
                var repairRequests = new List<String>();
                foreach (var rr in inc.RepairRequests)
                {
                    repairRequests.Add(rr.Id.ToString());
                };
                incidentsDTO.Add(new IncidentDTO
                {
                    IsGuilty = inc.IsGuilty,
                    RepairRequests = repairRequests,
                    RevisionDescription = inc.RevisionDescription,
                    Status = inc.Status,
                    UserId = inc.UserId,
                    User = inc.User

                });
            }
            return incidentsDTO;
        }

        public async Task<IncidentDTO> Create(IncidentDTO incidentDTO)
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
            await _context.SaveChangesAsync();

            return incidentDTO;
        }

        public async Task<IncidentDTO?> Update(Incident incident, IncidentDTO incidentDTO)
        {
            var repairRequests = await _context.RepairRequests.Where(r => r.IsActive && incidentDTO.RepairRequests.Contains(r.Id.ToString())).ToListAsync();

            incident.IsGuilty = incidentDTO.IsGuilty;
                incident.RepairRequests = repairRequests;
                incident.RevisionDescription = incidentDTO.RevisionDescription;
                incident.Status = incidentDTO.Status;
                incident.User = incidentDTO.User;
                incident.UserId = incidentDTO.UserId;

            _context.Incidents.Update(incident);
            await _context.SaveChangesAsync();

            return incidentDTO;
        }

        public bool IncidentExists(string id)
        {
            return (_context.Incidents?.Any(e => e.Id.ToString() == id)).GetValueOrDefault();
        }
    }
}
