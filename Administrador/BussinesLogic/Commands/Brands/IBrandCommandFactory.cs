using Administrador.BussinesLogic.Commands.Brands.Commands.Atomics;
using Administrador.BussinesLogic.Commands.Brands.Commands.Compose;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.Commands.Brands
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
