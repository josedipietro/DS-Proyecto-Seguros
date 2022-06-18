using System.Collections.Generic;

namespace Taller.Persistence.Entities
{
    public class Quotation : BaseEntity
    {
        public int QuantityToRepair { get; set; }
        public decimal Total { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
    }
}
