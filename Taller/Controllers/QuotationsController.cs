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
    public class QuotationsController : ControllerBase
    {
        private readonly TallerDbContext _context;
        private readonly QuotationDAO _quotationDAO;
        public QuotationsController(TallerDbContext context)
        {
            _context = context;
            _quotationDAO = new QuotationDAO(context);
        }

        // GET: api/Quotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotations()
        {
          if (_context.Quotations == null)
          {
              return NotFound();
          }
            return await _quotationDAO.GetQuotations();
        }

        // GET: api/Quotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quotation>> GetQuotation(Guid id)
        {
          if (_context.Quotations == null)
          {
              return NotFound();
          }
            var quotation = await _quotationDAO.GetQuotation(id);

            if (quotation == null)
            {
                return NotFound();
            }

            return quotation;
        }

        // PUT: api/Quotations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotation(Guid id, QuotationDTO quotationDTO)
        {
            if (!_quotationDAO.QuotationExist(id))
            {
                return NotFound();
            }

                var quotation = await _quotationDAO.UpdateQuotation(id, quotationDTO);

            return quotation == null ? NotFound() : Ok(quotation);
        }

        /* 
        public async Task<IActionResult> PutParticipation(Guid id, ParticipationDTO participationDTO)
        {
            if (!_participationDAO.ParticipationExists(id))
            {
                return NotFound();
            } 
                var participation = await _participationDAO.UpdateParticipation(id, participationDTO);

            return participation == null ? NotFound() : Ok(participation);
        }*/
        // POST: api/Quotations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quotation>> PostQuotation(QuotationDTO quotationDTO)
        {
          if (_context.Quotations == null)
          {
              return Problem("Entity set 'TallerDbContext.Quotations'  is null.");
          }
           // _context.Quotations.Add(quotation);
            var quotation = await _quotationDAO.CreateQuotation(quotationDTO);

            return CreatedAtAction("GetQuotation", new { id = quotation.Id }, quotation);
        }

        // DELETE: api/Quotations/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotation(Guid id)
        {
            if (_context.Quotations == null)
            {
                return NotFound();
            }
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return NotFound();
            }

            _context.Quotations.Remove(quotation);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool QuotationExists(Guid id)
        {
            return _quotationDAO.QuotationExist(id);
        }
    }
}
