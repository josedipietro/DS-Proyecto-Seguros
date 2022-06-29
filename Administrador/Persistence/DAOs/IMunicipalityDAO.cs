using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IMunicipalityDAO
    {
        bool MunicipalityExists(int id);
        Task<Municipality?> GetMunicipality(int id);
        Task<Municipality?> GetMunicipality(string name);
        Task<List<Municipality>> GetMunicipalities(int? stateId);
    }
}
