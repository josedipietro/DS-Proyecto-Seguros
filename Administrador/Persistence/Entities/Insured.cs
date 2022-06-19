using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Administrador.Persistence.Entities
{
    public enum EnumInsuredTypeIdentification
    {
        V,
        E,
        P
    }

    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    [Index(
        nameof(Identification),
        nameof(InsuredTypeIdentification),
        IsUnique = true,
        Name = "IX_Insured_Identification_IdentificationType"
    )]
    public class Insured : BaseEntity
    {
        public EnumInsuredTypeIdentification InsuredTypeIdentification { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
