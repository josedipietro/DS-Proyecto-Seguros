using Microsoft.EntityFrameworkCore;
using Perito.Persistence.Database;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public class UserDAO
    {
        private readonly PeritoDbContext _context;

        public UserDAO(PeritoDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(Guid id)
        {
            return await _context.Users
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUser(string email)
        {
            return await _context.Users
                .Where(b => (b.IsActive == true) && (b.Email == email))
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers(Guid? enterpriseId)
        {
            return await _context.Users
                .Where(
                    e =>
                        (e.IsActive == true)
                )
                .ToListAsync();
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
            var incidents = await _context.Incidents
                .Where(b => (b.IsActive == true) && userDTO.Incidents.Contains(b.Id.ToString())).ToListAsync();
            var user = new User
            {
                Id = Guid.NewGuid(),
                LdapID = Guid.NewGuid().ToString(),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Incidents = incidents,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
