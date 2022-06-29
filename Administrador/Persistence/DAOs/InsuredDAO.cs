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
    public class InsuredDAO : IInsuredDAO
    {
        private readonly IAdministradorDbContext _context;

        public InsuredDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<Insured?> GetInsured(Guid id)
        {
            return await _context.Insureds
                .Where(b => (b.IsActive == true) && (b.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<Insured?> GetInsured(string name)
        {
            return await _context.Insureds
                .Where(b => (b.IsActive == true) && (b.FirstName == name))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Insured>> GetInsureds()
        {
            return await _context.Insureds.Where(b => b.IsActive == true).ToListAsync();
        }

        public async Task<Insured> CreateInsured(InsuredDTO insuredDTO)
        {
            var insured = new Insured
            {
                Id = Guid.NewGuid(),
                InsuredTypeIdentification = insuredDTO.InsuredTypeIdentification,
                Identification = insuredDTO.Identification,
                FirstName = insuredDTO.FirstName,
                LastName = insuredDTO.LastName,
                Email = insuredDTO.Email,
                Phone = insuredDTO.Phone,
                Birthday = insuredDTO.Birthday,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Insureds.Add(insured);
            await _context.SaveChangesAsync();
            return insured;
        }

        public async Task<Insured> UpdateInsured(Insured insured, InsuredDTO insuredDTO)
        {
            insured.InsuredTypeIdentification = insuredDTO.InsuredTypeIdentification;
            insured.Identification = insuredDTO.Identification;
            insured.FirstName = insuredDTO.FirstName;
            insured.LastName = insuredDTO.LastName;
            insured.Email = insuredDTO.Email;
            insured.Phone = insuredDTO.Phone;
            insured.Birthday = insuredDTO.Birthday;

            _context.Insureds.Update(insured);
            await _context.SaveChangesAsync();
            return insured;
        }

        public async Task<Insured> DeleteInsured(Insured insured)
        {
            insured.IsActive = false;
            _context.Insureds.Update(insured);
            await _context.SaveChangesAsync();
            return insured;
        }
    }
}
