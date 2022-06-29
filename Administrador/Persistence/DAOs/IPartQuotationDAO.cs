using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IPartQuotationDAO
    {
        Task<PartQuotation?> GetPartQuotation(Guid id);
        Task<List<PartQuotation>> GetPartQuotations(Guid? partId);
        Task<PartQuotation> UpdateStatus(
            PartQuotation partQuotation,
            EnumPartQuotationStatus status
        );

        Task<PartQuotation> CreatePartQuotation(PartQuotationDTO partQuotationDTO);
    }
}
