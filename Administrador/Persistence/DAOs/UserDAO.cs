using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;
using Administrador.BussinesLogic.DTOs;

namespace Administrador.Persistence.DAOs
{
    public class UserDAO : IUserDAO
    {
        private readonly IAdministradorDbContext _context;

        public UserDAO(IAdministradorDbContext context)
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

        public async Task<List<User>> GetUsers(EnumRole? role, Guid? enterpriseId)
        {
            return await _context.Users
                .Where(
                    e =>
                        (e.IsActive == true)
                        && (role.HasValue ? e.Role == role : true)
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
            if (new List<EnumRole> { EnumRole.Workshop, EnumRole.Supplier }.Contains(userDTO.Role))
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
            }
            else
            {
                userDTO.EnterpriseId = null;
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                LdapID = Guid.NewGuid().ToString(),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Identification = userDTO.Identification,
                IdentificationType = userDTO.IdentificationType,
                Phone = userDTO.Phone,
                Password = userDTO.Password,
                Role = userDTO.Role,
                EnterpriseId = userDTO.EnterpriseId,
                IsActive = true,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Update User
        public async Task<User> UpdateUser(User user, UserDTO userDTO)
        {
            if (new List<EnumRole> { EnumRole.Workshop, EnumRole.Supplier }.Contains(userDTO.Role))
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
            }
            else
            {
                userDTO.EnterpriseId = null;
            }

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Role = userDTO.Role;
            user.EnterpriseId = userDTO.EnterpriseId;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
