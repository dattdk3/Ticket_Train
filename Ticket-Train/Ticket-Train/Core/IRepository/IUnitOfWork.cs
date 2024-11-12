using Ticket_Train.Core.Repository;

namespace Ticket_Train.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository user { get; }
        IStationRepository Stations { get; }
        IPassengerRepository Passengers { get; }
        IRouteRepository Routes { get; }
        IScheduleRepository Schedules { get; }
        ISeatRepository Seats { get; }
        ITrainRepository Trains { get; }
        void save();

        Task SaveAsync();
    }
}
