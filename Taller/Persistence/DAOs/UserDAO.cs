using Microsoft.EntityFrameworkCore;
using Taller.Persistence.Entities;
using Taller.Persistence.Database;
using Taller.BussinesLogic.DTOs;

namespace Taller.Persistence.DAOs
{
    public class UserDAO : IUserDAO
    {
        private readonly TallerDbContext _context;

        public UserDAO(TallerDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(Guid id)
        {
            return await _context.User
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUser(string email)
        {
            return await _context.User
                .Where(b => (b.IsActive == true) && (b.Email == email))
                .FirstOrDefaultAsync();
        }

        // Delete (Change IsActive to false)
        public async Task<User> DeleteUser(User user)
        {
            user.IsActive = false;
            await _context.SaveChangesAsync();
            return user;
        }

        // Create
        public async Task<User> CreateUser(UserDTO userDTO)
        {
                if (userDTO.EnterpriseId == null)
                {
                    throw new Exception("EnterpriseId is required");
                }

                var enterprise = await _context.Enterprises
                    .Where(b => (b.IsActive == true) && (b.Id == userDTO.EnterpriseId))
                    .FirstOrDefaultAsync();
                if (enterprise == null)
                {
                    throw new Exception("Enterprise not found");
                }
       

            var user = new User
            {
                Id = Guid.NewGuid(),
                LdapID = Guid.NewGuid().ToString(),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                EnterpriseId = userDTO.EnterpriseId,
                IsActive = true,
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
