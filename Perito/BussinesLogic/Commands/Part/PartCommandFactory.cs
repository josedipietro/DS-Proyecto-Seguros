//  using Perito.BussinesLogic.Commands.Part.Commands.Atomics;
using Perito.Persistence.DAOs;

namespace Perito.BussinesLogic.Commands.Part
{
    public class PartCommandFactory : IPartCommandFactory
    {
        private readonly IPartDAO _partDAO;

        public PartCommandFactory(IPartDAO partDAO)
        {
            _partDAO = partDAO;
        }

    }
}
