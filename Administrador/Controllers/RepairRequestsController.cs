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
    public class RepairRequestsController : ControllerBase
    {
        private readonly IRepairRequestDAO _repairRequestDAO;

        public RepairRequestsController(IRepairRequestDAO repairRequestDAO)
        {
            _repairRequestDAO = repairRequestDAO;
        }

        // GET: api/RepairRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairRequest>>> GetRepairRequests(
            Guid? IncidentId
        )
        {
            return await _repairRequestDAO.GetRepairRequests(IncidentId);
        }

        // GET: api/RepairRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairRequest>> GetRepairRequest(Guid id)
        {
            var repairRequest = await _repairRequestDAO.GetRepairRequest(id);

            if (repairRequest == null)
            {
                return NotFound();
            }

            return repairRequest;
        }
    }
}
