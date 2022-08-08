using Microsoft.EntityFrameworkCore;
using Perito.Persistence.Entities;

namespace Perito.Persistence.Database
{
    public class PeritoDbContext : DbContext, IPeritoDbContext
    {
        public PeritoDbContext() { }

        public PeritoDbContext(DbContextOptions<PeritoDbContext> options) : base(options) { }

        public DbContext DbContext
        {
            get { return this; }
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<RepairRequest> RepairRequests { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
