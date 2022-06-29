using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.Database
{
    public class ProveedorDbContext : DbContext, IProveedorDbContext
    {
        public ProveedorDbContext() { }

        public ProveedorDbContext(DbContextOptions<ProveedorDbContext> options) : base(options) { }

        public DbContext DbContext
        {
            get { return this; }
        }

        public virtual DbSet<Enterprise> Enterprises { get; set; }
        public virtual DbSet<RepairRequest> RepairRequests { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Participation> Participations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PartQuotation> PartQuotations { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
    }
}
