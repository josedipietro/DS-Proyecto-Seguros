using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Database;
using Proveedor.Persistence.Entities;

namespace Proveedor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly ProveedorDbContext _context;

        public PartsController(ProveedorDbContext context)
        {
            _context = context;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
          if (_context.Parts == null)
          {
              return NotFound();
          }
            return await _context.Parts.ToListAsync();
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(Guid id)
        {
          if (_context.Parts == null)
          {
              return NotFound();
          }
            var part = await _context.Parts.FindAsync(id);

            if (part == null)
            {
                return NotFound();
            }

            return part;
        }

        // PUT: api/Parts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart(Guid id, Part part)
        {
            if (id != part.Id)
            {
                return BadRequest();
            }

            _context.Entry(part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
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

        // POST: api/Parts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Part>> PostPart(Part part)
        {
          if (_context.Parts == null)
          {
              return Problem("Entity set 'ProveedorDbContext.Parts'  is null.");
          }
            _context.Parts.Add(part);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartExists(part.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPart", new { id = part.Id }, part);
        }

        // DELETE: api/Parts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart(Guid id)
        {
            if (_context.Parts == null)
            {
                return NotFound();
            }
            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartExists(Guid id)
        {
            return (_context.Parts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
