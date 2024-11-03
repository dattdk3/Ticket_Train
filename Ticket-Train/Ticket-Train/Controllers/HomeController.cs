using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Repository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Trainrespository trainrespository;

        public HomeController(ILogger<HomeController> logger , Trainrespository _trainrespository)
        {
            _logger = logger;
            trainrespository = _trainrespository;   
        }

        public IActionResult Index()
        {
            var result = trainrespository.GetAll(1 , 2 , () =>
            {
                
            })
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}