using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<Seat> GetSeatById(int id);
        Task<List<Seat>> GetListSeats(int pageIndex = 1, int pageSize = 10);

        Task<List<Seat>> GetSeatWithTrainid(int trainid);
    }
}
