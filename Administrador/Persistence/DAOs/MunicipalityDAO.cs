using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;

namespace Administrador.Persistence.DAOs
{
    public class MunicipalityDAO
    {
        private readonly AdministradorDbContext _context;

        public MunicipalityDAO(AdministradorDbContext context)
        {
            _context = context;
        }

        public bool MunicipalityExists(int id)
        {
            return (_context.Municipalities?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<Municipality?> GetMunicipality(int id)
        {
            return await _context.Municipalities.FindAsync(id);
        }

        public async Task<Municipality?> GetMunicipality(string name)
        {
            return await _context.Municipalities.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<Municipality>> GetMunicipalities(int? stateId)
        {
            if (stateId.HasValue)
            {
                return await _context.Municipalities.Where(e => e.StateId == stateId).ToListAsync();
            }
            else
            {
                return await _context.Municipalities.ToListAsync();
            }
        }
    }
}
