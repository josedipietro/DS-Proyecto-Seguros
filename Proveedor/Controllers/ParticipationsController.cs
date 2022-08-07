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
    public class ParticipationsController : ControllerBase
    {
        private readonly ProveedorDbContext _context;
        private readonly ParticipationDAO _participationDAO;

        public ParticipationsController(ProveedorDbContext context)
        {
            _context = context;
            _participationDAO = new ParticipationDAO(context);
        }

        // GET: api/Participations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participation>>> GetParticipations()
        {
          if (_context.Participations == null)
          {
              return NotFound();
          }
            return await _participationDAO.GetParticipations();
        }

        // GET: api/Participations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participation>> GetParticipation(Guid id)
        {
          if (_context.Participations == null)
          {
              return NotFound();
          }
            var participation = await _participationDAO.GetParticipation(id);

            if (participation == null)
            {
                return NotFound();
            }

            return participation;
        }

        // PUT: api/Participations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipation(Guid id, ParticipationDTO participationDTO)
        {
            if (!_participationDAO.ParticipationExists(id))
            {
                return NotFound();
            } 
                var participation = await _participationDAO.UpdateParticipation(id, participationDTO);

            return participation == null ? NotFound() : Ok(participation);
        }

        // POST: api/Participations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participation>> PostParticipation(ParticipationDTO participationDTO)
        {
          if (_context.Participations == null)
          {
              return Problem("Entity set 'ProveedorDbContext.Participations'  is null.");
          }
            var participation = await _participationDAO.CreateParticipation(participationDTO);

            return CreatedAtAction("GetParticipation", new { id = participation.Id }, participation);
        }

        // DELETE: api/Participations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipation(Guid id)
        {
            if (_context.Participations == null)
            {
                return NotFound();
            }
            var participation = await _context.Participations.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }

            _context.Participations.Remove(participation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipationExists(Guid id)
        {
            return _participationDAO.ParticipationExists(id);
        }
    }
}
