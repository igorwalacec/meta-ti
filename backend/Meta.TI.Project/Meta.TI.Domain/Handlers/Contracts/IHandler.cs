using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
