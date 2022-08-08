using Proveedor.BussinesLogic.Commands;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.Persistence.Entities;
using Proveedor.BussinesLogic.Mappers;

namespace Proveedor.BussinesLogic.Commands.Enterprises.Commands.Atomics
{
    public class GetEnterprises : Command<List<EnterpriseDTO>>
    {
        private readonly IEnterpriseDAO _enterpriseDAO;

        private readonly int? _parishId;
        private readonly List<string>? _brands;

        private List<EnterpriseDTO> _enterprises;

        public GetEnterprises(
            IEnterpriseDAO enterpriseDAO,
            List<string>? brands
        )
        {
            _enterpriseDAO = enterpriseDAO;

            _brands = brands;
        }

        public override async Task Execute()
        {
            var enterprises = await _enterpriseDAO.GetEnterprises(
                _brands
            );
            var _enterprises = new List<EnterpriseDTO>();
            foreach (var enterprise in enterprises)
            {
                // call EnterpriseMapper.MapEntityToDTO(enterprise)
                _enterprises.Add(EnterpriseMapper.MapEntityToDTO(enterprise));
            }
        }

        public override async Task<List<EnterpriseDTO>> GetResult()
        {
            return _enterprises;
        }
    }
}
