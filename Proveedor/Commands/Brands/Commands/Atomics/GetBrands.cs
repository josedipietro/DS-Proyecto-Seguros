using Proveedor.BussinesLogic.Commands;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.BussinesLogic.Mappers;

namespace Proveedor.BussinesLogic.Commands.Brands.Commands.Atomics
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
            var brands = await _brandDAO.List();
            var _brands = new List<BrandDTO>();
            foreach (var brand in brands)
            {
                // call BrandMapper.MapEntityToDTO(brand)
                _brands.Add(BrandMapper.MapEntityToDTO(brand));
            }
        }

        public override async Task<List<BrandDTO>> GetResult()
        {
            return _brands;
        }
    }
}
