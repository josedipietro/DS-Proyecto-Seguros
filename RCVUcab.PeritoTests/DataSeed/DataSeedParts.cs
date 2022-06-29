using MockQueryable.Moq;
using Moq;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCVUcab.PeritoTests.DataSeed
{
    public class DataSeedParts
    {
        private readonly List<Part> parts;
        public DataSeedParts(Mock<IPeritoDbContext> mockContext)
        {
            parts = new List<Part>
            {
                new Part
                {
                    Id = new Guid("38f401c9-82a2-46bf-12aa-05ff65bb2c86"),
                    Name = "Parachoque Delantero",
                    Quantity = 1,
                    RepairRequestId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    Status = EnumPartStatus.PendingReview,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Part
                {
                    Id = new Guid(),
                    Name = "Retrovisor izquierdo",
                    Quantity = 1,
                    RepairRequestId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    Status = EnumPartStatus.PendingReview,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                },
                new Part
                {
                    Id = new Guid(),
                    Name = "Retrovisor derecho",
                    Quantity = 1,
                    RepairRequestId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    Status = EnumPartStatus.PendingReview,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,},
            };

            mockContext.Setup(c => c.Parts).Returns(parts.AsQueryable().BuildMockDbSet().Object);
        }

        public void SetupCreate(Mock<IPeritoDbContext> mockContext, Part part)
        {
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<Part>())).Callback(() => parts.Add(part));
        }

        public void SetupUpdate(Mock<IPeritoDbContext> mockContext, Part part)
        {
            var partOld = parts.Find(i => i.Id == part.Id);
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<Part>())).Callback(() => partOld = part);
        }
    }
}
