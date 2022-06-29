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
    public class EnterpriseDAO : IEnterpriseDAO
    {
        private readonly IAdministradorDbContext _context;

        public EnterpriseDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<Enterprise?> GetEnterprise(Guid id)
        {
            return await _context.Enterprises
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<Enterprise?> GetEnterprise(string name)
        {
            return await _context.Enterprises
                .Where(b => (b.IsActive == true) && (b.Name == name))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Enterprise>> GetEnterprises(
            int? parishId,
            List<string>? brands,
            EnumEnterpriseType? EnterpriseType
        )
        {
            return await _context.Enterprises
                .Where(
                    e =>
                        (e.IsActive == true)
                        && (parishId.HasValue ? e.ParishId == parishId : true)
                        && (
                            brands != null || brands.Count > 0
                                ? brands.Any(b => e.Brands.Any(eb => eb.Code == b))
                                : true
                        )
                        && (EnterpriseType.HasValue ? e.EnterpriseType == EnterpriseType : true)
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

            var enterprise = new Enterprise
            {
                Id = Guid.NewGuid(),
                Rif = enterpriseDTO.Rif,
                Name = enterpriseDTO.Name,
                Email = enterpriseDTO.Email,
                Phone = enterpriseDTO.Phone,
                Address = enterpriseDTO.Address,
                EnterpriseType = enterpriseDTO.EnterpriseType,
                ParishId = enterpriseDTO.ParishId,
                Brands = brands,
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
            enterprise.Name = enterpriseDTO.Name;
            enterprise.Rif = enterpriseDTO.Rif;
            enterprise.Address = enterpriseDTO.Address;
            enterprise.Phone = enterpriseDTO.Phone;
            enterprise.Email = enterpriseDTO.Email;
            enterprise.ParishId = enterpriseDTO.ParishId;
            enterprise.Brands = brands;
            enterprise.UpdatedAt = DateTime.Now;
            _context.Enterprises.Update(enterprise);
            await _context.SaveChangesAsync();
            return enterprise;
        }
    }
}
