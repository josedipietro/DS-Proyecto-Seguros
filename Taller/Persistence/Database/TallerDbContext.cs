using Microsoft.EntityFrameworkCore;
using Taller.Persistence.Entities;

namespace Taller.Persistence.Database
{
    public class TallerDbContext : DbContext, ITallerDbContext
    {
        public TallerDbContext()
        {
        }

        public TallerDbContext(DbContextOptions<TallerDbContext> options) : base(options)
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