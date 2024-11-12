using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class StationRepository : BaseRepository<Station>, IStationRepository
    {
        public StationRepository(TicketsContext context) : base(context)
        {
        }

        // you can add more condition from here , t
        public async Task<List<Station>> GetListStation(int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Stations.Where(o => o.IsActive == true || o.IsActive == null).AsQueryable();
            var paginatedList = await PaginatedList<Station>.CreateAsync(query, pageIndex, pageSize);
            return paginatedList;
        }



        public async Task<Station> GetWithid(int id)
        {
            Station station = await _context.Stations.
                                       FirstOrDefaultAsync(o => o.StationId == id);
            return station;
        }
    }
}
