using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        public SeatRepository(TicketsContext context) : base(context)
        {
        }

        public Task<List<Seat>> GetAvailableSeats(int offset, int count, out int totalcount)
        {
            throw new NotImplementedException();
        }

        public Task<Seat> GetSeatByNumber(int seatNumber)
        {
            throw new NotImplementedException();
        }
    }
}
