namespace Administrador.BussinesLogic.DTOs
{
    public class IncidentDTO
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public int ParishId { get; set; }

        public Guid PolicyId { get; set; }

        public Guid? ThirdPolicyId { get; set; }
    }
}
