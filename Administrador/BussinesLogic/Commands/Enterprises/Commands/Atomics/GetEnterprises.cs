using Administrador.BussinesLogic.Commands;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.Mappers;

namespace Administrador.BussinesLogic.Commands.Enterprises.Commands.Atomics
{
    public class GetEnterprises : Command<List<EnterpriseDTO>>
    {
        private readonly IEnterpriseDAO _enterpriseDAO;

        private readonly int? _parishId;
        private readonly List<string>? _brands;
        private readonly EnumEnterpriseType? _EnterpriseType;

        private List<EnterpriseDTO> _enterprises;

        public GetEnterprises(
            IEnterpriseDAO enterpriseDAO,
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        )
        {
            _enterpriseDAO = enterpriseDAO;
            _parishId = parishId;
            _brands = brands;
            _EnterpriseType = EnterpriseType;
        }

        public override async Task Execute()
        {
            var enterprises = await _enterpriseDAO.GetEnterprises(
                _parishId,
                _brands,
                _EnterpriseType
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
