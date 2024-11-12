using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(TicketsContext context) : base(context)
        {
        }

        public Task<Passenger> GetByIdWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Passenger>> GetPassengers(int offset, int count, out int totalcount)
        {
            throw new NotImplementedException();
        }
    }
}
