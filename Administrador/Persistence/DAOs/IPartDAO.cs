using Administrador.BussinesLogic.DTOs;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.DAOs
{
    public interface IPartDAO
    {
        Task<Part?> GetPart(Guid id);
        Task<List<Part>> GetParts(Guid? repairRequestId);

        Task<Part> UpdateStatus(Part part, EnumPartStatus status);
    }
}
