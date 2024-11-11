using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<Seat> GetSeatById(int id);
        Task<List<Seat>> GetListSeats(int offset, int count, out int totalcount);
    }
}
