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

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleDAO _vehicleDAO;

        public VehiclesController(IVehicleDAO vehicleDAO)
        {
            _vehicleDAO = vehicleDAO;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles(
            EnumBodyworkType? bodyworkType,
            string? brandCode,
            Guid? InsuredId
        )
        {
            return await _vehicleDAO.GetVehicles(bodyworkType, brandCode, InsuredId);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(Guid id)
        {
            var vehicle = await _vehicleDAO.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> PutVehicle(Guid id, VehicleDTO vehicleDTO)
        {
            var vehicle = await _vehicleDAO.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            try
            {
                return await _vehicleDAO.UpdateVehicle(vehicle, vehicleDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(VehicleDTO vehicleDTO)
        {
            try
            {
                var vehicle = await _vehicleDAO.CreateVehicle(vehicleDTO);
                return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var vehicle = await _vehicleDAO.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            try
            {
                await _vehicleDAO.DeleteVehicle(vehicle);
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return NoContent();
        }
    }
}
