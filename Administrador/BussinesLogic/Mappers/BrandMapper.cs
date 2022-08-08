using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.Mappers
{
    public class BrandMapper
    {
        public static BrandDTO MapEntityToDTO(Brand brand)
        {
            return new BrandDTO
            {
                Code = brand.Code,
                Name = brand.Name,
                Description = brand.Description
            };
        }

        public static UpdateBrandDTO MapEntityToUpdateDTO(Brand brand)
        {
            return new UpdateBrandDTO
            {
                Name = brand.Name,
                Description = brand.Description
            };
        }


        public static Brand MapDTOtoEntity(BrandDTO brand)
        {
            return new Brand
            {
                Code = brand.Code,
                Name = brand.Name,
                Description = brand.Description
            };
        }
    }
}
