using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        public SeatRepository(TicketsContext context) : base(context)
        {
        }

        public Task<List<Seat>> GetListSeats(int offset, int count, out int totalcount)
        {
            totalcount = _context.Seats.Count();
            
            return _context.Seats
                            .Where(o => o.IsActive == true || o.IsActive == null).ToListAsync();
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