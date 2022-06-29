using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Taller.Persistence.Entities
{
    public class Enterprise : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        public int QuantityAttending { get; set; }
        [Precision(precision:3, scale:2)]
        public decimal RateProductivity { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
