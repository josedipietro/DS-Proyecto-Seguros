using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.Database
{
    public class AdministradorDbContext : DbContext, IAdministradorDbContext
    {
        public AdministradorDbContext() { }

        public AdministradorDbContext(DbContextOptions<AdministradorDbContext> options)
            : base(options) { }

        public DbContext DbContext
        {
            get { return this; }
        }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Parish> Parishes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Enterprise> Enterprises { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Insured> Insureds { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<RepairRequest> RepairRequests { get; set; }
        public virtual DbSet<PartQuotation> PartQuotations { get; set; }

    }
}
