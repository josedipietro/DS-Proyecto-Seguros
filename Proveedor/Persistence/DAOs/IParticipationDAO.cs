using Proveedor.BussinesLogic.DTOs;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.DAOs
{
    public interface IParticipationDAO
    {
        Task<Participation?> GetParticipation(Guid id);
        Task<List<Participation>> GetParticipations();

        Task<Participation> CreateParticipation(ParticipationDTO participationDTO);

        Task<Participation?> UpdateParticipation(Guid id, ParticipationDTO participationDTO);
    }
}