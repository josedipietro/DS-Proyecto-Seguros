using MockQueryable.Moq;
using Moq;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace RCVUcab.PeritoTests.DataSeed
{
    public class DataSeedRepairRequest
    {
        private readonly List<RepairRequest> repairRequests;
        public DataSeedRepairRequest(Mock<IPeritoDbContext> mockContext)
        {
            repairRequests = new List<RepairRequest>
            {
                new RepairRequest
                {
                    Id = new Guid("38f401c9-12aa-4a47-82a2-a725a6de92c6"),
                    IncidentId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    VehicleId = new Guid("3fbfe10c-4a47-4a47-b4de-4d6a2ef9181d"),
                    PolicyId = new Guid("38f401c9-4fe0-4a47-12aa-a725a6de92c6"),
                    Status = EnumRepairStatus.Peding,
                    Parts = new List<Part>(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,

                }
            };

            mockContext.Setup(c => c.RepairRequests).Returns(repairRequests.AsQueryable().BuildMockDbSet().Object);
        }
        public void SetupCreate(Mock<IPeritoDbContext> mockContext, RepairRequest repairRequest)
        {
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<RepairRequest>())).Callback(() => repairRequests.Add(repairRequest));
        }

        public void SetupUpdate(Mock<IPeritoDbContext> mockContext, RepairRequest repairRequest)
        {
            var repairRequestOld = repairRequests.Find(i => i.Id == repairRequest.Id);
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<RepairRequest>())).Callback(() => repairRequestOld = repairRequest);
        }

    }
}
