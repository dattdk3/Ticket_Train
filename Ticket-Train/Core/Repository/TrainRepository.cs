using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class TrainRepository : BaseRepository<Train>, ITrainRepository
    {

        public TrainRepository(TicketsContext ticketsContext) : base(ticketsContext) { }

        public Task<List<Train>> GetListTrain(int offset, int count, out int totalcount)
        {
            totalcount = _context.Trains.Count();
            return _context.Trains
                            .Where(o => o.IsActive == true || o.IsActive == null).ToListAsync();
        }

        //public async Task<List<Train>> GetAll(int pagesize, int index , ICallback.CallFunc callback = null)
        //{
        //    List<Train> list = await _context.Trains.ToListAsync();
        //    if (callback != null) callback();
        //    return list;
        //}


        public async Task<Train> GetWithid(int id)
        {
            Train train = await _context.Trains.
                                       FirstOrDefaultAsync(o => o.TrainId == id);
            return train;
        }
    }
}
