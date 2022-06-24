using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Database;
using Administrador.Persistence.Entities;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredsController : ControllerBase
    {
        private readonly AdministradorDbContext _context;

        public InsuredsController(AdministradorDbContext context)
        {
            _context = context;
        }

        // GET: api/Insureds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insured>>> GetInsureds()
        {
          if (_context.Insureds == null)
          {
              return NotFound();
          }
            return await _context.Insureds.ToListAsync();
        }

        // GET: api/Insureds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insured>> GetInsured(Guid id)
        {
          if (_context.Insureds == null)
          {
              return NotFound();
          }
            var insured = await _context.Insureds.FindAsync(id);

            if (insured == null)
            {
                return NotFound();
            }

            return insured;
        }

        // PUT: api/Insureds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsured(Guid id, Insured insured)
        {
            if (id != insured.Id)
            {
                return BadRequest();
            }

            _context.Entry(insured).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuredExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Insureds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insured>> PostInsured(Insured insured)
        {
          if (_context.Insureds == null)
          {
              return Problem("Entity set 'AdministradorDbContext.Insureds'  is null.");
          }
            _context.Insureds.Add(insured);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsured", new { id = insured.Id }, insured);
        }

        // DELETE: api/Insureds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsured(Guid id)
        {
            if (_context.Insureds == null)
            {
                return NotFound();
            }
            var insured = await _context.Insureds.FindAsync(id);
            if (insured == null)
            {
                return NotFound();
            }

            _context.Insureds.Remove(insured);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuredExists(Guid id)
        {
            return (_context.Insureds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
