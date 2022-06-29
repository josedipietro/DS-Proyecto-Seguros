using Moq;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.DAOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;
using RCVUcab.PeritoTests.DataSeed;

namespace RCVUcab.PeritoTests.UnitTests.DAOs
{
    public class RepairRequestDAOTest
    {
        private readonly RepairRequestDAO _dao;
        private readonly DataSeedRepairRequest data;
        private readonly Mock<IPeritoDbContext> _contextMock;

        public RepairRequestDAOTest()
        {
            _contextMock = new Mock<IPeritoDbContext>();

            _dao = new RepairRequestDAO(_contextMock.Object);
            data = new DataSeedRepairRequest(_contextMock);
        }

        [TestMethod]
        public async Task GetRepairRequests_ShouldReturnsSome()
        {
            var result = await _dao.GetRepairRequests();
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void RepairRequestExist_ShouldReturnsTrue()
        {
            var id = new Guid("38f401c9-12aa-4a47-82a2-a725a6de92c6");
            var result = _dao.RepairRequestExists(id);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetRepairRequest_ShouldReturnsIncident()
        {
            var id = new Guid("38f401c9-12aa-4a47-82a2-a725a6de92c6");
            var result = await _dao.GetRepairRequest(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateRepairRequest_ShouldAddIncident()
        {
            var result = await _dao.GetRepairRequests();
            var prev = result.Count;

            data.SetupCreate(_contextMock, new RepairRequest
            {
                Id = new Guid("38f401c9-448b-24aq-5d9q-05ff65bb2c86"),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            });

            await _dao.CreateRepairRequest(new RepairRequestDTO
            {
                Status = EnumRepairStatus.Peding
            });

            result = await _dao.GetRepairRequests();

            Assert.IsTrue(result.Count > prev);
        }
    }
}
