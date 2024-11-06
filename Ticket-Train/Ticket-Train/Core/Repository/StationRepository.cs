using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class StationRepository : BaseRepository<Station>, IStationRepository
    {
        public StationRepository(TicketsContext context) : base(context)
        {
        }

        // you can add more condition from here , t
        public Task<List<Station>> GetListStation(int offset, int count, out int totalcount)
        {
            totalcount = _context.Stations.Count();
            return _context.Stations.
                            Skip(offset - 1).
                            Take(count).ToListAsync();
        }



        public async Task<Station> GetWithid(int id)
        {
            Station station = await _context.Stations.
                                       FirstOrDefaultAsync(o => o.StationId == id);
            return station;
        }
    }
}
