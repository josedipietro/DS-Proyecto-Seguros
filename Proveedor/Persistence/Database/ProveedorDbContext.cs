using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.Database
{
    public class ProveedorDbContext : DbContext, IProveedorDbContext
    {
        public ProveedorDbContext()
        {
        }

        public ProveedorDbContext(DbContextOptions<ProveedorDbContext> options) : base(options)
        {
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

    }
}