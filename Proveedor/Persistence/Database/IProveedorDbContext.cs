using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.Database
{
    public interface IProveedorDbContext
    {
        DbContext DbContext { get; }
        DbSet<Enterprise> Enterprises { get; set; }
        DbSet<RepairRequest> RepairRequests { get; set; }
        DbSet<Part> Parts { get; set; }
        DbSet<Participation> Participations { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<PartQuotation> PartQuotations { get; set; }
        DbSet<Brand> Brands { get; set; }
    }
}
