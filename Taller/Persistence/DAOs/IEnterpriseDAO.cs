using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Entities;

namespace Taller.Persistence.DAOs
{
    public interface IEnterpriseDAO
    {
        public Task<Enterprise?> GetEnterprise(Guid id);
        public Task<List<Enterprise>> GetEnterprises(
            //int? parishId,
            List<string>? brands
        //EnumEnterpriseType? EnterpriseType
        );

        public Task<Enterprise> DeleteEnterprise(Enterprise enterprise);

        public Task<Enterprise> CreateEnterprise(EnterpriseDTO enterpriseDTO);

        public Task<Enterprise> UpdateEnterprise(
            Enterprise enterprise,
            EnterpriseUpdateDTO enterpriseDTO
        );
        public bool EnterpriseExists(Guid id);
    }
}
