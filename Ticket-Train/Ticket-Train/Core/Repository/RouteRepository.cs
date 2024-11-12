using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class RouteRepository : BaseRepository<Routes>, IRouteRepository
    {
        public RouteRepository(TicketsContext context) : base(context) { }

        public async Task<List<Routes>> GetRoutes(int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Routes.Where(o => o.IsActive == true || o.IsActive == null).AsQueryable();
            var paginatedList = await PaginatedList<Routes>.CreateAsync(query, pageIndex, pageSize);
            return paginatedList;
        }

        public async Task<Routes> GetRouteWithDetails(int id)
        {
            Routes route = await _context.Routes.
                                        FirstOrDefaultAsync(o => o.RouteId == id);
            return route;
        }
    }
}
