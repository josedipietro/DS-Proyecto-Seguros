using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Persistence.DAOs;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.DAOs;
using Taller.Persistence.Database;
using Taller.Persistence.Entities;

namespace Taller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairRequestsController : ControllerBase
    {
        private readonly TallerDbContext _context;
        private readonly RepairRequestDAO _repairRequestDAO;

        public RepairRequestsController(TallerDbContext context)
        {
            _context = context;
            _repairRequestDAO = new RepairRequestDAO(context);
        }

        // GET: api/RepairRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairRequest>>> GetRepairRequests()
        {
          if (_context.RepairRequests == null)
          {
              return NotFound();
          }
            return await _repairRequestDAO.GetRepairRequests();
        }

        // GET: api/RepairRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairRequest>> GetRepairRequest(Guid id)
        {
          if (_context.RepairRequests == null)
          {
              return NotFound();
          }
            var repairRequest = await _repairRequestDAO.GetRepairRequest(id);

            if (repairRequest == null)
            {
                return NotFound();
            }

            return repairRequest;
        }

        // PUT: api/RepairRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairRequest(Guid id, RepairRequestDTO repairRequestDTO)
        {
            if (!_repairRequestDAO.RepairRequestExist(id))
            {
                return NotFound();
            }

                var repairRequest = await _repairRequestDAO.UpdateRepairRequest(id, repairRequestDTO);

            return repairRequest == null ? NotFound() : Ok(repairRequest);
        }
        /*
                 public async Task<IActionResult> PutQuotation(Guid id, QuotationDTO quotationDTO)
        {
            if (!_quotationDAO.QuotationExist(id))
            {
                return NotFound();
            }

                var quotation = await _quotationDAO.UpdateQuotation(id, quotationDTO);

            return quotation == null ? NotFound() : Ok(quotation);
        }
         */

        // POST: api/RepairRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepairRequest>> PostRepairRequest(RepairRequestDTO repairRequestDTO)
        {
          if (_context.RepairRequests == null)
          {
              return Problem("Entity set 'TallerDbContext.RepairRequests'  is null.");
          }
           
            var repairRequest = await _repairRequestDAO.CreateRepairRequest(repairRequestDTO);

            return CreatedAtAction("GetRepairRequest", new { id = repairRequest.Id }, repairRequest);
        }

        // DELETE: api/RepairRequests/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairRequest(Guid id)
        {
            if (!_repairRequestDAO.RepairRequestExist(id))
            {
                return BadRequest();
            }

            var repairRequest = await _repairRequestDAO.(id);
            if (repairRequest == null)
            {
                return NotFound();
            }

            return NoContent();
        }*/

        private bool RepairRequestExists(Guid id)
        {
            return _repairRequestDAO.RepairRequestExist(id);
        }
    }
}
