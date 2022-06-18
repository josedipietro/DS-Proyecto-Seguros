using System.Collections.Generic;

namespace Taller.Persistence.Entities
{
    public class Enterprise : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        public int QuantityAttending { get; set; }
        public decimal RateProductivity { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
