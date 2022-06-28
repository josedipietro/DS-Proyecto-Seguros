using Proveedor.Persistence.Entities;

namespace Proveedor.BussinesLogic.DTOs
{
    public class RepairRequestDTO
    {
        public ICollection<Part> Parts { get; set; }
    }
}
