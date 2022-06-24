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
    public class RepairRequestsController : ControllerBase
    {
        private readonly AdministradorDbContext _context;

        public RepairRequestsController(AdministradorDbContext context)
        {
            _context = context;
        }

        // GET: api/RepairRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairRequest>>> GetRepairRequests()
        {
          if (_context.RepairRequests == null)
          {
              return NotFound();
          }
            return await _context.RepairRequests.ToListAsync();
        }

        // GET: api/RepairRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairRequest>> GetRepairRequest(Guid id)
        {
          if (_context.RepairRequests == null)
          {
              return NotFound();
          }
            var repairRequest = await _context.RepairRequests.FindAsync(id);

            if (repairRequest == null)
            {
                return NotFound();
            }

            return repairRequest;
        }

        // PUT: api/RepairRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairRequest(Guid id, RepairRequest repairRequest)
        {
            if (id != repairRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(repairRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairRequestExists(id))
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

        // POST: api/RepairRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepairRequest>> PostRepairRequest(RepairRequest repairRequest)
        {
          if (_context.RepairRequests == null)
          {
              return Problem("Entity set 'AdministradorDbContext.RepairRequests'  is null.");
          }
            _context.RepairRequests.Add(repairRequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepairRequestExists(repairRequest.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepairRequest", new { id = repairRequest.Id }, repairRequest);
        }

        // DELETE: api/RepairRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairRequest(Guid id)
        {
            if (_context.RepairRequests == null)
            {
                return NotFound();
            }
            var repairRequest = await _context.RepairRequests.FindAsync(id);
            if (repairRequest == null)
            {
                return NotFound();
            }

            _context.RepairRequests.Remove(repairRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairRequestExists(Guid id)
        {
            return (_context.RepairRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
