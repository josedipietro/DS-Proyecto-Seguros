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
    public class PartQuotationsController : ControllerBase
    {
        private readonly IPartQuotationDAO _partQuotationDAO;
        private readonly IPartDAO _partDAO;
        private readonly AmqpService _amqpService;

        public PartQuotationsController(
            IPartQuotationDAO partQuotationDAO,
            IPartDAO partDAO,
            AmqpService amqpService
        )
        {
            _partQuotationDAO = partQuotationDAO;
            _partDAO = partDAO;
            _amqpService = amqpService ?? throw new ArgumentNullException(nameof(amqpService));
        }

        // GET: api/PartQuotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartQuotation>>> GetPartQuotations(Guid? partId)
        {
            return await _partQuotationDAO.GetPartQuotations(partId);
        }

        // GET: api/PartQuotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartQuotation>> GetPartQuotation(Guid id)
        {
            var partQuotation = await _partQuotationDAO.GetPartQuotation(id);

            if (partQuotation == null)
            {
                return NotFound();
            }

            return partQuotation;
        }

        // POST: api/PartQuotations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<PartQuotation>> PostPartQuotation(Guid id)
        {
            // se pasa el status a con_orden_de_compra
            var partQuotation = await _partQuotationDAO.GetPartQuotation(id);
            if (partQuotation == null)
            {
                return NotFound();
            }
            try
            {
                partQuotation = await _partQuotationDAO.UpdateStatus(
                    partQuotation,
                    EnumPartQuotationStatus.BuyOrder
                );
                await _amqpService.SendMessageAsync(
                    partQuotation,
                    "proveedor-partquotation-update"
                );

                // update part status
                var part = await _partDAO.GetPart(partQuotation.PartId);
                if (part != null)
                {
                    part = await _partDAO.UpdateStatus(part, EnumPartStatus.PendingSend);
                    await _amqpService.SendMessageAsync(part, "proveedor-part-update");
                }
                return Ok(partQuotation);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
