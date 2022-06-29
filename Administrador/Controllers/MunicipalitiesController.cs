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
    public class MunicipalitiesController : ControllerBase
    {
        private readonly IMunicipalityDAO _municipalityDAO;

        public MunicipalitiesController(IMunicipalityDAO municipalityDAO)
        {
            _municipalityDAO = municipalityDAO;
        }

        // GET: api/Municipalities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipalities(int? stateId)
        {
            return await _municipalityDAO.GetMunicipalities(stateId);
        }

        // GET: api/Municipalities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Municipality>> GetMunicipality(int id)
        {
            var municipality = await _municipalityDAO.GetMunicipality(id);

            if (municipality == null)
            {
                return NotFound();
            }

            return municipality;
        }
    }
}
