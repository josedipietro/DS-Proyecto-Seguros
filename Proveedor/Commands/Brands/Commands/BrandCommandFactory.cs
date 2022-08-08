using Proveedor.BussinesLogic.Commands.Brands.Commands.Atomics;
using Proveedor.BussinesLogic.Commands.Brands.Commands.Compose;
using Proveedor.Persistence.DAOs;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.Commands.Brands
{
    public class BrandCommandFactory : IBrandCommandFactory
    {
        private readonly IBrandDAO _brandDAO;

        public BrandCommandFactory(IBrandDAO brandDAO)
        {
            _brandDAO = brandDAO;
        }

        public Task<GetBrands> GetBrands()
        {
            return Task<GetBrands>.Run(() => new GetBrands(_brandDAO));
        }

        public Task<GetBrand> GetBrand(string id)
        {
            return Task<GetBrand>.Run(() => new GetBrand(_brandDAO, id));
        }

        public Task<UpdateBrand> UpdateBrand(Brand brand, UpdateBrandDTO updateBrandDTO)
        {
            return Task<UpdateBrand>.Run(() => new UpdateBrand(_brandDAO, brand, updateBrandDTO));
        }

        public Task<GetAndUpdateBrand> GetAndUpdateBrand(string id, UpdateBrandDTO updateBrandDTO)
        {
            return Task<GetAndUpdateBrand>.Run(
                () => new GetAndUpdateBrand(_brandDAO, id, updateBrandDTO)
            );
        }

        public Task<InsertBrand> InsertBrand(BrandDTO brandDTO)
        {
            return Task<InsertBrand>.Run(() => new InsertBrand(_brandDAO, brandDTO));
        }
    }
}