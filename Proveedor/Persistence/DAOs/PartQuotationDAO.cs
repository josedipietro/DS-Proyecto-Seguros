using Microsoft.EntityFrameworkCore;
using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Database;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public class PartQuotationDAO
    {
        private readonly ProveedorDbContext _context;

        public PartQuotationDAO(ProveedorDbContext proveedorDbContext)
        {
            _context = proveedorDbContext;
        }

        public bool PartQuotationExist(Guid id)
        {
            return (_context.PartQuotations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<PartQuotation?> GetPartQuotation(Guid id)
        {
            return await _context.PartQuotations
                .FindAsync(id);
        }

        public async Task<List<PartQuotation>> GetPartQuotations()
        {
            return await _context.PartQuotations.ToListAsync();
        }

        public async Task<PartQuotation> CreateParticipation(PartQuotationDTO participationDTO)
        {
            var partQ = new PartQuotation
            {
                DeliveryEndDate = participationDTO.DeliveryEndDate,
                DeliveryStartDate = participationDTO.DeliveryStartDate,
                DeliveryTime = participationDTO.DeliveryTime,
                discount_percentage = participationDTO.discount_percentage,
                Original = participationDTO.Original,
                Part = participationDTO.Part,
                PartId = participationDTO.PartId,
                Quantity = participationDTO.Quantity,
                UnitPrice = participationDTO.UnitPrice,
                Status = participationDTO.Status,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            _context.PartQuotations.Add(partQ);
            await _context.SaveChangesAsync();

            return partQ;
        }

        public async Task<PartQuotation?> UpdatePartQuotation(Guid id, PartQuotationDTO partQuotationDTO)
        {
            var partQ = await _context.PartQuotations.FindAsync(id);
            if (partQ == null) return null;

            partQ.DeliveryEndDate = partQuotationDTO.DeliveryEndDate;
            partQ.DeliveryStartDate = partQuotationDTO.DeliveryStartDate;
            partQ.DeliveryTime = partQuotationDTO.DeliveryTime;
            partQ.discount_percentage = partQuotationDTO.discount_percentage;
            partQ.Original = partQuotationDTO.Original;
            partQ.Part = partQuotationDTO.Part;
            partQ.PartId = partQuotationDTO.PartId;
            partQ.Quantity = partQuotationDTO.Quantity;
            partQ.UnitPrice = partQuotationDTO.UnitPrice;
            partQ.Status = partQuotationDTO.Status;
            partQ.UpdatedAt = DateTime.Now;

            _context.PartQuotations.Update(partQ);
            await _context.SaveChangesAsync();

            return partQ;
        }
    }
}
