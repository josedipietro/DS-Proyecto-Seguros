using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;

namespace Administrador.Persistence.DAOs
{
    public class ParishDAO
    {
        private readonly AdministradorDbContext _context;

        public ParishDAO(AdministradorDbContext context)
        {
            _context = context;
        }

        public bool ParishExists(int id)
        {
            return (_context.Parishes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<Parish?> GetParish(int id)
        {
            return await _context.Parishes.FindAsync(id);
        }

        public async Task<Parish?> GetParish(string name)
        {
            return await _context.Parishes.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<Parish>> GetParishes(int? municipalityId)
        {
            if (municipalityId.HasValue)
            {
                return await _context.Parishes
                    .Where(e => e.MunicipalityId == municipalityId)
                    .ToListAsync();
            }
            else
            {
                return await _context.Parishes.ToListAsync();
            }
        }
    }
}
