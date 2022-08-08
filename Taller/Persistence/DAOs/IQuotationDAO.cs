using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Entities;

namespace Taller.Persistence.DAOs
{
    public interface IQuotationDAO
    {
        public bool QuotationExist(Guid id);
        public Task<Quotation?> GetQuotation(Guid id);
        public Task<List<Quotation>> GetQuotations();
        public Task<Quotation> CreateQuotation(QuotationDTO participationDTO);
        public Task<Quotation?> UpdateQuotation(Guid id, QuotationDTO quotationDTO);
    }
}
