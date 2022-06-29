using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Administrador.Persistence.Entities
{
    public enum EnumBodyworkType
    {
        Sedan,
        Convertible,
        PickUp,
        Corf,
        Hatchback,
    }

    [Index(nameof(Plate), IsUnique = true)]
    [Index(nameof(SerialMotorNumber), IsUnique = true)]
    [Index(nameof(SerialChasisNumber), IsUnique = true)]
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public int Year { get; set; }
        public string SerialMotorNumber { get; set; }
        public string SerialChasisNumber { get; set; }
        public string Color { get; set; }
        public EnumBodyworkType BodyworkType { get; set; }
        public Guid InsuredId { get; set; }
        public virtual Insured Insured { get; set; }
        public string BrandCode { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<RepairRequest> RepairRequests { get; set; }
    }
}
