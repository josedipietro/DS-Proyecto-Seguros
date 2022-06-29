using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IEnterpriseDAO
    {
        public Task<Enterprise?> GetEnterprise(Guid id);
        public Task<Enterprise?> GetEnterprise(string name);
        public Task<List<Enterprise>> GetEnterprises(
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        );

        public Task<Enterprise> DeleteEnterprise(Enterprise enterprise);

        public Task<Enterprise> CreateEnterprise(EnterpriseDTO enterprise);

        public Task<Enterprise> UpdateEnterprise(
            Enterprise enterprise,
            EnterpriseUpdateDTO enterpriseDTO
        );
    }
}
