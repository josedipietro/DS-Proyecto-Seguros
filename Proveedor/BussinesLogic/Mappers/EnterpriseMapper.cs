using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.Mappers
{
    public class EnterpriseMapper
    {
        public static EnterpriseDTO MapEntityToDTO(Enterprise enterprise)
        {
            var _brands = new List<string>();
            foreach (var brand in enterprise.Brands)
            {
                _brands.Add(brand.Name);
            }
            return new EnterpriseDTO
            {
                Brands = _brands,
            };
        }

        public static EnterpriseUpdateDTO MapEntityToUpdateDTO(Enterprise enterprise)
        {
            var _brands = new List<string>();
            foreach (var brand in enterprise.Brands)
            {
                _brands.Add(brand.Name);
            }

            return new EnterpriseUpdateDTO
            {
                Brands = _brands,
            };
        }

        public static Enterprise MapDTOtoEntity(EnterpriseDTO enterprise)
        {
            return new Enterprise
            {
                Brands = new List<Brand>(),
            };
        }
    }
}
