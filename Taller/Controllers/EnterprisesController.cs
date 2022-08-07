using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.DAOs;
using Taller.Persistence.Database;
using Taller.Persistence.Entities;

namespace Taller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private readonly TallerDbContext _context;
        private readonly EnterpriseDAO _enterpriseDAO;

        public EnterprisesController(TallerDbContext context)
        {
            _context = context;
            _enterpriseDAO = new EnterpriseDAO(context);
        }

        // GET: api/Enterprises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enterprise>>> GetEnterprises()
        {
          if (_context.Enterprises == null)
          {
              return NotFound();
          }
            return await _enterpriseDAO.GetEnterprises(null);
        }

        [HttpGet("{brand}")]
        public async Task<ActionResult<IEnumerable<Enterprise>>> GetEnterprisesByBrand(string brand)
        {
            if (_context.Enterprises == null)
            {
                return NotFound();
            }
            var brands = new List<string>();
            brands.Add(brand);
            return await _enterpriseDAO.GetEnterprises(brands);
        }

        // GET: api/Enterprises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enterprise>> GetEnterprise(Guid id)
        {
          if (_context.Enterprises == null)
          {
              return NotFound();
          }
            var enterprise = await _enterpriseDAO.GetEnterprise(id);

            if (enterprise == null)
            {
                return NotFound();
            }

            return enterprise;
        }

        // PUT: api/Enterprises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutEnterprise(Guid id, EnterpriseDTO enterpriseDTO)
        {
            if (id != enterprise.Id)
            {
                return BadRequest();
            }

            _context.Entry(enterprise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnterpriseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Enterprises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Enterprise>> PostEnterprise(Enterprise enterprise)
        {
          if (_context.Enterprises == null)
          {
              return Problem("Entity set 'TallerDbContext.Enterprises'  is null.");
          }
            _context.Enterprises.Add(enterprise);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (_enterpriseDAO.EnterpriseExists(enterprise.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnterprise", new { id = enterprise.Id }, enterprise);
        }*/

        // DELETE: api/Enterprises/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise(Guid id)
        {
            
            if (_enterpriseDAO.)
            {
                return NotFound();
            }
            var enterprise = await _context.Enterprises.FindAsync(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            _context.Enterprises.Remove(enterprise);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        /*private bool EnterpriseExists(Guid id)
        {
            return (_context.Enterprises?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
