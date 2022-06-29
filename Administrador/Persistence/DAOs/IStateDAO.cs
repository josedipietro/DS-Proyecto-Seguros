using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IStateDAO
    {
        bool StateExists(int id);
        Task<State?> GetState(int id);
        Task<State?> GetState(string name);
        Task<List<State>> GetStates();
    }
}
