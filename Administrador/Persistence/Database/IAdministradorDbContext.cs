using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.Database
{
    public interface IAdministradorDbContext
    {
        DbContext DbContext { get; }

        DbSet<State> States { get; set; }
        DbSet<Municipality> Municipalities { get; set; }
        DbSet<Parish> Parishes { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Enterprise> Enterprises { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Insured> Insureds { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Policy> Policies { get; set; }
        DbSet<Incident> Incidents { get; set; }
        DbSet<Part> Parts { get; set; }
        DbSet<RepairRequest> RepairRequests { get; set; }
        DbSet<PartQuotation> PartQuotations { get; set; }
    }
}
