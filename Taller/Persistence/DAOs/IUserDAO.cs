using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Entities;

namespace Taller.Persistence.DAOs
{
    public interface IUserDAO
    {
        public Task<User?> GetUser(Guid id);
        public Task<User?> GetUser(string email);
        public Task<User> DeleteUser(User user);
        public Task<User> CreateUser(UserDTO userDTO);
    }
}
