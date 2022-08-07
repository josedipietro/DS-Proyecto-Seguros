using MassTransit;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using System.Threading.Tasks;

namespace Administrador.Consumers
{
    public class RepairRequestConsumer : IConsumer<RepairRequestDTO>
    {
        private readonly IRepairRequestDAO _repairRequestDAO;

        public RepairRequestConsumer(IRepairRequestDAO repairRequestDAO)
        {
            _repairRequestDAO = repairRequestDAO;
        }

        public async Task Consume(ConsumeContext<RepairRequestDTO> context)
        {
            var repairRequestDTO = context.Message;
            // create repair request
            try
            {
                await _repairRequestDAO.CreateRepairRequest(repairRequestDTO);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
