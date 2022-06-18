using System.Collections.Generic;

namespace Administrador.Persistence.Entities
{
    // make a enum for the roles
    public enum EnumRole
    {
        Administrator, // Administrador
        Proficient, // Perito
        Supplier, // Proveedor
        Workshop, // Taller
    }

    // Identification types for the user
    public enum EnumIdentificationType
    {
        V,
        E,
        P,
    }

    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    [Index(
        nameof(Identification),
        nameof(IdentificationType),
        IsUnique = true,
        Name = "IX_Identification_IdentificationType"
    )]
    [Index(nameof(LdapID), IsUnique = true)]
    public class User : BaseEntity
    {
        public string LdapID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
        public EnumIdentificationType IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public Guid? EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
