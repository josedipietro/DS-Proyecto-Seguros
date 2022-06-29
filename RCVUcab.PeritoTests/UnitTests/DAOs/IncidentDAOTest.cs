
using Moq;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.DAOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;
using RCVUcab.PeritoTests.DataSeed;
using Assert = Xunit.Assert;

namespace RCVUcab.PeritoTests.UnitTests.DAOs
{
    [TestClass]
    public class IncidentDAOTest
    {
        private readonly IncidentDAO _dao;
        private readonly DataSeedIncident dataIncident;
        private readonly Mock<IPeritoDbContext> _contextMock;

        public IncidentDAOTest()
        {
            _contextMock = new Mock<IPeritoDbContext>();

            _dao = new IncidentDAO(_contextMock.Object);
            dataIncident = new DataSeedIncident(_contextMock);

        }

        [TestMethod]
        public async Task GetIncident_ShouldReturnsSome()
        {
            var result = await _dao.GetIncidents();
            Assert.True(result.Any());
        }

        [TestMethod]
        public void IncidentExist_ShouldReturnsTrue()
        {
            var id = new Guid();
            var result = _dao.IncidentExists(id);
            Assert.True(result);
        }

        [TestMethod]
        public async Task GetIncident_ShouldReturnsIncident()
        {
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var result = await _dao.GetIncident(id);
            Assert.NotNull(result);
        }

        [TestMethod]
        public async Task CreateIncident_ShouldAddIncident()
        {
            var result = await _dao.GetIncidents();
            var prev = result.Count;

            dataIncident.SetupCreateIncident(_contextMock, new Incident
            {
                Id = new Guid("38f401c9-448b-24aq-5d9q-05ff65bb2c86"),
                RepairRequests =  new List<RepairRequest>(),
                RevisionDescription = "",
                Status = EnumIncidentStatus.PendingProficient,
                User = new User(),
                UserId = new Guid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            });

            await _dao.CreateIncident(new IncidentDTO
            {
                RepairRequests = new List<string>(),
                RevisionDescription = "",
                Status = EnumIncidentStatus.PendingProficient,
                User =  new User(),
                UserId = new Guid(),
            });


        }
    }
}