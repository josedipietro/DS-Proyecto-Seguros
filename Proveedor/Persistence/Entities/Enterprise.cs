using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Proveedor.Persistence.Entities
{
    public class Enterprise : BaseEntity
    {
        public enum EnumEnterpriseType
        {
            Workshop,
            Supplier,
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
