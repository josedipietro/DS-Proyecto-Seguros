using Taller.BussinesLogic.DTOs;
using Taller.Persistence.Entities;

namespace Taller.Persistence.DAOs
{
    public interface IPartDAO
    {
        public Task<Part?> GetPart(Guid id);
        public Task<List<Part>> GetParts();

        public Task<Part> CreatePart(PartDTO partDTO);

        public bool PartExists(Guid id);
    }
}
