using Administrador.BussinesLogic.Commands;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using Administrador.BussinesLogic.Mappers;

namespace Administrador.BussinesLogic.Commands.Brands.Commands.Atomics
{
    public class GetBrand : Command<BrandDTO>
    {
        private readonly IBrandDAO _brandDAO;

        private readonly string _id;
        private BrandDTO _brand;

        public GetBrand(IBrandDAO brandDAO, string id)
        {
            _brandDAO = brandDAO;
            _id = id;
        }

        public override async Task Execute()
        {
            var brand = await _brandDAO.Get(_id);
            if (brand != null)
            {
                _brand = BrandMapper.MapEntityToDTO(brand);
            }
        }

        public override async Task<BrandDTO?> GetResult()
        {
            return _brand;
        }
    }
}
