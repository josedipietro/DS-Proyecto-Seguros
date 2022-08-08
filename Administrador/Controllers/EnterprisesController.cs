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
using Administrador.BussinesLogic.Commands.Enterprises;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private readonly IEnterpriseCommandFactory _enterpriseCommandFactory;

        public EnterprisesController(IEnterpriseCommandFactory enterpriseCommandFactory)
        {
            _enterpriseCommandFactory = enterpriseCommandFactory;
        }

        // GET: api/Enterprises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnterpriseDTO>>> GetEnterprises(
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        )
        {
            var Command = await _enterpriseCommandFactory.GetEnterprises(
                parishId,
                brands,
                EnterpriseType
            );
            await Command.Execute();
            return await Command.GetResult();
        }

        // GET: api/Enterprises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnterpriseDTO>> GetEnterprise(Guid id)
        {
            var Command = await _enterpriseCommandFactory.GetEnterprise(id);
            await Command.Execute();
            var result = await Command.GetResult();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT: api/Enterprises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<EnterpriseDTO>> PutEnterprise(
            Guid id,
            EnterpriseUpdateDTO enterprise
        )
        {
            // Obtener la Marca
            var Command = await _enterpriseCommandFactory.GetAndUpdateEnterprise(id, enterprise);

            // Actualizar los datos
            try
            {
                await Command.Execute();
                var result = await Command.GetResult();
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Enterprises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enterprise>> PostEnterprise(EnterpriseDTO enterpriseDTO)
        {
            var Command = await _enterpriseCommandFactory.InsertEnterprise(enterpriseDTO);

            try
            {
                await Command.Execute();
                var result = await Command.GetResult();
                return CreatedAtAction("GetEnterprise", new { id = result.Id }, result);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}
