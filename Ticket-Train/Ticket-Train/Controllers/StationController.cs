using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Repository;
using Ticket_Train.Models;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ticket_Train.Controllers
{
    [RoleAuthorize(1)] // Chỉ cho phép người dùng có Role = 1
    public class StationController : Controller
    {
        private readonly IUnitOfWork _stationRepository;
        public StationController(IUnitOfWork station)
        {
            _stationRepository = station;
        }


        public async Task<IActionResult> ShowView(int pageIndex = 1, int pageSize = 4)
        {
            int totalcount = 0;
            var stations = await _stationRepository.Stations.GetListStation(pageIndex, pageSize);
            int count = stations.Count;
            return View(stations);
        }

        public IActionResult StationAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStation([FromBody] Station data)
        {
            await _stationRepository.Stations.AddAsync(data);
            await _stationRepository.SaveAsync();
            return Ok(new { success = true, message = "Thêm mới thành công." });
        }

        [HttpGet]
        public async Task<IActionResult> ShoweditForm(int id)
        {
            var station = await _stationRepository.Stations.GetByIdAsync(id);
            return Ok(new { success = true, data = station });
        }

        [HttpPut]
        public async Task<IActionResult> EditStation([FromBody] Station data)
        {
            await _stationRepository.Stations.UpdateAsync(data);
            await _stationRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }

        [HttpPut]
        public async Task<IActionResult> delete(int id)
        {
            Station station = await _stationRepository.Stations.GetByIdAsync(id);
            if(station == null) return Ok(new { success = false, message = "Không tìm thấy." });
            station.IsActive = false;
            await _stationRepository.Stations.UpdateAsync(station);
            await _stationRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }
    }
}
