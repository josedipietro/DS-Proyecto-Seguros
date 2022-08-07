using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Persistence.Entities;

namespace Taller.BussinesLogic.DTOs
{
    public class RepairRequestDTO
    {

        //public Guid Id { get; set; }
        //public Guid Id { get; set; }
        public EnumRepairStatus Status { get; set; } = EnumRepairStatus.Peding;

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid VehicleId { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PolicyId { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IncidentId { get; set; }

        public Guid? QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

        public DateTime BuyDate { get; set; }
    }
}
