using System.Collections.Generic;

namespace Perito.Persistence.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(LdapID), IsUnique = true)]
    public class User : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public string LdapID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
