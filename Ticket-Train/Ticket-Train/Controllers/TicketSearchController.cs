using Microsoft.AspNetCore.Mvc;

namespace Ticket_Train.Controllers
{
    public class TicketSearchController : Controller
    {
        public IActionResult SeatSelection()
        {
            return View();
        }
    }
}
