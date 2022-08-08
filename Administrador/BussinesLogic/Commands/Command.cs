namespace Administrador.BussinesLogic.Commands
{
    public abstract class Command<TOut> : ICommand<TOut>
    {
        public abstract Task Execute();
        public abstract Task<TOut> GetResult();
    }
}
