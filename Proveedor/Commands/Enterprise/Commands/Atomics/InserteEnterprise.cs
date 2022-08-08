using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.Persistence.Entities;
using Proveedor.BussinesLogic.Mappers;
using Base.Services.RabbitMQ;

namespace Proveedor.BussinesLogic.Commands.Enterprises.Commands.Atomics
{
    public class InsertEnterprise : Command<EnterpriseDTO>
    {
        private readonly IEnterpriseDAO _enterpriseDAO;

        private readonly AmqpService _amqpService;

        private EnterpriseDTO _enterpriseDTO;

        private EnterpriseDTO _enterprise;

        public InsertEnterprise(
            IEnterpriseDAO enterpriseDAO,
            AmqpService amqpService,
            EnterpriseDTO enterpriseDTO
        )
        {
            _enterpriseDAO = enterpriseDAO;
            _amqpService = amqpService;
            _enterpriseDTO = enterpriseDTO;
        }

        public override async Task Execute()
        {
            var enterpriseInserted = await _enterpriseDAO.CreateEnterprise(_enterpriseDTO);
            _enterprise = EnterpriseMapper.MapEntityToDTO(enterpriseInserted);
        }

        public override async Task<EnterpriseDTO> GetResult()
        {
            return _enterprise;
        }
    }
}
