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
    public class MunicipalitiesController : ControllerBase
    {
        private readonly AdministradorDbContext _context;

        public MunicipalitiesController(AdministradorDbContext context)
        {
            _context = context;
        }

        // GET: api/Municipalities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipalities()
        {
          if (_context.Municipalities == null)
          {
              return NotFound();
          }
            return await _context.Municipalities.ToListAsync();
        }

        // GET: api/Municipalities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Municipality>> GetMunicipality(int id)
        {
          if (_context.Municipalities == null)
          {
              return NotFound();
          }
            var municipality = await _context.Municipalities.FindAsync(id);

            if (municipality == null)
            {
                return NotFound();
            }

            return municipality;
        }

        // PUT: api/Municipalities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMunicipality(int id, Municipality municipality)
        {
            if (id != municipality.Id)
            {
                return BadRequest();
            }

            _context.Entry(municipality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipalityExists(id))
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

        // POST: api/Municipalities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Municipality>> PostMunicipality(Municipality municipality)
        {
          if (_context.Municipalities == null)
          {
              return Problem("Entity set 'AdministradorDbContext.Municipalities'  is null.");
          }
            _context.Municipalities.Add(municipality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMunicipality", new { id = municipality.Id }, municipality);
        }

        // DELETE: api/Municipalities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMunicipality(int id)
        {
            if (_context.Municipalities == null)
            {
                return NotFound();
            }
            var municipality = await _context.Municipalities.FindAsync(id);
            if (municipality == null)
            {
                return NotFound();
            }

            _context.Municipalities.Remove(municipality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MunicipalityExists(int id)
        {
            return (_context.Municipalities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
