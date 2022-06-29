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

        public bool QuotationExist(Guid id)
        {
            return (_context.Quotations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
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

        public async Task<Quotation?> UpdateQuotation(Guid id, QuotationDTO quotationDTO)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation == null) return null;

            quotation.QuantityToRepair = quotationDTO.QuantityToRepair;
            quotation.Total = quotationDTO.Total;
            quotation.NumberOfDays = quotationDTO.NumberOfDays;
            quotation.StartDate = quotationDTO.StartDate;
            quotation.EndDate = quotationDTO.EndDate;
            quotation.RepairRequest = quotationDTO.RepairRequest;
            quotation.UpdatedAt = DateTime.Now;

            _context.Quotations.Update(quotation);
            await _context.SaveChangesAsync();

            return quotation;
        }

        /*public async Task<Quotation?> UpdateRepairRequest(Guid id, QuotationDTO quotationDTO)
        {
            var repairRequest = await _context.RepairRequests.FindAsync(id);
            if (repairRequest == null) return null;

            repairRequest.VehicleId = repairRequestDTO.VehicleId;
            repairRequest.PolicyId = repairRequestDTO.PolicyId;
            repairRequest.IncidentId = repairRequestDTO.IncidentId;
            repairRequest.QuotationId = repairRequestDTO.QuotationId;
            repairRequest.Quotation = repairRequestDTO.Quotation;
            repairRequest.Parts = repairRequestDTO.Parts;

            _context.RepairRequests.Update(repairRequest);
            await _context.SaveChangesAsync();

            return repairRequest;
        }*/
    }
}