using Ticket_Train.Core.IRepository;

namespace Ticket_Train.Core.Repository
{
    public class RouteRepository : BaseRepository<Route> , IRouteRepository
    {
        public RouteRepository(Models.TicketsContext context) : base(context)
        {
        }

        public Task<List<Route>> GetRoutes(int offset, int count, out int totalcount)
        {
            throw new NotImplementedException();
        }

        public Task<Route> GetRouteWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
