using Microsoft.AspNetCore.Mvc;

namespace Ticket_Train.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult BookingInfo()
        {
            return View();
        }
        public IActionResult Confirm() 
        { 
            return View(); 
        }
        public IActionResult Payment()
        {
            return View(); 
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
