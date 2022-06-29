using MockQueryable.Moq;
using Moq;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace RCVUcab.PeritoTests.DataSeed
{
    public class DataSeedIncident
    {
        private readonly List<Incident> incidents;

        public DataSeedIncident(Mock<IPeritoDbContext> mockContext)
        {
            incidents = new List<Incident>{ new Incident
            {
                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
                RevisionDescription = "Revision completa",
                Status = EnumIncidentStatus.PendingProficient,
                User = new User
                {
                    Id = new Guid("38f401c9-b4de-46bf-55ts-4d6a2ef9181d"),
                    Email = "usuario@example.com",
                    FirstName = "Usuario",
                    LastName = "Example",
                    LdapID = new Guid("38f401c9-b4de-46bf-55ts-4d6a2ef9181d").ToString(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                UserId = new Guid("38f401c9-12aa-f1d0-82a2-4d6a2ef9181d"),
            }};

            mockContext.Setup(c => c.Incidents).Returns(incidents.AsQueryable().BuildMockDbSet().Object);
        }

        public void SetupCreateIncident(Mock<IPeritoDbContext> mockContext, Incident incident)
        {
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<Incident>())).Callback(() => incidents.Add(incident));
        }

        public void SetupUpdateIncident(Mock<IPeritoDbContext> mockContext, Incident incident)
        {
            var incidentOld = incidents.Find(i => i.Id == incident.Id);
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<Incident>())).Callback(() => incidentOld = incident);
        }

    }
}
