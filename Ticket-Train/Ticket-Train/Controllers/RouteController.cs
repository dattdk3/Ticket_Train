using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Repository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    [RoleAuthorize(1)] // Chỉ cho phép người dùng có Role 
    public class RouteController : Controller
    {
        private readonly IUnitOfWork _routeRepository;
        public RouteController(IUnitOfWork route)
        {
            _routeRepository = route;
        }
        public async Task<IActionResult> ShowView(int pageIndex = 1, int pageSize = 4)
        {
            int totalcount = 0;
            var routes = await _routeRepository.Routes.GetRoutes(pageIndex, pageSize);
            int count = routes.Count;
            return View(routes);
        }

        public IActionResult RouteAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoute([FromBody] Routes data)
        {
            await _routeRepository.Routes.AddAsync(data);
            await _routeRepository.SaveAsync();
            return Ok(new { success = true, message = "Thêm mới thành công." });
        }

        [HttpGet]
        public async Task<IActionResult> ShoweditForm(int id)
        {
            var route = await _routeRepository.Routes.GetByIdAsync(id);
            return Ok(new { success = true, data = route });
        }
        [HttpPut]
        public async Task<IActionResult> EditRoute([FromBody] Routes data)
        {
            await _routeRepository.Routes.UpdateAsync(data);
            await _routeRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }

        [HttpPut]
        public async Task<IActionResult> delete(int id)
        {
            Routes route = await _routeRepository.Routes.GetByIdAsync(id);
            if (route == null) return Ok(new { success = false, message = "Không tìm thấy." });
            route.IsActive = false;
            await _routeRepository.Routes.UpdateAsync(route);
            await _routeRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }
    }
}
