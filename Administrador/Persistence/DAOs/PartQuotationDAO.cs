using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;
using Administrador.BussinesLogic.DTOs;

namespace Administrador.Persistence.DAOs
{
    public class PartQuotationDAO : IPartQuotationDAO
    {
        private readonly IAdministradorDbContext _context;

        public PartQuotationDAO(IAdministradorDbContext context)
        {
            _context = context;
        }

        public async Task<PartQuotation?> GetPartQuotation(Guid id)
        {
            return await _context.PartQuotations.FindAsync(id);
        }

        public async Task<List<PartQuotation>> GetPartQuotations(Guid? partId)
        {
            return await _context.PartQuotations
                .Where(e => (partId.HasValue ? e.PartId == partId : true))
                .ToListAsync();
        }

        public async Task<PartQuotation> UpdateStatus(
            PartQuotation partQuotation,
            EnumPartQuotationStatus status
        )
        {
            partQuotation.Status = status;
            _context.PartQuotations.Update(partQuotation);
            await _context.SaveChangesAsync();
            return partQuotation;
        }

        public async Task<PartQuotation> CreatePartQuotation(PartQuotationDTO partQuotationDTO)
        {
            var partQuotation = new PartQuotation
            {
                Id = partQuotationDTO.Id,
                Quantity = partQuotationDTO.Quantity,
                Original = partQuotationDTO.Original,
                UnitPrice = partQuotationDTO.UnitPrice,
                discount_percentage = partQuotationDTO.discount_percentage,
                Status = partQuotationDTO.Status,
                DeliveryTime = partQuotationDTO.DeliveryTime,
                PartId = partQuotationDTO.PartId,
                EnterpriseId = partQuotationDTO.EnterpriseId,
            };

            _context.PartQuotations.Add(partQuotation);
            await _context.SaveChangesAsync();

            return partQuotation;
        }
    }
}
