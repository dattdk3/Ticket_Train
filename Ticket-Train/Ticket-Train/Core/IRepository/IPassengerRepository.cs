using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface IPassengerRepository : IGenericRepository<Passenger>
    {
        Task<Passenger> GetByIdWithDetails(int id);
        Task<List<Passenger>> GetPassengers(int offset, int count, out int totalcount);
    }
}
