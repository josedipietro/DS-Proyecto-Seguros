using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Database;
using Administrador.Persistence.Entities;
using Administrador.Persistence.DAOs;
using Administrador.BussinesLogic.DTOs;
using Base.Exceptions;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyDAO _policyDAO;

        public PoliciesController(IPolicyDAO policyDAO)
        {
            _policyDAO = policyDAO;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies(
            Guid? vehicleId,
            EnumPolicyType? policyType
        )
        {
            return await _policyDAO.GetPolicies(vehicleId, policyType);
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(Guid id)
        {
            var policy = await _policyDAO.GetPolicy(id);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

        // POST: api/Policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(PolicyDTO policyDTO)
        {
            try
            {
                var policy = await _policyDAO.CreatePolicy(policyDTO);
                return CreatedAtAction("GetPolicy", new { id = policy.Id }, policy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(Guid id)
        {
            var policy = await _policyDAO.GetPolicy(id);
            if (policy == null)
            {
                return NotFound();
            }

            try
            {
                await _policyDAO.DeletePolicy(policy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}
