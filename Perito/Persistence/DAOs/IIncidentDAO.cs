using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public interface IIncidentDAO
    {
        public bool IncidentExists(string id);
        public Task<IncidentDTO> Create(IncidentDTO incident);
        public Task<List<IncidentDTO>> List();
        public Task<IncidentDTO?> Get(string id);
        public Task<IncidentDTO> Update(Incident incident, IncidentDTO incidentDTO);
    }
}
