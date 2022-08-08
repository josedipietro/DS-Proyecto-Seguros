using Microsoft.EntityFrameworkCore;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.Mappers;
//using Base.Exceptions;
using Administrador.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrador.Persistence.DAOs
{
    public class BrandDAO : IBrandDAO
    {
        private readonly IAdministradorDbContext _context;

        public BrandDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public bool BrandExists(string id)
        {
            return (_context.Brands?.Any(e => e.Code == id)).GetValueOrDefault();
        }

        public async Task<Brand> Create(BrandDTO brand)
        {
            var newBrand = BrandMapper.MapDTOtoEntity(brand);
            _context.Brands.Add(newBrand);
            await _context.SaveChangesAsync();
            return newBrand;
        }

        // Listar las marcas
        public async Task<List<Brand>> List()
        {
            return await _context.Brands.ToListAsync();
        }

        // Obtener una marca por su código
        public async Task<Brand?> Get(string id)
        {
            return await _context.Brands.FindAsync(id);
        }

        // Actualizar una marca por su código
        public async Task<Brand> Update(Brand brand, UpdateBrandDTO brandDTO)
        {
            brand.Name = brandDTO.Name;
            brand.Description = brandDTO.Description;
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return brand;
        }
    }
}
