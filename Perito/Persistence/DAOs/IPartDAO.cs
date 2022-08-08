using Microsoft.EntityFrameworkCore;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace Perito.Persistence.DAOs
{
    public interface IPartDAO
    {
        Task<Part?> GetPart(Guid id);

        Task<List<Part>> GetParts();
        Task<Part> CreatePart(PartDTO partDTO);
        bool PartExists(Guid id);
    }
}
