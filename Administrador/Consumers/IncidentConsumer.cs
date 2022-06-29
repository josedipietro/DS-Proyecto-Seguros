using MassTransit;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using Administrador.Persistence.Database;
using System.Threading.Tasks;

namespace Administrador.Consumers
{
    public class IncidentConsumer : IConsumer<IncidentConsumerDTO>
    {

        public async Task Consume(ConsumeContext<IncidentConsumerDTO> context)
        {
            

            var incidentDTO = context.Message;
            // get incident
            // var incident = await _incidentDAO.GetIncident(incidentDTO.Id);
            // if (incident != null)
            // {
            //     await _incidentDAO.UpdateStatus(incident, incidentDTO.Status);
            // }
        }
    }
}
