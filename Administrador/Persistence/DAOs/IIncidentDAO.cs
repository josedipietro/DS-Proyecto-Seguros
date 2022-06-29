using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IIncidentDAO
    {
        Task<Incident?> GetIncident(Guid id);
        Task<List<Incident>> GetIncidents(
            int? parishId,
            EnumIncidentStatus? status,
            Guid? policyId,
            Guid? thirdPolicyId
        );
        Task<Incident> CreateIncident(IncidentDTO incidentDTO);
    }
}
