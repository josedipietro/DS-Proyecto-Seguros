using System.Collections.Generic;

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
        public virtual ICollection<Incident> Incidents { get; set; }
        public virtual ICollection<Incident> ThirdIncidents { get; set; }
    }
}
