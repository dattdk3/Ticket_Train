
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    public class TicketSearchController : Controller
    {
        private readonly IUnitOfWork _trainRepository;
        public TicketSearchController(IUnitOfWork train)
        {
            _trainRepository = train;
        }

        public async Task<IActionResult> SeatSelection()
        {
            var trainlist = await _trainRepository.Trains.GetAllAsync();
            return View(trainlist);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeatInTrain(int trainid)
        {
            var listSeat = await _trainRepository.Seats.GetSeatWithTrainid(trainid);
            return Ok(new { success = true, data = listSeat });
        }


    }
}
