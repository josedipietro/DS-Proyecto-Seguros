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
    public class PartQuotationsController : ControllerBase
    {
        private readonly ProveedorDbContext _context;
        private readonly PartQuotationDAO _partQuotationDAO;

        public PartQuotationsController(ProveedorDbContext context)
        {
            _context = context;
            _partQuotationDAO = new PartQuotationDAO(context);
        }

        // GET: api/PartQuotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartQuotation>>> GetPartQuotations()
        {
          if (_context.PartQuotations == null)
          {
              return NotFound();
          }
            return await _partQuotationDAO.GetPartQuotations();
        }

        // GET: api/PartQuotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartQuotation>> GetPartQuotation(Guid id)
        {
          if (_context.PartQuotations == null)
          {
              return NotFound();
          }
            var partQuotation = await _partQuotationDAO.GetPartQuotation(id);

            if (partQuotation == null)
            {
                return NotFound();
            }

            return partQuotation;
        }

        // PUT: api/PartQuotations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartQuotation(Guid id, PartQuotationDTO partQuotationDTO)
        {
            if (!_partQuotationDAO.PartQuotationExist(id))
            {
                return NotFound();
            }

            var partQuotation = await _partQuotationDAO.GetPartQuotation(id);

            return partQuotation == null ? NotFound() : Ok(partQuotation);

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
        public async Task<ActionResult<PartQuotation>> PostPartQuotation(PartQuotationDTO partQuotationDTO)
        {
          if (_context.PartQuotations == null)
          {
              return Problem("Entity set 'ProveedorDbContext.PartQuotations'  is null.");
          }
           var partQuotation = await _partQuotationDAO.CreateParticipation(partQuotationDTO);
  

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
            return _partQuotationDAO.PartQuotationExist(id);
        }
    }
}
