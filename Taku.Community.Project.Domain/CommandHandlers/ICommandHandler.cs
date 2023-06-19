namespace Taku.Community.Project.Domain.CommandHandlers
{
    public interface ICommand
    {
    }
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
