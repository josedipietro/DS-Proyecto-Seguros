using System.Collections.Generic;

namespace Administrador.Persistence.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Municipality> Municipalities { get; set; }
    }
}