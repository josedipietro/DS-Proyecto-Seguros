using Moq;
using Perito.BussinesLogic.DTOs;
using Perito.Persistence.DAOs;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;
using RCVUcab.PeritoTests.DataSeed;

namespace RCVUcab.PeritoTests.UnitTests.DAOs
{
    public class UserDAOTest
    {
        private readonly UserDAO _dao;
        private readonly DataSeedUser data;
        private readonly Mock<IPeritoDbContext> _contextMock;

        public UserDAOTest()
        {
            _contextMock = new Mock<IPeritoDbContext>();

            _dao = new UserDAO(_contextMock.Object);
            data = new DataSeedUser(_contextMock);
        }

        [TestMethod]
        public async Task GetUsers_ShouldReturnsSome()
        {
            var result = await _dao.GetUsers(null);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetUser_ShouldReturnsIncident()
        {
            var id = new Guid("38f401c9-b4de-46bf-55ts-4d6a2ef9181d");
            var result = await _dao.GetUser(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateUser_ShouldAddIncident()
        {
            var result = await _dao.GetUsers(null);
            var prev = result.Count;

            data.SetupCreate(_contextMock, new User
            {
                Id = new Guid("38f401c9-448b-24aq-5d9q-05ff65bb2c86"),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            });

            await _dao.CreateUser(new UserDTO
            {
                Email = "test@test.com"
            });

            result = await _dao.GetUsers(null);

            Assert.IsTrue(result.Count > prev);
        }
    }
}
