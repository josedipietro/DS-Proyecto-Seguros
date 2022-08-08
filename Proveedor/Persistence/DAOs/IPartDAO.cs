using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public interface IPartDAO
    {
        Task<Part?> GetPart(Guid id);

        Task<Part> CreatePart(PartDTO partDTO);
    }
}
