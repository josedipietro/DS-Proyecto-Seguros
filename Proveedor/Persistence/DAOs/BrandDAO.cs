﻿using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Entities;
using Proveedor.Persistence.Database;
using Proveedor.BussinesLogic.DTOs;

namespace Proveedor.Persistence.DAOs
{
    public class BrandDAO
    {
        private readonly ProveedorDbContext _context;

        public BrandDAO(ProveedorDbContext context)
        {
            _context = context;
        }

        public bool BrandExists(string id)
        {
            return (_context.Brands?.Any(e => e.Code == id)).GetValueOrDefault();
        }

        public async Task<BrandDTO> Create(BrandDTO brand)
        {
            var newBrand = new Brand
            {
                Code = brand.Code,
                Name = brand.Name,
                Description = brand.Description
            };
            _context.Brands.Add(newBrand);
            await _context.SaveChangesAsync();
            return brand;
        }

        // Listar las marcas
        public async Task<List<BrandDTO>> List()
        {
            var brands = await _context.Brands.ToListAsync();
            var brandsDTO = new List<BrandDTO>();
            foreach (var brand in brands)
            {
                brandsDTO.Add(
                    new BrandDTO
                    {
                        Code = brand.Code,
                        Name = brand.Name,
                        Description = brand.Description
                    }
                );
            }
            return brandsDTO;
        }

        // Obtener una marca por su código
        public async Task<Brand?> Get(string id)
        {
            return await _context.Brands.FindAsync(id);
        }

        // Actualizar una marca por su código
        public async Task<BrandDTO> Update(Brand brand, UpdateBrandDTO brandDTO)
        {
            brand.Name = brandDTO.Name;
            brand.Description = brandDTO.Description;
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return new BrandDTO
            {
                Code = brand.Code,
                Name = brand.Name,
                Description = brand.Description
            };
        }
    }
}
