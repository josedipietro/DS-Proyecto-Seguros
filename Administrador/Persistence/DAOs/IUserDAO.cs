using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IUserDAO
    {
        Task<User?> GetUser(Guid id);
        Task<User?> GetUser(string email);
        Task<List<User>> GetUsers(EnumRole? role, Guid? enterpriseId);
        Task<User> DeleteUser(User user);
        Task<User> CreateUser(UserDTO userDTO);
        Task<User> UpdateUser(User user, UserDTO userDTO);
    }
}
