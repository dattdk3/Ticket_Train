using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<Seat> GetSeatByNumber(int seatNumber);
        Task<List<Seat>> GetAvailableSeats(int offset, int count, out int totalcount);
    }
}
