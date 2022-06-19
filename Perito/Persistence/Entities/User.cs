using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

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
        public string Email { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
