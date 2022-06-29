using MassTransit;
using Administrador.Persistence.Entities;
using Administrador.BussinesLogic.DTOs;
using System.Threading.Tasks;

namespace Administrador.Consumers
{
    public class UserConsumer : IConsumer<BrandDTO>
    {
        public async Task Consume(ConsumeContext<BrandDTO> context)
        {
            var user = context.Message;
            // print the message to the console
            System.Console.WriteLine($"User:");
            System.Console.WriteLine($"User: {user.Code}");
        }
    }
}
