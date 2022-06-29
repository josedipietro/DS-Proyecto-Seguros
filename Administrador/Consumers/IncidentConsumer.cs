using MassTransit;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using System.Threading.Tasks;

namespace Administrador.Consumers
{
    public class IncidentConsumer : IConsumer<IncidentConsumerDTO>
    {
        private readonly IIncidentDAO _incidentDAO;

        public IncidentConsumer(IIncidentDAO incidentDAO)
        {
            _incidentDAO = incidentDAO;
        }

        public async Task Consume(ConsumeContext<IncidentConsumerDTO> context)
        {
            var incidentDTO = context.Message;
            // get incident
            var incident = await _incidentDAO.GetIncident(incidentDTO.Id);
            if (incident != null)
            {
                await _incidentDAO.UpdateStatus(incident, incidentDTO.Status);
            }
        }
    }
}
