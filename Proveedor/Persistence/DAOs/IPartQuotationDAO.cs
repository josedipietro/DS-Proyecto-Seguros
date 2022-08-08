using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public interface IPartQuotationDAO
    {
        Task<PartQuotation?> GetPartQuotation(Guid id);
        Task<List<PartQuotation>> GetPartQuotations();
        Task<PartQuotation> CreateParticipation(PartQuotationDTO participationDTO);
        Task<PartQuotation?> UpdatePartQuotation(Guid id, PartQuotationDTO partQuotationDTO);
    }
}
