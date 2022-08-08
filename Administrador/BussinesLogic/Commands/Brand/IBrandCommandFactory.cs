using Administrador.BussinesLogic.Commands.Brand.Commands.Atomics;

namespace Administrador.BussinesLogic.Commands.Brand
{
    public interface IBrandCommandFactory
    {
        Task<GetBrands> GetBrands();
    }
}
