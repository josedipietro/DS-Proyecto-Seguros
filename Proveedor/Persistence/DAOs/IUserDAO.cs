using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public interface IUserDAO
    {
        Task<User?> GetUser(Guid id);
        Task<User?> GetUser(string email);
        Task<List<User>> GetUsers(Guid? enterpriseId);
        Task<User> DeleteUser(User user);
        Task<User> CreateUser(UserDTO userDTO);
    }
}
