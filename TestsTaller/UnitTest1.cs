

using Moq;
using Taller.Persistence.Entities;
using Taller.BussinesLogic.DTOs;
using Taller.Persistence.DAOs;
using Taller.Persistence.Database;

namespace TestsTaller
{
    [TestClass]
    public class TestsDAOs
    {
        Mock<TallerDbContext> tallerDBContextMock = new Mock<TallerDbContext>();

        [TestMethod]
        public async void RepairRequestShouldExist()
        {
            RepairRequestDTO repairRequestDTO = new RepairRequestDTO();
            RepairRequest repairRequest = new RepairRequest();
            tallerDBContextMock.Setup(t => t.RepairRequests.Add(repairRequest)).Returns(repairRequest);
            RepairRequestDAO repairRequestDAO = new RepairRequestDAO(tallerDBContextMock.Object);
            repairRequestDAO.CreateRepairRequest(repairRequestDTO);
        }
    }
}