using Proveedor.BussinesLogic.Commands.Brands.Commands.Atomics;
using Proveedor.BussinesLogic.Commands.Brands.Commands.Compose;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.Commands.Brands
{
    public interface IBrandCommandFactory
    {
        Task<GetBrands> GetBrands();
        Task<GetBrand> GetBrand(string id);

        Task<UpdateBrand> UpdateBrand(Brand brand, UpdateBrandDTO updateBrandDTO);

        Task<GetAndUpdateBrand> GetAndUpdateBrand(string id, UpdateBrandDTO updateBrandDTO);

        Task<InsertBrand> InsertBrand(BrandDTO brandDTO);
    }
}
