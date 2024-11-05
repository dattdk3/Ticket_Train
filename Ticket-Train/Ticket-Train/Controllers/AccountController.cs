using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ticket_Train.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TicketsContext _context;

        public AccountController(TicketsContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        // POST: api/Account/Register
        [HttpPost("register")]
      
        public async Task<IActionResult> Register([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra email đã tồn tại
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (existingUser == null)
                {
                    model.Role = 2; // Đặt role mặc định là user
                    _context.Users.Add(model);
                    await _context.SaveChangesAsync();
                    return Ok(new { success = true, message = "Đăng ký thành công." });
                }
                return BadRequest(new { success = false, message = "Email đã được sử dụng." });
            }
            return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });
        }
        public IActionResult Login()
        {
            return View();
        }

        // POST: api/Account/Login
        [HttpPost("login")]

        // GET: Login
     
        public async Task<IActionResult> Login([FromBody] User loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);

                if (user != null)
                {
                    // Đăng nhập thành công
                    
                    return Ok(new { success = true, message = "Đăng nhập thành công." });
                }
                return Unauthorized(new { success = false, message = "Email hoặc mật khẩu không đúng." });
            }
            return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });
        }

     
    }
}