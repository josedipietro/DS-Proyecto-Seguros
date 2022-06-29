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
using Base.Services.RabbitMQ;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IPartDAO _partDAO;

        public PartsController(IPartDAO partDAO)
        {
            _partDAO = partDAO;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts(Guid? repairRequestId)
        {
            return await _partDAO.GetParts(repairRequestId);
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(Guid id)
        {
            var part = await _partDAO.GetPart(id);

            if (part == null)
            {
                return NotFound();
            }

            return part;
        }
    }
}
