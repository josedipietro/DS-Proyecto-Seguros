using Proveedor.BussinesLogic.Commands;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.BussinesLogic.Mappers;
using Proveedor.Persistence.Entities;
using Base.Services.RabbitMQ;

namespace Proveedor.BussinesLogic.Commands.Enterprises.Commands.Compose
{
    public class GetAndUpdateEnterprise : Command<EnterpriseDTO>
    {
        private readonly IEnterpriseDAO _enterpriseDAO;

        private readonly AmqpService _amqpService;

        private Guid _id;
        private EnterpriseUpdateDTO _updateEnterpriseDTO;
        private EnterpriseDTO _enterprise;

        public GetAndUpdateEnterprise(
            IEnterpriseDAO enterpriseDAO,
            Guid id,
            EnterpriseUpdateDTO updateEnterpriseDTO,
            AmqpService amqpService
        )
        {
            _enterpriseDAO = enterpriseDAO;
            _id = id;
            _updateEnterpriseDTO = updateEnterpriseDTO;
            _amqpService = amqpService;
        }

        public override async Task Execute()
        {
            var enterprise = await _enterpriseDAO.GetEnterprise(_id);
            if (enterprise != null)
            {
                var enterpriseUpdated = await _enterpriseDAO.UpdateEnterprise(
                    enterprise,
                    _updateEnterpriseDTO
                );
                _enterprise = EnterpriseMapper.MapEntityToDTO(enterpriseUpdated);
            }
        }

        public override async Task<EnterpriseDTO> GetResult()
        {
            return _enterprise;
        }
    }
}
