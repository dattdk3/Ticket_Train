using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class Trainrespository : BaseRepository<Train>, Itrainrespository
    {

        public Trainrespository(TicketsContext ticketsContext) : base(ticketsContext) { }
        public async Task<List<Train>> GetAll(int pagesize, int index , ICallback.CallFunc callback = null)
        {
            List<Train> list = await _context.Trains.ToListAsync();
            if (callback != null) callback();
            return list;
        }
    }
}
