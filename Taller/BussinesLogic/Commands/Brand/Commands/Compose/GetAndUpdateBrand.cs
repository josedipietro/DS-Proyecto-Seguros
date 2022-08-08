using Taller.BussinesLogic.Commands;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.DAOs;
using Taller.BussinesLogic.Mappers;

namespace Taller.BussinesLogic.Commands.Brands.Commands.Compose
{
    public class GetAndUpdateBrand : Command<BrandDTO>
    {
        private readonly IBrandDAO _brandDAO;

        private string _id;
        private UpdateBrandDTO _updateBrandDTO;
        private BrandDTO _brand;

        public GetAndUpdateBrand(IBrandDAO brandDAO, string id, UpdateBrandDTO updateBrandDTO)
        {
            _brandDAO = brandDAO;
            _id = id;
            _updateBrandDTO = updateBrandDTO;
        }

        public override async Task Execute()
        {
            var brand = await _brandDAO.Get(_id);
            if (brand != null)
            {
                var brandUpdated = await _brandDAO.Update(brand, _updateBrandDTO);
                _brand = BrandMapper.MapEntityToDTO(brandUpdated);
            }
        }

        public override async Task<BrandDTO> GetResult()
        {
            return _brand;
        }
    }
}