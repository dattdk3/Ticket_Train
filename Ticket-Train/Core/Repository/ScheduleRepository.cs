using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
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

        public Task<List<Schedule>> GetSchedules(int offset, int count, out int totalcount)
        {
            totalcount = _context.Schedules.Count();
            return _context.Schedules
                            .Where(o => o.IsActive == true || o.IsActive == null).ToListAsync();
        }
    }
}
