using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(TicketsContext context) : base(context)
        {
        }

        public Task<Schedule> GetScheduleByTrainId(int trainId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Schedule>> GetSchedules(int offset, int count, out int totalcount)
        {
            throw new NotImplementedException();
        }
    }
}
