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
    public class PartQuotationsController : ControllerBase
    {
        private readonly ProveedorDbContext _context;

        public PartQuotationsController(ProveedorDbContext context)
        {
            _context = context;
        }

        // GET: api/PartQuotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartQuotation>>> GetPartQuotations()
        {
          if (_context.PartQuotations == null)
          {
              return NotFound();
          }
            return await _context.PartQuotations.ToListAsync();
        }

        // GET: api/PartQuotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartQuotation>> GetPartQuotation(Guid id)
        {
          if (_context.PartQuotations == null)
          {
              return NotFound();
          }
            var partQuotation = await _context.PartQuotations.FindAsync(id);

            if (partQuotation == null)
            {
                return NotFound();
            }

            return partQuotation;
        }

        // PUT: api/PartQuotations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartQuotation(Guid id, PartQuotation partQuotation)
        {
            if (id != partQuotation.Id)
            {
                return BadRequest();
            }

            _context.Entry(partQuotation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartQuotationExists(id))
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

        // POST: api/PartQuotations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartQuotation>> PostPartQuotation(PartQuotation partQuotation)
        {
          if (_context.PartQuotations == null)
          {
              return Problem("Entity set 'ProveedorDbContext.PartQuotations'  is null.");
          }
            _context.PartQuotations.Add(partQuotation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartQuotation", new { id = partQuotation.Id }, partQuotation);
        }

        // DELETE: api/PartQuotations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartQuotation(Guid id)
        {
            if (_context.PartQuotations == null)
            {
                return NotFound();
            }
            var partQuotation = await _context.PartQuotations.FindAsync(id);
            if (partQuotation == null)
            {
                return NotFound();
            }

            _context.PartQuotations.Remove(partQuotation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartQuotationExists(Guid id)
        {
            return (_context.PartQuotations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
