using Administrador.BussinesLogic.Commands;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;

namespace Administrador.BussinesLogic.Commands.Brand.Commands.Atomics
{
    public class GetBrands : Command<List<BrandDTO>>
    {
        private readonly IBrandDAO _brandDAO;
        private List<BrandDTO> _brands;

        public GetBrands(IBrandDAO brandDAO)
        {
            _brandDAO = brandDAO;
        }

        public override async void Execute()
        {
            _brands = await _brandDAO.List();
        }

        public override async Task<List<BrandDTO>> GetResult()
        {
            return _brands;
        }
    }
}
