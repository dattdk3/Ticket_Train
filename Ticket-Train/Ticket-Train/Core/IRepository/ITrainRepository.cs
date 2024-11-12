using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface ITrainRepository : IGenericRepository<Train>
    {
        Task<Train> GetWithid(int id);

        Task<List<Train>> GetListTrain(int pageIndex = 1, int pageSize = 10);
    }
}