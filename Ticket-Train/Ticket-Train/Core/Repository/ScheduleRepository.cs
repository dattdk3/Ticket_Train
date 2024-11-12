using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(TicketsContext context) : base(context)
        {
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
            Schedule schedule = await _context.Schedules.
                                        FirstOrDefaultAsync(o => o.ScheduleId == id);
            return schedule;
        }

        public async Task<List<Schedule>> GetSchedules(int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Schedules.Where(o => o.IsActive == true || o.IsActive == null).AsQueryable();
            var paginatedList = await PaginatedList<Schedule>.CreateAsync(query, pageIndex, pageSize);
            return paginatedList;
        }
    }
}
