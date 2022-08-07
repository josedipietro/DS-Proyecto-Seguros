using MassTransit;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using System.Threading.Tasks;

namespace Administrador.Consumers
{
    public class PartQuotationConsumer : IConsumer<PartQuotationDTO>
    {
        private readonly IPartQuotationDAO _partQuotationDAO;

        public PartQuotationConsumer(IPartQuotationDAO partQuotationDAO)
        {
            _partQuotationDAO = partQuotationDAO;
        }

        public async Task Consume(ConsumeContext<PartQuotationDTO> context)
        {
            var partQuotationDTO = context.Message;
            //  create part quotation
            try
            {
                await _partQuotationDAO.CreatePartQuotation(partQuotationDTO);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
