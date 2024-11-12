using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Repository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    [RoleAuthorize(1)] // Chỉ cho phép người dùng có Role = 1
    public class SeatController : Controller
    {
        private readonly IUnitOfWork _seatRepository;
        public SeatController(IUnitOfWork seat)
        {
            _seatRepository = seat;
        }
        public async Task<IActionResult> ShowView(int pageIndex = 1, int pageSize = 4)
        {
            int totalcount = 0;
            var seats = await _seatRepository.Seats.GetListSeats(pageIndex, pageSize);
            int count = seats.Count;
            return View(seats);
        }

        public IActionResult SeatAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] Seat data)
        {
            await _seatRepository.Seats.AddAsync(data);
            await _seatRepository.SaveAsync();
            return Ok(new { success = true, message = "Thêm mới thành công." });
        }

        [HttpGet]
        public async Task<IActionResult> ShoweditForm(int id)
        {
            var seat = await _seatRepository.Seats.GetByIdAsync(id);
            return Ok(new { success = true, data = seat });
        }

        [HttpPut]
        public async Task<IActionResult> EditSeat([FromBody] Seat data)
        {
            await _seatRepository.Seats.UpdateAsync(data);
            await _seatRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }

        [HttpPut]
        public async Task<IActionResult> delete(int id)
        {
            Seat seat = await _seatRepository.Seats.GetByIdAsync(id);
            if (seat == null) return Ok(new { success = false, message = "Không tìm thấy." });
            seat.IsActive = false;
            await _seatRepository.Seats.UpdateAsync(seat);
            await _seatRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }
    }
}
