using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class VehicleDTO
    {
        public string Plate { get; set; }
        public int Year { get; set; }
        public string SerialMotorNumber { get; set; }
        public string SerialChasisNumber { get; set; }
        public string Color { get; set; }
        public EnumBodyworkType BodyworkType { get; set; }
        public Guid InsuredId { get; set; }
        public string BrandCode { get; set; }
    }
}
