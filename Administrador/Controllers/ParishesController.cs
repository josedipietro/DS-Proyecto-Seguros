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
    public class ParishesController : ControllerBase
    {
        private readonly AdministradorDbContext _context;

        public ParishesController(AdministradorDbContext context)
        {
            _context = context;
        }

        // GET: api/Parishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parish>>> GetParishes()
        {
          if (_context.Parishes == null)
          {
              return NotFound();
          }
            return await _context.Parishes.ToListAsync();
        }

        // GET: api/Parishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parish>> GetParish(int id)
        {
          if (_context.Parishes == null)
          {
              return NotFound();
          }
            var parish = await _context.Parishes.FindAsync(id);

            if (parish == null)
            {
                return NotFound();
            }

            return parish;
        }

        // PUT: api/Parishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParish(int id, Parish parish)
        {
            if (id != parish.Id)
            {
                return BadRequest();
            }

            _context.Entry(parish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParishExists(id))
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

        // POST: api/Parishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parish>> PostParish(Parish parish)
        {
          if (_context.Parishes == null)
          {
              return Problem("Entity set 'AdministradorDbContext.Parishes'  is null.");
          }
            _context.Parishes.Add(parish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParish", new { id = parish.Id }, parish);
        }

        // DELETE: api/Parishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParish(int id)
        {
            if (_context.Parishes == null)
            {
                return NotFound();
            }
            var parish = await _context.Parishes.FindAsync(id);
            if (parish == null)
            {
                return NotFound();
            }

            _context.Parishes.Remove(parish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParishExists(int id)
        {
            return (_context.Parishes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
