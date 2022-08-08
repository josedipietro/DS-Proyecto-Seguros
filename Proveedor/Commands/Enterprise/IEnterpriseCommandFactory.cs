using Proveedor.BussinesLogic.Commands.Enterprises.Commands.Atomics;
using Proveedor.BussinesLogic.Commands.Enterprises.Commands.Compose;
using Proveedor.Persistence.DAOs;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.Commands.Enterprises
{
    public interface IEnterpriseCommandFactory
    {
        Task<GetEnterprises> GetEnterprises(
            int? parishId,
            List<string>? brands
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
