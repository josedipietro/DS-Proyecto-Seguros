using MockQueryable.Moq;
using Moq;
using Perito.Persistence.Database;
using Perito.Persistence.Entities;

namespace RCVUcab.PeritoTests.DataSeed
{
    public class DataSeedUser
    {

        private readonly List<User> users;
        public DataSeedUser(Mock<IPeritoDbContext> mockContext)
        {
            users = new List<User>
            {
                new User
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
            };

            mockContext.Setup(c => c.Users).Returns(users.AsQueryable().BuildMockDbSet().Object);
        }

        public void SetupCreate(Mock<IPeritoDbContext> mockContext, User user)
        {
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<User>())).Callback(() => users.Add(user));
        }

        public void SetupUpdate(Mock<IPeritoDbContext> mockContext, User user)
        {
            var userOld = users.Find(i => i.Id == user.Id);
            mockContext.Setup(i => i.DbContext.Add(It.IsAny<User>())).Callback(() => userOld = user);
        }
    }
}
