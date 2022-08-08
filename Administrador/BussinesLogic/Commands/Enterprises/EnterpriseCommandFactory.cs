using Administrador.BussinesLogic.Commands.Enterprises.Commands.Atomics;
using Administrador.BussinesLogic.Commands.Enterprises.Commands.Compose;
using Administrador.Persistence.DAOs;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;
using Base.Services.RabbitMQ;

namespace Administrador.BussinesLogic.Commands.Enterprises
{
    public class EnterpriseCommandFactory : IEnterpriseCommandFactory
    {
        private readonly IEnterpriseDAO _enterpriseDAO;
        private readonly AmqpService _amqpService;

        public EnterpriseCommandFactory(IEnterpriseDAO enterpriseDAO, AmqpService amqpService)
        {
            _enterpriseDAO = enterpriseDAO;
            _amqpService = amqpService ?? throw new ArgumentNullException(nameof(amqpService));
        }

        public Task<GetEnterprises> GetEnterprises(
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        )
        {
            return Task<GetEnterprises>.Run(
                () => new GetEnterprises(_enterpriseDAO, parishId, brands, EnterpriseType)
            );
        }

        public Task<GetEnterprise> GetEnterprise(Guid id)
        {
            return Task<GetEnterprise>.Run(() => new GetEnterprise(_enterpriseDAO, id));
        }

        public Task<InsertEnterprise> InsertEnterprise(EnterpriseDTO enterpriseDTO)
        {
            return Task<InsertEnterprise>.Run(
                () => new InsertEnterprise(_enterpriseDAO, _amqpService, enterpriseDTO)
            );
        }

        public Task<UpdateEnterprise> UpdateEnterprise(
            Enterprise enterprise,
            EnterpriseUpdateDTO updateEnterpriseDTO
        )
        {
            return Task<UpdateEnterprise>.Run(
                () => new UpdateEnterprise(_enterpriseDAO, enterprise, updateEnterpriseDTO)
            );
        }

        public Task<GetAndUpdateEnterprise> GetAndUpdateEnterprise(
            Guid id,
            EnterpriseUpdateDTO updateEnterpriseDTO
        )
        {
            return Task<GetAndUpdateEnterprise>.Run(
                () =>
                    new GetAndUpdateEnterprise(
                        _enterpriseDAO,
                        id,
                        updateEnterpriseDTO,
                        _amqpService
                    )
            );
        }
    }
}
