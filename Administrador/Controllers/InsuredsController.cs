using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.DAOs;
using Administrador.BussinesLogic.DTOs;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredsController : ControllerBase
    {
        private readonly IInsuredDAO _insuredDAO;

        public InsuredsController(IInsuredDAO insuredDAO)
        {
            _insuredDAO = insuredDAO;
        }

        // GET: api/Insureds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insured>>> GetInsureds()
        {
            return await _insuredDAO.GetInsureds();
        }

        // GET: api/Insureds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insured>> GetInsured(Guid id)
        {
            var insured = await _insuredDAO.GetInsured(id);

            if (insured == null)
            {
                return NotFound();
            }
            return insured;
        }

        // PUT: api/Insureds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Insured>> PutInsured(Guid id, InsuredDTO insured)
        {
            var insuredToUpdate = await _insuredDAO.GetInsured(id);

            if (insuredToUpdate == null)
            {
                return NotFound();
            }
            try
            {
                return await _insuredDAO.UpdateInsured(insuredToUpdate, insured);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Insureds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insured>> PostInsured(InsuredDTO insuredDTO)
        {
            var insured = await _insuredDAO.CreateInsured(insuredDTO);

            return CreatedAtAction("GetInsured", new { id = insured.Id }, insured);
        }

        // DELETE: api/Insureds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsured(Guid id)
        {
            var insured = await _insuredDAO.GetInsured(id);

            if (insured == null)
            {
                return NotFound();
            }
            try
            {
                insured = await _insuredDAO.DeleteInsured(insured);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
    }
}
