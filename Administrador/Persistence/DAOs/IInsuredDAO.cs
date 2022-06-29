using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IInsuredDAO
    {
        Task<Insured?> GetInsured(Guid id);
        Task<Insured?> GetInsured(string name);
        Task<List<Insured>> GetInsureds();
        Task<Insured> CreateInsured(InsuredDTO insuredDTO);
        Task<Insured> UpdateInsured(Insured insured, InsuredDTO insuredDTO);

        Task<Insured> DeleteInsured(Insured insured);
    }
}
