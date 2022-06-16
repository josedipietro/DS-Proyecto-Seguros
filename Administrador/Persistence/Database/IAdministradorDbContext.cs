using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;

namespace Administrador.Persistence.Database
{
    public interface IAdministradorDbContext
    {
        DbContext DbContext
        {
            get;
        }
    }
}