using System;
using System.Collections.Generic;
using Taller.Persistence.Entities;

namespace Taller.BussinesLogic.DTOs
{
    public class EnterpriseDTO
    {
        public Guid Id { get; set; }

        public int QuantityAttending { get; set; }

        public decimal RateProductivity { get; set; }

        //public EnumEnterpriseType EnterpriseType { get; set; }

       //public int? ParishId { get; set; }

        public ICollection<string> Brands { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

    public class EnterpriseUpdateDTO
    {
        public int QuantityAttending { get; set; }

        public decimal RateProductivity { get; set; }

        //public EnumEnterpriseType EnterpriseType { get; set; }

        //public int? ParishId { get; set; }

        public ICollection<string> Brands { get; set; }
    }
}
