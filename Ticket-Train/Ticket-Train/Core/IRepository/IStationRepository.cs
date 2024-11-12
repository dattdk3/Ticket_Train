using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface IStationRepository : IGenericRepository<Station>
    {
        Task<Station> GetWithid(int id);

        Task<List<Station>> GetListStation(int pageIndex = 1, int pageSize = 10);
    }
}
