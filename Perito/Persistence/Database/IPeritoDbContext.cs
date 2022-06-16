using Microsoft.EntityFrameworkCore;
using Perito.Persistence.Entities;

namespace Perito.Persistence.Database
{
    public interface IPeritoDbContext
    {
        DbContext DbContext
        {
            get;
        }
    }
}