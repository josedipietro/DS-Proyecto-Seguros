using Base.Exceptions;
using Perito.BussinesLogic.Commands;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.DAOs;

namespace Perito.BussinesLogic.Commands.Incident.Commands.Atomics
{
    public class GetIncident : Command<IncidentDTO>
    {
        private readonly IIncidentDAO _incidentDAO;
        private IncidentDTO? _incident;
        private string _id;

        public GetIncident(IIncidentDAO incidentDAO, string id)
        {
            _incidentDAO = incidentDAO;
            _id = id;
        }

        public override async Task Execute()
        {
            _incident = await _incidentDAO.Get(_id);
        }

        public override async Task<IncidentDTO> GetResult()
        {

            return _incident ?? throw new RCVException("Debe ejecutar el comando primero");
        }
    }
}
