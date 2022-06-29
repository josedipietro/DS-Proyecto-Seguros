using Microsoft.EntityFrameworkCore;
using Taller.Persistence.Entities;

namespace Taller.Persistence.Database
{
    public interface ITallerDbContext
    {
        DbContext DbContext { get; }
        DbSet<User> User { get; set; }
        DbSet<RepairRequest> RepairRequests { get; set; }
        DbSet<Part> Parts { get; set; }
        DbSet<Quotation> Quotations { get; set; }
        DbSet<Enterprise> Enterprises { get; set; }
        DbSet<Brand> Brands { get; set; }
    }
}
