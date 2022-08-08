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
                Id = enterprise.Id,
                Rif = enterprise.Rif,
                Name = enterprise.Name,
                Email = enterprise.Email,
                Phone = enterprise.Phone,
                Address = enterprise.Address,
                EnterpriseType = enterprise.EnterpriseType,
                ParishId = enterprise.ParishId,
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
                Rif = enterprise.Rif,
                Name = enterprise.Name,
                Email = enterprise.Email,
                Phone = enterprise.Phone,
                Address = enterprise.Address,
                ParishId = enterprise.ParishId,
                Brands = _brands,
            };
        }

        public static Enterprise MapDTOtoEntity(EnterpriseDTO enterprise)
        {
            return new Enterprise
            {
                Rif = enterprise.Rif,
                Name = enterprise.Name,
                Email = enterprise.Email,
                Phone = enterprise.Phone,
                Address = enterprise.Address,
                EnterpriseType = enterprise.EnterpriseType,
                ParishId = enterprise.ParishId,
                Brands = new List<Brand>(),
            };
        }
    }
}
