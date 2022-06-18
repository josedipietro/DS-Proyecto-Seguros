using System.Collections.Generic;

namespace Taller.Persistence.Entities
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
        public Guid EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
