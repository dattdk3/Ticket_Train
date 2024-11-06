using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task<Schedule> GetScheduleByTrainId(int trainId);
        Task<List<Schedule>> GetSchedules(int offset, int count, out int totalcount);
    }
}
