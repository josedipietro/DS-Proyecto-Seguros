using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Administrador.Persistence.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Municipality> Municipalities { get; set; }
    }
}