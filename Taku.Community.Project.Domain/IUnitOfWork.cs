namespace Taku.Community.Project.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
