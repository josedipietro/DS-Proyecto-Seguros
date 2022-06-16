using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.Database
{
    public class AdministradorDbContext : DbContext, IAdministradorDbContext
    {
        public AdministradorDbContext()
        {
        }

        public AdministradorDbContext(DbContextOptions<AdministradorDbContext> options) : base(options)
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