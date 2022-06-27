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

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private readonly AdministradorDbContext _context;

        private readonly EnterpriseDAO _enterpriseDAO;

        public EnterprisesController(AdministradorDbContext context)
        {
            _enterpriseDAO = new EnterpriseDAO(context);
            _context = context;
        }

        // GET: api/Enterprises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enterprise>>> GetEnterprises(
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        )
        {
            return await _enterpriseDAO.GetEnterprises(parishId, brands, EnterpriseType);
        }

        // GET: api/Enterprises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enterprise>> GetEnterprise(Guid id)
        {
            var enterprise = await _enterpriseDAO.GetEnterprise(id);

            if (enterprise == null)
            {
                return NotFound();
            }
            return enterprise;
        }

        // PUT: api/Enterprises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Enterprise>> PutEnterprise(
            Guid id,
            EnterpriseUpdateDTO enterprise
        )
        {
            var enterpriseToUpdate = await _context.Enterprises.FindAsync(id);

            if (enterpriseToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                return await _enterpriseDAO.UpdateEnterprise(enterpriseToUpdate, enterprise);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Enterprises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enterprise>> PostEnterprise(EnterpriseDTO enterpriseDTO)
        {
            var enterprise = await _enterpriseDAO.CreateEnterprise(enterpriseDTO);
            return CreatedAtAction("GetEnterprise", enterprise);
        }

        // DELETE: api/Enterprises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise(Guid id)
        {
            var enterpriseToUpdate = await _context.Enterprises.FindAsync(id);

            if (enterpriseToUpdate == null)
            {
                return NotFound();
            }
            try
            {
                await _enterpriseDAO.DeleteEnterprise(enterpriseToUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        private bool EnterpriseExists(Guid id)
        {
            return (_context.Enterprises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
