using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.Mappers;

namespace Administrador.BussinesLogic.Commands.Brands.Commands.Atomics
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
