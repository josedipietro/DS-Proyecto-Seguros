using Taller.BussinesLogic.Commands.Brand.Commands.Atomics;

namespace Taller.BussinesLogic.Commands.Brand
{
    public interface IBrandCommandFactory
    {
        Task<GetBrands> GetBrands();
    }
}
