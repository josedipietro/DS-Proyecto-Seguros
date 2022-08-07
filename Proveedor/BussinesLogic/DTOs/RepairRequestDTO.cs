using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.DTOs
{
    public class RepairRequestDTO
    {

        public Guid Id { get; set; }

        public DateTime BuyDate { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}
