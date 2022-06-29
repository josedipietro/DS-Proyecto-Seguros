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
    public class PartsController : ControllerBase
    {
        private readonly ProveedorDbContext _context;
        private readonly PartDAO _partDAO;
        public PartsController(ProveedorDbContext context)
        {
            _context = context;
            _partDAO = new PartDAO(context);
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
            return await _partDAO.GetParts();
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(Guid id)
        {
            if(_context.Parts == null)
            {
                return NotFound();   
            }
            var part = await _partDAO.GetPart(id);

            if (part == null)
            {
                return NotFound();
            }

            return part;
        }

        // PUT: api/Parts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart(Guid id, PartDTO partDTO)
        {
            if (!_partDAO.PartExists(id))
            {
                return NotFound();
            }

            try
            {
                var part = await _partDAO.GetPart(id);

                if (part == null)
                {
                    return BadRequest();
                }
                _context.Entry(part).State = EntityState.Modified;

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
        public async Task<ActionResult<Part>> PostPart(PartDTO partDTO)
        {
            if (_context.Parts == null)
            {
                return Problem("Entity set 'ProveedorDbContext.Parts'  is null.");
            }
            var part = await _partDAO.CreatePart(partDTO);

            return CreatedAtAction("GetPart", new { id = part.Id }, part);
        }

        // DELETE: api/Parts/5
       /* [HttpDelete("{id}")]
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
        }*/

        private bool PartExists(Guid id)
        {
            return _partDAO.PartExists(id);
        }
    }
}
