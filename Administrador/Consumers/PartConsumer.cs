using MassTransit;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using System.Threading.Tasks;

namespace Administrador.Consumers
{
    public class PartConsumer : IConsumer<PartDTO>
    {
        private readonly IPartDAO _partDAO;

        public PartConsumer(IPartDAO partDAO)
        {
            _partDAO = partDAO;
        }

        public async Task Consume(ConsumeContext<PartDTO> context)
        {
            var partDTO = context.Message;
            // create part quotation
            try
            {
                await _partDAO.CreatePart(partDTO);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
