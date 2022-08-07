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
using Administrador.BussinesLogic.Commands.Brand;
using Base.Exceptions;
using Base.Services.RabbitMQ;

namespace Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandDAO _brandDAO;
        private readonly IBrandCommandFactory _brandCommandFactory;

        public BrandsController(IBrandDAO brandDAO, IBrandCommandFactory brandCommandFactory)
        {
            _brandDAO = brandDAO;
            _brandCommandFactory = brandCommandFactory;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<List<BrandDTO>>> GetBrands()
        {
            var brandsCommand = await _brandCommandFactory.GetBrands();
            brandsCommand.Execute();
            return await brandsCommand.GetResult();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetBrand(string id)
        {
            var brand = await _brandDAO.Get(id);

            if (brand == null)
            {
                return NotFound();
            }

            return new BrandDTO
            {
                Code = brand.Code,
                Name = brand.Name,
                Description = brand.Description
            };
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<BrandDTO>> PutBrand(string id, UpdateBrandDTO brand)
        {
            // Obtener la Marca
            var brandToUpdate = await _brandDAO.Get(id);

            if (brandToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar los datos

            try
            {
                return await _brandDAO.Update(brandToUpdate, brand);
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
            try
            {
                await _brandDAO.Create(brand);
            }
            catch (DbUpdateException)
            {
                if (_brandDAO.BrandExists(brand.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBrand", new { id = brand.Code }, brand);
        }
    }
}
