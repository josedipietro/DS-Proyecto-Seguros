using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IBrandDAO
    {
        public bool BrandExists(string id);
        public Task<Brand> Create(BrandDTO brand);
        public Task<List<Brand>> List();
        public Task<Brand?> Get(string id);
        public Task<Brand> Update(Brand brand, UpdateBrandDTO brandDTO);
    }
}
