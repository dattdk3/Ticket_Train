using Ticket_Train.Models;

namespace Ticket_Train.Core.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {

        Task<User> Authentication(string email, string password);
    }
}
