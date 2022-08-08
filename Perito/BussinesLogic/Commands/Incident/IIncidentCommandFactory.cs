using Perito.BussinesLogic.Commands.Incident.Commands.Atomics;

namespace Perito.BussinesLogic.Commands.Incident
{
    public interface IIncidentCommandFactory
    {
        Task<GetIncidents> GetIncidents();
        Task<GetIncident> GetIncident(string id);
    }
}
