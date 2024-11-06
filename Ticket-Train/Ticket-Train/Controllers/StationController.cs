using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationRepository _stationRepository;
        public StationController(IStationRepository station)
        {
            _stationRepository = station;
        }
        public IActionResult Index()
        {
            int totalcount = 0;
            var stations = _stationRepository.GetListStation(1 , 1 , out totalcount);
            return View();
        }
    }
}
