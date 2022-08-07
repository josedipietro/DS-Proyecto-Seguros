using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Taller.Persistence.Entities;

namespace Taller.BussinesLogic.DTOs
{
    public class QuotationDTO
    {

        //public Guid Id { get; set; }
        public int QuantityToRepair { get; set; }
        [Precision(precision: 10, scale: 2)]
        public decimal Total { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid RepairRequest { get; set; } 

    }

    /*public class PartUpdateDTO
    {
        public string Name { get; set; }
        public EnumPartStatus Status { get; set; } = EnumPartStatus.PendingReview;
        public int Quantity { get; set; }
        public Guid RepairRequestId { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
    }*/
}
