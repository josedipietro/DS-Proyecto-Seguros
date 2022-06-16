using Microsoft.EntityFrameworkCore;
using Taller.Persistence.Entities;

namespace Taller.Persistence.Database
{
    public interface ITallerDbContext
    {
        DbContext DbContext
        {
            get;
        }
    }
}