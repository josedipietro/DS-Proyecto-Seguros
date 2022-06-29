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
    public class EnterprisesController : ControllerBase
    {
        private readonly IEnterpriseDAO _enterpriseDAO;
        private readonly AmqpService _amqpService;

        public EnterprisesController(IEnterpriseDAO enterpriseDAO, AmqpService amqpService)
        {
            _enterpriseDAO = enterpriseDAO;
            _amqpService = amqpService ?? throw new ArgumentNullException(nameof(amqpService));
        }

        // GET: api/Enterprises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enterprise>>> GetEnterprises(
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        )
        {
            return await _enterpriseDAO.GetEnterprises(parishId, brands, EnterpriseType);
        }

        // GET: api/Enterprises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enterprise>> GetEnterprise(Guid id)
        {
            var enterprise = await _enterpriseDAO.GetEnterprise(id);

            if (enterprise == null)
            {
                return NotFound();
            }
            return enterprise;
        }

        // PUT: api/Enterprises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Enterprise>> PutEnterprise(
            Guid id,
            EnterpriseUpdateDTO enterprise
        )
        {
            var enterpriseToUpdate = await _enterpriseDAO.GetEnterprise(id);

            if (enterpriseToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                enterpriseToUpdate = await _enterpriseDAO.UpdateEnterprise(
                    enterpriseToUpdate,
                    enterprise
                );
                switch (enterpriseToUpdate.EnterpriseType)
                {
                    case EnumEnterpriseType.Workshop:
                        await _amqpService.SendMessageAsync(
                            enterpriseToUpdate,
                            "workshop-enterprise-update"
                        );
                        break;
                    case EnumEnterpriseType.Supplier:
                        await _amqpService.SendMessageAsync(
                            enterpriseToUpdate,
                            "supplier-enterprise-update"
                        );
                        break;
                }
                return enterpriseToUpdate;
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
            var enterprise = await _enterpriseDAO.CreateEnterprise(enterpriseDTO);

            switch (enterprise.EnterpriseType)
            {
                case EnumEnterpriseType.Workshop:
                    await _amqpService.SendMessageAsync(enterprise, "workshop-enterprise-create");
                    break;
                case EnumEnterpriseType.Supplier:
                    await _amqpService.SendMessageAsync(enterprise, "supplier-enterprise-create");
                    break;
            }

            return CreatedAtAction("GetEnterprise", new { id = enterprise.Id }, enterprise);
        }

        // DELETE: api/Enterprises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise(Guid id)
        {
            var enterpriseToUpdate = await _enterpriseDAO.GetEnterprise(id);

            if (enterpriseToUpdate == null)
            {
                return NotFound();
            }
            try
            {
                enterpriseToUpdate = await _enterpriseDAO.DeleteEnterprise(enterpriseToUpdate);
                switch (enterpriseToUpdate.EnterpriseType)
                {
                    case EnumEnterpriseType.Workshop:
                        await _amqpService.SendMessageAsync(
                            enterpriseToUpdate,
                            "workshop-enterprise-update"
                        );
                        break;
                    case EnumEnterpriseType.Supplier:
                        await _amqpService.SendMessageAsync(
                            enterpriseToUpdate,
                            "supplier-enterprise-update"
                        );
                        break;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
    }
}
