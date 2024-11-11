using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class RouteRepository : BaseRepository<Routes>, IRouteRepository
    {
        public RouteRepository(TicketsContext context) : base(context) { }
        public Task<List<Routes>> GetRoutes(int offset, int count, out int totalcount)
        {

            totalcount = _context.Routes.Count();
            return _context.Routes
                            .Where(o => o.IsActive == true || o.IsActive == null).ToListAsync();
        }

        public async Task<Routes> GetRouteWithDetails(int id)
        {
            Routes route = await _context.Routes.
                                        FirstOrDefaultAsync(o => o.RouteId == id);
            return route;
        }
    }
}
