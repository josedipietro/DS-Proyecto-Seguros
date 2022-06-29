using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Administrador.Persistence.Entities
{
    public enum EnumPolicyType
    {
        CompleteCover,
        ThirdSupporter,
    }

    public class Policy : BaseEntity
    {
        public EnumPolicyType PolicyType { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [InverseProperty("Policy")]
        public virtual ICollection<Incident> Incidents { get; set; }

        [InverseProperty("ThirdPolicy")]
        public virtual ICollection<Incident> ThirdIncidents { get; set; }
    }
}
