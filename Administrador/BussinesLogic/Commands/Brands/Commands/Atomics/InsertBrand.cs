using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.Mappers;

namespace Administrador.BussinesLogic.Commands.Brands.Commands.Atomics
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
