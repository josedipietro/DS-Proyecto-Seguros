using Microsoft.EntityFrameworkCore;
using Proveedor.Persistence.Entities;

namespace Proveedor.Persistence.Database
{
    public interface IProveedorDbContext
    {
        DbContext DbContext
        {
            get;
        }
    }
}