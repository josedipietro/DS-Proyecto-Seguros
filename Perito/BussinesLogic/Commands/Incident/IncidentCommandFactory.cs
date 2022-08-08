using Perito.BussinesLogic.Commands.Incident.Commands.Atomics;
using Perito.Persistence.DAOs;

namespace Perito.BussinesLogic.Commands.Incident
{
    public class IncidentCommandFactory : IIncidentCommandFactory
    {
        private readonly IIncidentDAO _incidentDAO;

        public IncidentCommandFactory(IIncidentDAO incidentDAO)
        {
            _incidentDAO = incidentDAO;
        }

        public Task<GetIncidents> GetIncidents()
        {
            return Task<GetIncidents>.Run(() => new GetIncidents(_incidentDAO));
        }
        public Task<GetIncident> GetIncident(string id)
        {
            return Task<GetIncident>.Run(() => new GetIncident(_incidentDAO, id));
        }
    }
}
