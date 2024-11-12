using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Repository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    [RoleAuthorize(1)] // Chỉ cho phép người dùng có Rol
    public class ScheduleController : Controller
    {
        private readonly IUnitOfWork _scheduleRepository;
        public ScheduleController(IUnitOfWork schedule)
        {
            _scheduleRepository = schedule;
        }
        public async Task<IActionResult> ShowView()
        {
            int totalcount = 0;
            var schedules = await _scheduleRepository.Schedules.GetSchedules(10, 10, out totalcount);
            int count = schedules.Count;
            return View(schedules);
        }

        public IActionResult ScheduleAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] Schedule data)
        {
            await _scheduleRepository.Schedules.AddAsync(data);
            await _scheduleRepository.SaveAsync();
            return Ok(new { success = true, message = "Thêm mới thành công." });
        }

        [HttpGet]
        public async Task<IActionResult> ShoweditForm(int id)
        {
            var schedule = await _scheduleRepository.Schedules.GetByIdAsync(id);
            return Ok(new { success = true, data = schedule });
        }

        [HttpPut]
        public async Task<IActionResult> EditSchedule([FromBody] Schedule data)
        {
            await _scheduleRepository.Schedules.UpdateAsync(data);
            await _scheduleRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }

        [HttpPut]
        public async Task<IActionResult> delete(int id)
        {
            Schedule schedule = await _scheduleRepository.Schedules.GetByIdAsync(id);
            if (schedule == null) return Ok(new { success = false, message = "Không tìm thấy." });
            schedule.IsActive = false;
            await _scheduleRepository.Schedules.UpdateAsync(schedule);
            await _scheduleRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }
    }
}
