namespace Ticket_Train.Core.IRepository
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        Task<Route> GetRouteWithDetails(int id);
        Task<List<Route>> GetRoutes(int offset, int count, out int totalcount);
    }
}
