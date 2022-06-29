using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Administrador.Persistence.Entities
{
    public enum EnumEnterpriseType
    {
        Workshop,
        Supplier,
    }

    [Index(nameof(Rif), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    public class Enterprise : BaseEntity
    /*
    The Enterprise class have two types types
    - Workshop: the enterprise is a workshop
    - Supplier: the enterprise is a supplier
    */
    //TODO: Unique Constraint in Many to Many relationship
    {
        public string Rif { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public EnumEnterpriseType EnterpriseType { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public int? ParishId { get; set; }
        public virtual Parish Parish { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<RepairRequest> RepairRequests { get; set; }
        public virtual ICollection<PartQuotation> PartQuotations { get; set; }
    }
}
