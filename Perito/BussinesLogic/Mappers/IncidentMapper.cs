using Perito.BussinesLogic.DTOs;
using Perito.Persistence.Entities;

namespace Perito.BussinesLogic.Mappers
{
    public class IncidentMapper
    {
        public static IncidentDTO MapEntityToDTO(Incident incident)
        {
            var repairRequests = new List<String>();
            foreach (var rr in incident.RepairRequests)
            {
                repairRequests.Add(rr.Id.ToString());
            };
            return new IncidentDTO
            {
                IsGuilty = incident.IsGuilty,
                RepairRequests = repairRequests,
                RevisionDescription = incident.RevisionDescription,
                Status = incident.Status,
                UserId = incident.UserId,
                User = incident.User
            };
        }

        public static Incident MapDTOtoEntity(IncidentDTO incident)
        {
            return new Incident
            {
                IsGuilty = incident.IsGuilty,
                RevisionDescription = incident.RevisionDescription,
                Status = incident.Status,
                UserId = incident.UserId,
                User = incident.User
            };
        }
    }
}
