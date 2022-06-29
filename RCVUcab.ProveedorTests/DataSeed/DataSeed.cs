using Proveedor.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCVUcab.ProveedorTests.DataSeed
{
    public static class DataSeed
    {
        public static void SetupDbContextData(this Mock<IProveedorDbContext> _mockContext)
        {
            var requests = new List<Incident>
            {
                new Incident
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
                    RepairRequests = new List<RepairRequest>
                    {
                        new RepairRequest
                        {
                            IncidentId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                            VehicleId = new Guid("3fbfe10c-4a47-4a47-b4de-4d6a2ef9181d"),
                            PolicyId = new Guid("38f401c9-4fe0-4a47-12aa-a725a6de92c6"),
                            Status = EnumRepairStatus.Peding,
                            Parts = new List<Part>
                            {
                                new Part
                                {
                                    Id = new Guid(),
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
                                },
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            IsActive = true,

                        }
                    }
                },
            };

            var requestsUser = requests.SelectMany<Incident, User>(q => new List<User> { q.User }).Concat(new List<User> { });
            var requestsRepairRequest = requests.SelectMany<Incident, RepairRequest>(q => q.RepairRequests).Concat(new List<RepairRequest> { });
            var requestsParts = requestsRepairRequest.SelectMany<RepairRequest, Part>(q => q.Parts).Concat(new List<Part> { });

            _mockContext.Setup(c => c.Incidents).Returns(requests.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Parts).Returns(requestsParts.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.RepairRequests).Returns(requestsRepairRequest.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Users).Returns(requestsUser.AsQueryable().BuildMockDbSet().Object);
        }
    }
}
