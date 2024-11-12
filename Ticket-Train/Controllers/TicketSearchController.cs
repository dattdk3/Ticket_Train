using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    public class TicketSearchController : Controller
    {
        private readonly IUnitOfWork _trainRepository;
        private readonly IUnitOfWork _seatRepository;
        public TicketSearchController(IUnitOfWork train, IUnitOfWork seatRepository)
        {
            _trainRepository = train;
            _seatRepository = seatRepository;
        }

        public async Task<IActionResult> SeatSelection()
        {
            //// Lấy tất cả tàu từ repository
            //int totalcount = 0;
            //var trains = await _trainRepository.Trains.GetListTrain(0, 0, out totalcount);

            ////var train = await _trainRepository.Trains
            ////    .Include(t => t.Seats) // Include Seats to ensure it's populated
            ////    .Where(t => t.IsActive == true)
            ////    .ToList(); 

            //// Kiểm tra nếu không có tàu nào
            //if (trains == null || !trains.Any())
            //{
            //    return NotFound("Không tìm thấy tàu nào.");
            //}

            return View();
        }
    }
}
