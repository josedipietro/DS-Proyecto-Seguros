using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Database;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public class UserDAO
    {
        private readonly ProveedorDbContext _context;

        public UserDAO(ProveedorDbContext context)
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
                        && (enterpriseId.HasValue ? e.EnterpriseId == enterpriseId : true)
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
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
