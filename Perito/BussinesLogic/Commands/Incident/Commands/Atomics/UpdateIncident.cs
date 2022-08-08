using Base.Exceptions;
using Perito.BussinesLogic.Commands;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.DAOs;

namespace Perito.BussinesLogic.Commands.Incident.Commands.Atomics
{
    public class UpdateIncident: Command<IncidentDTO>
    {
        private readonly IIncidentDAO _incidentDAO;
        private IncidentDTO? _incidentUpdate;
        private Persistence.Entities.Incident _incident;
        private IncidentDTO _incidentDTO;

        public UpdateIncident(IIncidentDAO incidentDAO, IncidentDTO incidentDTO, Persistence.Entities.Incident incident)
        {
            _incidentDAO = incidentDAO;
            _incident = incident;
            _incidentDTO = incidentDTO;
        }

        public override async Task Execute()
        {
            _incidentUpdate = await _incidentDAO.Update(_incident, _incidentDTO);
        }

        public override async Task<IncidentDTO> GetResult()
        {

            return _incidentUpdate ?? throw new RCVException("Debe ejecutar el comando primero");
        }
    }
}
