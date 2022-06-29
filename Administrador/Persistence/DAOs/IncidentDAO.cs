using Microsoft.EntityFrameworkCore;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;
using Base.Exceptions;
using Administrador.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrador.Persistence.DAOs
{
    public class IncidentDAO : IIncidentDAO
    {
        private readonly IAdministradorDbContext _context;

        public IncidentDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<Incident?> GetIncident(Guid id)
        {
            return await _context.Incidents
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Incident>> GetIncidents(
            int? parishId,
            EnumIncidentStatus? status,
            Guid? policyId,
            Guid? thirdPolicyId
        )
        {
            return await _context.Incidents
                .Where(
                    b =>
                        (b.IsActive == true)
                        && (parishId.HasValue ? b.ParishId == parishId.Value : true)
                        && (status.HasValue ? b.Status == status.Value : true)
                        && (policyId.HasValue ? b.PolicyId == policyId.Value : true)
                        && (thirdPolicyId.HasValue ? b.ThirdPolicyId == thirdPolicyId.Value : true)
                )
                .ToListAsync();
        }

        public async Task<Incident> CreateIncident(IncidentDTO incidentDTO)
        {
            // Validate if the policy exists
            var policy = await _context.Policies
                .Where(b => (b.IsActive == true) && (b.Id == incidentDTO.PolicyId))
                .FirstOrDefaultAsync();
            if (policy == null)
            {
                throw new Exception("The policy does not exist");
            }

            // Validate if the third policy exists
            var thirdPolicy = await _context.Policies
                .Where(b => (b.IsActive == true) && (b.Id == incidentDTO.ThirdPolicyId))
                .FirstOrDefaultAsync();
            if (thirdPolicy == null)
            {
                throw new Exception("The third policy does not exist");
            }

            var incident = new Incident
            {
                Id = Guid.NewGuid(),
                Date = incidentDTO.Date,
                Description = incidentDTO.Description,
                Status = EnumIncidentStatus.PendingProficient,
                Address = incidentDTO.Address,
                ParishId = incidentDTO.ParishId,
                PolicyId = incidentDTO.PolicyId,
                ThirdPolicyId = incidentDTO.ThirdPolicyId,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();
            return incident;
        }

        public async Task<Incident> UpdateStatus(Incident incident, EnumIncidentStatus status)
        {
            incident.Status = status;
            _context.Incidents.Update(incident);
            await _context.SaveChangesAsync();
            return incident;
        }
    }
}
