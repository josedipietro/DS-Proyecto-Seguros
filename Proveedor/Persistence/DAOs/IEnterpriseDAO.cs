using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public interface IEnterpriseDAO
    {
        public Task<Enterprise?> GetEnterprise(Guid id);
        
        
        public Task<Enterprise> DeleteEnterprise(Enterprise enterprise);

        public Task<Enterprise> CreateEnterprise(EnterpriseDTO enterprise);

        public Task<Enterprise> UpdateEnterprise(
            Enterprise enterprise,
            EnterpriseUpdateDTO enterpriseDTO
        );
    }
}