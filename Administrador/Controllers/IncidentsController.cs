using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Database;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.DAOs;
using Base.Services.RabbitMQ;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentDAO _incidentDAO;
        private readonly AmqpService _amqpService;

        public IncidentsController(IIncidentDAO incidentDAO, AmqpService amqpService)
        {
            _incidentDAO = incidentDAO;
            _amqpService = amqpService ?? throw new ArgumentNullException(nameof(amqpService));
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidents(
            int? parishId,
            EnumIncidentStatus? status,
            Guid? policyId,
            Guid? thirdPolicyId
        )
        {
            return await _incidentDAO.GetIncidents(parishId, status, policyId, thirdPolicyId);
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(Guid id)
        {
            var incident = await _incidentDAO.GetIncident(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incident>> PostIncident(IncidentDTO incidentDTO)
        {
            try
            {
                var incident = await _incidentDAO.CreateIncident(incidentDTO);
                await _amqpService.SendMessageAsync(incident, "perito-incidente-create");
                return CreatedAtAction("GetIncident", new { id = incident.Id }, incident);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
