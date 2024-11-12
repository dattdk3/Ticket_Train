using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;

namespace Ticket_Train.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork repository)
        {
            _unitOfWork = repository;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            await _unitOfWork.user.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return Ok(new { success = true, message = "Đăng kí thành công." });
        }
        public IActionResult Login()
        {
            return View();
        }

        public string GetAllStudents()
        {
            return "Return All Students";
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User loginModel)
        {

            User user = await _unitOfWork.user.Authentication(loginModel.Email, loginModel.Password);
            if (user == null)
            {
                return Ok(new { success = false, message = "Đăng nhập không thành công." });
            }

            // Lưu tên người dùng vào session
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetInt32("UserRole", user.Role);

            return Ok(new { success = true, message = "Đăng nhập thành công.", userName = user.Name, role = user.Role });
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session data
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View(); // Tạo trang AccessDenied.cshtml để hiển thị thông báo
        }
    }
}