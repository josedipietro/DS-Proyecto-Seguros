using System;
using System.Collections.Generic;
using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class PolicyDTO
    {
        public EnumPolicyType PolicyType { get; set; }

        public DateTime BuyDate { get; set; }
        public Guid VehicleId { get; set; }
    }
}
