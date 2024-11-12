using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface IRouteRepository : IGenericRepository<Routes>
    {
        Task<Routes> GetRouteWithDetails(int id);
        Task<List<Routes>> GetRoutes(int pageIndex = 1, int pageSize = 10);
    }
}
