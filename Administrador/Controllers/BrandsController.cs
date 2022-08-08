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
using Administrador.BussinesLogic.Commands.Brands;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandCommandFactory _brandCommandFactory;

        public BrandsController(IBrandCommandFactory brandCommandFactory)
        {
            _brandCommandFactory = brandCommandFactory;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<List<BrandDTO>>> GetBrands()
        {
            var Command = await _brandCommandFactory.GetBrands();
            await Command.Execute();
            return await Command.GetResult();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetBrand(string id)
        {
            var Command = await _brandCommandFactory.GetBrand(id);
            await Command.Execute();
            var result = await Command.GetResult();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<BrandDTO>> PutBrand(string id, UpdateBrandDTO brand)
        {
            // Obtener la Marca
            var Command = await _brandCommandFactory.GetAndUpdateBrand(id, brand);

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

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(BrandDTO brand)
        {
            var Command = await _brandCommandFactory.InsertBrand(brand);

            try
            {
                await Command.Execute();
                var result = await Command.GetResult();
                return CreatedAtAction("GetBrand", new { id = result.Code }, result);
            }
            catch (DbUpdateException)
            {
                var GetCommand = await _brandCommandFactory.GetBrand(brand.Code);
                await GetCommand.Execute();
                var result = await Command.GetResult();
                if (result != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
