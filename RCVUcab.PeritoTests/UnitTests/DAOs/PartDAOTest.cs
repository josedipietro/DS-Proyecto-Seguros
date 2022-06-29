using Moq;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.DAOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;
using RCVUcab.PeritoTests.DataSeed;

namespace RCVUcab.PeritoTests.UnitTests.DAOs
{
    public class PartDAOTest
    {
        private readonly PartDAO _dao;
        private readonly DataSeedParts data;
        private readonly Mock<IPeritoDbContext> _contextMock;

        public PartDAOTest()
        {
            _contextMock = new Mock<IPeritoDbContext>();

            _dao = new PartDAO(_contextMock.Object);
            data = new DataSeedParts(_contextMock);
        }

        [TestMethod]
        public async Task GetParts_ShouldReturnsSome()
        {
            var result = await _dao.GetParts();
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void PartExist_ShouldReturnsTrue()
        {
            var id = new Guid("38f401c9-82a2-46bf-12aa-05ff65bb2c86");
            var result = _dao.PartExists(id);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetPart_ShouldReturnsIncident()
        {
            var id = new Guid("38f401c9-82a2-46bf-12aa-05ff65bb2c86");
            var result = await _dao.GetPart(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateRepairRequest_ShouldAddIncident()
        {
            var result = await _dao.GetParts();
            var prev = result.Count;

            data.SetupCreate(_contextMock, new Part
            {
                Id = new Guid("38f401c9-448b-24aq-5d9q-05ff65bb2c86"),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            });

            await _dao.CreatePart(new PartDTO
            {
                Status = EnumPartStatus.PendingReview
            });

            result = await _dao.GetParts();

            Assert.IsTrue(result.Count > prev);
        }
    }
}
