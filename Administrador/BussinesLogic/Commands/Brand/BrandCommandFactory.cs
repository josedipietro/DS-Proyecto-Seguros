using Administrador.BussinesLogic.Commands.Brand.Commands.Atomics;
using Administrador.Persistence.DAOs;

namespace Administrador.BussinesLogic.Commands.Brand
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
    }
}
