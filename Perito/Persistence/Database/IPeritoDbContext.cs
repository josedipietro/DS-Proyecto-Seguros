using Microsoft.EntityFrameworkCore;
using Perito.Persistence.Entities;

namespace Perito.Persistence.Database
{
    public interface IPeritoDbContext
    {
        DbContext DbContext { get; }

        DbSet<User> Users { get; set; }
        DbSet<Incident> Incidents { get; set; }
        DbSet<RepairRequest> RepairRequests { get; set; }
        DbSet<Part> Parts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
