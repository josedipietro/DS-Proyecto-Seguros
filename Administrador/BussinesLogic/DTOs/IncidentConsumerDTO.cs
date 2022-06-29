using Administrador.Persistence.Entities;

namespace Administrador.BussinesLogic.DTOs
{
    public class IncidentConsumerDTO
    {
        public Guid Id { get; set; }

        public EnumIncidentStatus Status { get; set; }
    }
}
