using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class TrainRepository : BaseRepository<Train>, ITrainRepository
    {

        public TrainRepository(TicketsContext ticketsContext) : base(ticketsContext) { }

        public async Task<List<Train>> GetListTrain(int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Trains.AsQueryable();
            var paginatedList = await PaginatedList<Train>.CreateAsync(query, pageIndex, pageSize);
            return paginatedList;
        }

        public async Task<Train> GetWithid(int id)
        {
            Train train = await _context.Trains.
                                       FirstOrDefaultAsync(o => o.TrainId == id);
            return train;
        }
    }
}
