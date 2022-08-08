// using Perito.BussinesLogic.Commands.User.Commands.Atomics;
using Perito.Persistence.DAOs;

namespace Perito.BussinesLogic.Commands.User
{
    public class UserCommandFactory : IUserCommandFactory
    {
        private readonly IUserDAO _userDAO;

        public UserCommandFactory(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

    }
}
