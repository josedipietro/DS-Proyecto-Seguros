using Taller.BussinesLogic.Commands;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.DAOs;

namespace Taller.BussinesLogic.Commands.Brand.Commands.Atomics
{
    public class GetBrands : Command<List<BrandDTO>>
    {
        private readonly IBrandDAO _brandDAO;
        private List<BrandDTO> _brands;

        public GetBrands(IBrandDAO brandDAO)
        {
            _brandDAO = brandDAO;
        }

        public override async Task Execute()
        {
            _brands = await _brandDAO.List();
        }

        public override async Task<List<BrandDTO>> GetResult()
        {
            return _brands;
        }
    }
}
