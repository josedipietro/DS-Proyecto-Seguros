using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IBrandDAO
    {
        public bool BrandExists(string id);
        public Task<BrandDTO> Create(BrandDTO brand);
        public Task<List<BrandDTO>> List();
        public Task<Brand?> Get(string id);
        public Task<BrandDTO> Update(Brand brand, UpdateBrandDTO brandDTO);
    }
}
