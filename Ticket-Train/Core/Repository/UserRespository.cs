using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Core.Repository
{
    public class UserRespository : BaseRepository<User>, IUserRepository
    {

        public UserRespository(TicketsContext context) : base(context)
        {
        }
        public async Task<User> Authentication(string email, string password)
        {
            try
            {
                User user = await _context.Users.Where(user =>
                                            user.Email.Equals(email) && user.Password.Equals(password))
                                                .FirstOrDefaultAsync();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during authentication: {ex.Message}");
                Console.WriteLine(ex.StackTrace); // In ra thông tin chi tiết về lỗi nếu cần
            }

            return null;
        }
    }
}
