using System.Collections.Generic;

namespace Proveedor.Persistence.Entities
{
    public class Enterprise : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Participation> Participations { get; set; }
    }
}
