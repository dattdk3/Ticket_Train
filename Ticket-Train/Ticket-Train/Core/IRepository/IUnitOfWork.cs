namespace Ticket_Train.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository user { get; }
        void save();

        Task SaveAsync();
    }
}
