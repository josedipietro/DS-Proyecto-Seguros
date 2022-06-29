using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IParishDAO
    {
        bool ParishExists(int id);
        Task<Parish?> GetParish(int id);
        Task<Parish?> GetParish(string name);
        Task<List<Parish>> GetParishes(int? municipalityId);
    }
}
