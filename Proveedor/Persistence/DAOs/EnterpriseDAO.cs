using Microsoft.EntityFrameworkCore;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;
using Proveedor.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrador.Persistence.DAOs
{
    public class EnterpriseDAO
    {
        private readonly ProveedorDbContext _context;

        public EnterpriseDAO(ProveedorDbContext context)
        {
            _context = context;
        }

        public async Task<Enterprise?> GetEnterprise(Guid id)
        {
            return await _context.Enterprises
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Enterprise>> GetEnterprises(
            List<string>? brands
        )
        {
            return await _context.Enterprises
                .Where(
                    e =>
                        (e.IsActive == true)
                        && (
                            brands != null || brands.Count > 0
                                ? brands.Any(b => e.Brands.Any(eb => eb.Code == b))
                                : true
                        )
                )
                .ToListAsync();
        }

        // Delete (Change IsActive to false)
        public async Task<Enterprise> DeleteEnterprise(Enterprise enterprise)
        {
            enterprise.IsActive = false;
            await _context.SaveChangesAsync();
            return enterprise;
        }

        // Create
        public async Task<Enterprise> CreateEnterprise(EnterpriseDTO enterpriseDTO)
        {
            var brands = _context.Brands.Where(b => enterpriseDTO.Brands.Contains(b.Code)).ToList();
            var users = _context.Users.Where(b => enterpriseDTO.Users.Contains(b.Id.ToString())).ToList();

            var enterprise = new Enterprise
            {
                Brands = brands,
                Users = users,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();

            return enterprise;
        }

        // Update
        public async Task<Enterprise> UpdateEnterprise(
            Enterprise enterprise,
            EnterpriseUpdateDTO enterpriseDTO
        )
        {
            var brands = _context.Brands.Where(b => enterpriseDTO.Brands.Contains(b.Code)).ToList();
            var users = _context.Users.Where(b => enterpriseDTO.Users.Contains(b.Id.ToString())).ToList();

            enterprise.Brands = brands;
            enterprise.Users = users;
            enterprise.UpdatedAt = DateTime.Now;
            _context.Enterprises.Update(enterprise);
            await _context.SaveChangesAsync();
            return enterprise;
        }
    }
}
