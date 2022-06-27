using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Entities;
using Administrador.Persistence.Database;

namespace Administrador.Persistence.DAOs
{
    public class StateDAO
    {
        private readonly AdministradorDbContext _context;

        public StateDAO(AdministradorDbContext context)
        {
            _context = context;
        }

        public bool StateExists(int id)
        {
            return (_context.States?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<State?> GetState(int id)
        {
            return await _context.States.FindAsync(id);
        }

        public async Task<State?> GetState(string name)
        {
            return await _context.States.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<State>> GetStates()
        {
            return await _context.States.ToListAsync();
        }
    }
}
