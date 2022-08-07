namespace Administrador.BussinesLogic.Commands
{
    public interface ICommand<TOut>
    {
        public void Execute();
        public Task<TOut> GetResult();
    }
}
