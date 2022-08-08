using MassTransit;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using System.Threading.Tasks;
using Administrador;

namespace Administrador.Consumers
{
    public class PartConsumer : IConsumer<PartDTO>
    {
        private readonly IPartDAO _partQuotationDAO;

        public PartConsumer(IPartDAO partQuotationDAO)
        {
            _partQuotationDAO = partQuotationDAO;
        }

        public async Task Consume(ConsumeContext<PartDTO> context)
        {
            var partQuotationDTO = context.Message;
            // create part quotation
            try
            {
                await _partQuotationDAO.CreatePart(partQuotationDTO);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
