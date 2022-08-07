using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.DAOs;
using Proveedor.Persistence.Database;
using Proveedor.Persistence.Entities;

namespace Proveedor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProveedorDbContext _context;
        private readonly UserDAO _usersDAO;

        public UsersController(ProveedorDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _usersDAO.GetUsers(null);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            return await _usersDAO.GetUser(id);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {

            var userToUpdate = await _context.Enterprises.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                return await _usersDAO.
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

        }*/

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO user)
        {
            var createdUser = await _usersDAO.CreateUser(user);
            return CreatedAtAction("GetUser", createdUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var userToUpdate = await _context.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }
            try
            {
                await _usersDAO.DeleteUser(userToUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
