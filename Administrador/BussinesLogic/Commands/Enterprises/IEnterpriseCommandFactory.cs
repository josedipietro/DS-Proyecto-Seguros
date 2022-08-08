using Administrador.BussinesLogic.Commands.Enterprises.Commands.Atomics;
using Administrador.BussinesLogic.Commands.Enterprises.Commands.Compose;
using Administrador.Persistence.DAOs;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.Commands.Enterprises
{
    public interface IEnterpriseCommandFactory
    {
        Task<GetEnterprises> GetEnterprises(
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        );
        Task<GetEnterprise> GetEnterprise(Guid id);
        Task<UpdateEnterprise> UpdateEnterprise(
            Enterprise enterprise,
            EnterpriseUpdateDTO updateEnterpriseDTO
        );
        Task<GetAndUpdateEnterprise> GetAndUpdateEnterprise(
            Guid id,
            EnterpriseUpdateDTO updateEnterpriseDTO
        );
        Task<InsertEnterprise> InsertEnterprise(EnterpriseDTO enterpriseDTO);
    }
}
