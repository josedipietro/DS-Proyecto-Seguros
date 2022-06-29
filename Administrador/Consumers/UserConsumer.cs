using MassTransit;
using Administrador.Persistence.Entities;
using System.Threading.Tasks;

namespace Administrador.Consumers
{
    public class UserConsumer : IConsumer<User>
    {
        public async Task Consume(ConsumeContext<User> context)
        {
            var user = context.Message;
            // print the message to the console
            System.Console.WriteLine($"User: {user}");
        }
    }
}
