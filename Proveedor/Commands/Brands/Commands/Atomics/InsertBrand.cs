using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.Persistence.Entities;
using Proveedor.BussinesLogic.Mappers;

namespace Proveedor.BussinesLogic.Commands.Brands.Commands.Atomics
{
    public class InsertBrand : Command<BrandDTO>
    {
        private readonly IBrandDAO _brandDAO;

        private BrandDTO _brandDTO;

        private BrandDTO _brand;

        public InsertBrand(IBrandDAO brandDAO, BrandDTO brandDTO)
        {
            _brandDAO = brandDAO;
            _brandDTO = brandDTO;
        }

        public override async Task Execute()
        {
            var brandInserted = await _brandDAO.Create(_brandDTO);
            _brand = BrandMapper.MapEntityToDTO(brandInserted);
        }

        public override async Task<BrandDTO> GetResult()
        {
            return _brand;
        }
    }
}
