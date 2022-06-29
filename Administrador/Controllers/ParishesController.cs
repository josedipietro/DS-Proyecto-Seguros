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

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParishesController : ControllerBase
    {
        private readonly IParishDAO _parishDAO;

        public ParishesController(IParishDAO parishDAO)
        {
            _parishDAO = parishDAO;
        }

        // GET: api/Parishes
        // Query: ?municipalityId=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parish>>> GetParishes(int? municipalityId)
        {
            return await _parishDAO.GetParishes(municipalityId);
        }

        // GET: api/Parishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parish>> GetParish(int id)
        {
            var parish = await _parishDAO.GetParish(id);

            if (parish == null)
            {
                return NotFound();
            }

            return parish;
        }
    }
}
