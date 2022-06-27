using Microsoft.EntityFrameworkCore;
using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;
using Base.Exceptions;
using Administrador.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrador.Persistence.DAOs
{
    public class BrandDAO
    {
        private readonly AdministradorDbContext _context;

        public BrandDAO(AdministradorDbContext context)
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
    }
}
