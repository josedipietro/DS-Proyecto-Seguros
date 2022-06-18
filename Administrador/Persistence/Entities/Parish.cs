using System.Collections.Generic;

namespace Administrador.Persistence.Entities
{
    public class Parish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MunicipalityId { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual ICollection<Enterprise> Enterprises { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
