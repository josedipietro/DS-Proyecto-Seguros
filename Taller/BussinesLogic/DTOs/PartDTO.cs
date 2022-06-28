using System;
using System.Collections.Generic;
using Taller.Persistence.Entities;

namespace Taller.BussinesLogic.DTOs
{
    public class PartDTO {

        //public Guid Id { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumPartStatus Status { get; set; } = EnumPartStatus.PendingReview;
        public int Quantity { get; set; }
        public Guid RepairRequestId { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
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
