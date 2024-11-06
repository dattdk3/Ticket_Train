using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface ITrainRepository : IGenericRepository<Train>
    {
        public Task<List<Train>> GetAll(int pagesize, int index, ICallback.CallFunc callback = null);
    }
}