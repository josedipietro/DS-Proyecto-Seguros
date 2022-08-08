namespace Perito.BussinesLogic.Commands
{
    public interface ICommand<TOut>
    {
        public Task Execute();
        public Task<TOut> GetResult();
    }
}
