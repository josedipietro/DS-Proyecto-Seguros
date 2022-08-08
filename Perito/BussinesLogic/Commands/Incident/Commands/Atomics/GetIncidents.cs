using Base.Exceptions;
using Perito.BussinesLogic.Commands;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.DAOs;

namespace Perito.BussinesLogic.Commands.Incident.Commands.Atomics
{
    public class GetIncidents: Command<List<IncidentDTO>>
    {
        private readonly IIncidentDAO _incidentDAO;
        private List<IncidentDTO>? _incidents;

        public GetIncidents(IIncidentDAO incidentDAO)
        {
            _incidentDAO = incidentDAO;
        }

        public override async Task Execute()
        {
            _incidents = await _incidentDAO.List();
        }

        public override async Task<List<IncidentDTO>> GetResult()
        {

            return _incidents ?? throw new RCVException("Debe ejecutar el comando primero");
        }
    }
}
