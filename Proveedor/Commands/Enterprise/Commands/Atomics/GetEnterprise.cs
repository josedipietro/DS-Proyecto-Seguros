using Proveedor.BussinesLogic.Commands;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.BussinesLogic.Mappers;

namespace Proveedor.BussinesLogic.Commands.Enterprises.Commands.Atomics
{
    public class GetEnterprise : Command<EnterpriseDTO>
    {
        private readonly IEnterpriseDAO _enterpriseDAO;

        private readonly Guid _id;
        private EnterpriseDTO _enterprise;

        public GetEnterprise(IEnterpriseDAO enterpriseDAO, Guid id)
        {
            _enterpriseDAO = enterpriseDAO;
            _id = id;
        }

        public override async Task Execute()
        {
            var enterprise = await _enterpriseDAO.GetEnterprise(_id);
            if (enterprise != null)
            {
                _enterprise = EnterpriseMapper.MapEntityToDTO(enterprise);
            }
        }

        public override async Task<EnterpriseDTO?> GetResult()
        {
            return _enterprise;
        }
    }
}