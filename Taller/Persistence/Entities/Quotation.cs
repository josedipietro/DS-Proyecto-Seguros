using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Taller.Persistence.Entities
{
    public class Quotation : BaseEntity
    {
        public int QuantityToRepair { get; set; }
        [Precision(precision:10, scale:2)]
        public decimal Total { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual RepairRequest RepairRequest { get; set; }
    }
}
