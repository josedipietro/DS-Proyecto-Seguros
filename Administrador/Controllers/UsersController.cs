using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Database;
using Administrador.Persistence.Entities;
using Administrador.Persistence.DAOs;
using Administrador.BussinesLogic.DTOs;
using Base.Services.RabbitMQ;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserDAO _userDAO;
        private readonly AmqpService _amqpService;

        public UsersController(IUserDAO userDAO, AmqpService amqpService)
        {
            _userDAO = userDAO;
            _amqpService = amqpService ?? throw new ArgumentNullException(nameof(amqpService));
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(
            EnumRole? role,
            Guid? enterpriseId
        )
        {
            return await _userDAO.GetUsers(role, enterpriseId);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userDAO.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(Guid id, UserDTO userDTO)
        {
            var user = await _userDAO.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                user = await _userDAO.UpdateUser(user, userDTO);
                switch (user.Role)
                {
                    case EnumRole.Workshop:
                        await _amqpService.SendMessageAsync(user, "workshop-user-update");
                        break;
                    case EnumRole.Supplier:
                        await _amqpService.SendMessageAsync(user, "supplier-user-update");
                        break;
                    case EnumRole.Proficient:
                        await _amqpService.SendMessageAsync(user, "proficient-user-update");
                        break;
                    default:
                        break;
                }
                return user;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            var user = await _userDAO.CreateUser(userDTO);

            // Send message to RabbitMQ

            switch (user.Role)
            {
                case EnumRole.Workshop:
                    await _amqpService.SendMessageAsync(user, "workshop-user-create");
                    break;
                case EnumRole.Supplier:
                    await _amqpService.SendMessageAsync(user, "supplier-user-create");
                    break;
                case EnumRole.Proficient:
                    await _amqpService.SendMessageAsync(user, "proficient-user-create");
                    break;
                default:
                    break;
            }

            //TODO: CREATE USER IN LDAP

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userDAO.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            user = await _userDAO.DeleteUser(user);
            switch (user.Role)
            {
                case EnumRole.Workshop:
                    await _amqpService.SendMessageAsync(user, "workshop-user-update");
                    break;
                case EnumRole.Supplier:
                    await _amqpService.SendMessageAsync(user, "supplier-user-update");
                    break;
                case EnumRole.Proficient:
                    await _amqpService.SendMessageAsync(user, "proficient-user-update");
                    break;
                default:
                    break;
            }
            return NoContent();
        }
    }
}
