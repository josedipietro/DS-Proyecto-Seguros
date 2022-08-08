// using Perito.BussinesLogic.Commands.RepairRequest.Commands.Atomics;
using Perito.Persistence.DAOs;

namespace Perito.BussinesLogic.Commands.RepairRequest
{
    public class RepairRequestCommandFactory : IRepairRequestCommandFactory
    {
        private readonly IRepairRequestDAO _repairRequestDAO;

        public RepairRequestCommandFactory(IRepairRequestDAO repairRequestDAO)
        {
            _repairRequestDAO = repairRequestDAO;
        }

    }
}
