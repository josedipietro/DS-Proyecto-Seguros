using Microsoft.EntityFrameworkCore;
using Perito.Persistence.Database;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public interface IUserDAO
    {
        Task<User?> GetUser(Guid id);

        Task<User?> GetUser(string email);

        Task<List<User>> GetUsers(Guid? enterpriseId);

        // Delete (Change IsActive to false)
        Task<User> DeleteUser(User user);

        // Create
        Task<User> CreateUser(UserDTO userDTO);
    }
}
