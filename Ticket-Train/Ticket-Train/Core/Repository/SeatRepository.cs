using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Utilities;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        public SeatRepository(TicketsContext context) : base(context)
        {
        }

        public async Task<List<Seat>> GetListSeats(int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Seats.Where(o => o.IsActive == true || o.IsActive == null).AsQueryable();
            var paginatedList = await PaginatedList<Seat>.CreateAsync(query, pageIndex, pageSize);
            return paginatedList;
        }

        public async Task<Seat> GetSeatById(int id)
        {
             Seat seat = await _context.Seats.
                                       FirstOrDefaultAsync(o => o.SeatId == id);
            return seat;
        }

        public async Task<List<Seat>> GetSeatWithTrainid(int trainid)
        {
            return await _context.Seats.Where(o=> o.TrainId  == trainid).ToListAsync();
        }
    }
}