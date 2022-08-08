using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.Persistence.Entities;
using Proveedor.BussinesLogic.Mappers;

namespace Proveedor.BussinesLogic.Commands.Enterprises.Commands.Atomics
{
    public class UpdateEnterprise : Command<EnterpriseDTO>
    {
        private readonly IEnterpriseDAO _enterpriseDAO;
        private Enterprise _enterprise;

        private EnterpriseUpdateDTO _updateEnterpriseDTO;

        private EnterpriseDTO _result;

        public UpdateEnterprise(
            IEnterpriseDAO enterpriseDAO,
            Enterprise enterprise,
            EnterpriseUpdateDTO updateEnterpriseDTO
        )
        {
            _enterpriseDAO = enterpriseDAO;
            _enterprise = enterprise;
            _updateEnterpriseDTO = updateEnterpriseDTO;
        }

        public override async Task Execute()
        {
            var enterpriseUpdated = await _enterpriseDAO.UpdateEnterprise(
                _enterprise,
                _updateEnterpriseDTO
            );
            _result = EnterpriseMapper.MapEntityToDTO(enterpriseUpdated);
        }

        public override async Task<EnterpriseDTO> GetResult()
        {
            return _result;
        }
    }
}
