using Microsoft.EntityFrameworkCore;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Database;
using Taller.Persistence.Entities;

namespace Taller.Persistence.DAOs
{
    public class QuotationDAO
    {
        private readonly TallerDbContext _context;

        public QuotationDAO(TallerDbContext proveedorDbContext)
        {
            _context = proveedorDbContext;
        }

        /*public bool QuotationExist(Guid id)
        {
            return (_context.QuotationDAO?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
        public async Task<Quotation?> GetQuotation(Guid id)
        {
            return await _context.Quotations
                .FindAsync(id);
        }

        public async Task<List<Quotation>> GetQuotations()
        {
            return await _context.Quotations.ToListAsync();
        }

        public async Task<Quotation> CreateQuotation(QuotationDTO participationDTO)
        {
            var partQ = new Quotation
            {
                QuantityToRepair = participationDTO.QuantityToRepair,
                Total = participationDTO.Total,
                NumberOfDays = participationDTO.NumberOfDays,
                StartDate = participationDTO.StartDate,
                EndDate = participationDTO.EndDate,
                RepairRequest = participationDTO.RepairRequest,
                /*PartId = participationDTO.PartId,
                Quantity = participationDTO.Quantity,
                UnitPrice = participationDTO.UnitPrice,
                Status = participationDTO.Status,*/
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            _context.Quotations.Add(partQ);
            await _context.SaveChangesAsync();

            return partQ;
        }

        public async Task<Quotation?> Quotation(Guid id, QuotationDTO quotationDTO)
        {
            var partQ = await _context.Quotations.FindAsync(id);
            if (partQ == null) return null;

                partQ.QuantityToRepair = quotationDTO.QuantityToRepair;
                partQ.Total = quotationDTO.Total;
                partQ.NumberOfDays = quotationDTO.NumberOfDays;
                partQ.StartDate = quotationDTO.StartDate;
                partQ.EndDate = quotationDTO.EndDate;
                partQ.RepairRequest = quotationDTO.RepairRequest;
                partQ.UpdatedAt = DateTime.Now;

            _context.Quotations.Update(partQ);
            await _context.SaveChangesAsync();

            return partQ;
        }
    }
}