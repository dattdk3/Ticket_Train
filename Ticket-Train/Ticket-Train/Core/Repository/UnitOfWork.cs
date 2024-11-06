using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TicketsContext _context;
        public IUserRepository user { get; }


        public UnitOfWork(TicketsContext context)
        {
            _context = context;
            user = new UserRespository(_context);
        }


        public void Dispose()
        {
            _context.Dispose();
            // Giải phóng vùng nhớ
            GC.SuppressFinalize(this);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
