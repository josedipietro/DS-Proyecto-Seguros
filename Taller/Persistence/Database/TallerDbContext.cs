using Microsoft.EntityFrameworkCore;
using Taller.Persistence.Entities;

namespace Taller.Persistence.Database
{
    public class TallerDbContext : DbContext, ITallerDbContext
    {
        public TallerDbContext() { }

        public TallerDbContext(DbContextOptions<TallerDbContext> options) : base(options) { }

        public DbContext DbContext
        {
            get { return this; }
        }

        public DbSet<User> User { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Brand> Brands { get; set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
