using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Proveedor.Persistence.Entities
{
    public class RepairRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
