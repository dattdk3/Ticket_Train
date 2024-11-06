using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TicketsContext _context;
        public IUserRepository user { get; }
        public IStationRepository Stations { get; private set; }
        public IPassengerRepository Passengers { get; private set; }
        public IRouteRepository Routes { get; private set; }
        public IScheduleRepository Schedules { get; private set; }
        public ISeatRepository Seats { get; private set; }
        public ITrainRepository Trains { get; private set; }

        public UnitOfWork(TicketsContext context)
        {
            _context = context;
            user = new UserRespository(_context);
            Passengers = new PassengerRepository(_context);
            Routes = new RouteRepository(_context);
            Schedules = new ScheduleRepository(_context);
            Seats = new SeatRepository(_context);
            Trains = new TrainRepository(_context);
        }


        public void Dispose()
        {
            _context.Dispose();
            // Giải phóng vùng nhớ
            GC.SuppressFinalize(this);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
        }
    }
}
