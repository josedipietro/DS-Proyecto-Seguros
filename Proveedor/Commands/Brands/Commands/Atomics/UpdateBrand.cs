using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.Persistence.Entities;
using Proveedor.BussinesLogic.Mappers;

namespace Proveedor.BussinesLogic.Commands.Brands.Commands.Atomics
{
    public class UpdateBrand : Command<BrandDTO>
    {
        private readonly IBrandDAO _brandDAO;
        private Brand _brand;

        private UpdateBrandDTO _updateBrandDTO;

        private BrandDTO _result;

        public UpdateBrand(IBrandDAO brandDAO, Brand brand, UpdateBrandDTO updateBrandDTO)
        {
            _brandDAO = brandDAO;
            _brand = brand;
            _updateBrandDTO = updateBrandDTO;
        }

        public override async Task Execute()
        {
            var brandUpdated = await _brandDAO.Update(_brand, _updateBrandDTO);
            _result = BrandMapper.MapEntityToDTO(brandUpdated);
        }

        public override async Task<BrandDTO> GetResult()
        {
            return _result;
        }
    }
}
