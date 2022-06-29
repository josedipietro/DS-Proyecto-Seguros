using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IPolicyDAO
    {
        Task<Policy?> GetPolicy(Guid id);
        Task<List<Policy>> GetPolicies(Guid? vehicleId, EnumPolicyType? policyType);
        Task<Policy> DeletePolicy(Policy policy);
        Task<Policy> CreatePolicy(PolicyDTO policyDTO);
    }
}
