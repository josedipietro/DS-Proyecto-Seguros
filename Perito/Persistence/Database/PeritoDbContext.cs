using Microsoft.EntityFrameworkCore;
using Perito.Persistence.Entities;

namespace Perito.Persistence.Database
{
    public class PeritoDbContext : DbContext, IPeritoDbContext
    {
        public PeritoDbContext()
        {
        }

        public PeritoDbContext(DbContextOptions<PeritoDbContext> options) : base(options)
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