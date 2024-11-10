﻿using Microsoft.AspNetCore.Mvc;
using Ticket_Train.Core.IRepository;
using Ticket_Train.Core.Repository;
using Ticket_Train.Models;

namespace Ticket_Train.Controllers
{
    public class TrainController : Controller
    {
        private readonly IUnitOfWork _trainRepository;
        public TrainController(IUnitOfWork train)
        {
            _trainRepository = train;
        }
        public async Task<IActionResult> ShowView()
        {
            int totalcount = 0;
            var trains = await _trainRepository.Trains.GetListTrain(10, 10, out totalcount);
            int count = trains.Count;
            return View(trains);
        }

        public IActionResult TrainAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTrain([FromBody] Train data)
        {
            await _trainRepository.Trains.AddAsync(data);
            await _trainRepository.SaveAsync();
            return Ok(new { success = true, message = "Thêm mới thành công." });
        }

        [HttpGet]
        public async Task<IActionResult> ShoweditForm(int id)
        {
            var train = await _trainRepository.Trains.GetByIdAsync(id);
            return Ok(new { success = true, data = train });
        }

        [HttpPut]
        public async Task<IActionResult> EditTrain([FromBody] Train data)
        {
            await _trainRepository.Trains.UpdateAsync(data);
            await _trainRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }

        [HttpPut]
        public async Task<IActionResult> delete(int id)
        {
            Train train = await _trainRepository.Trains.GetByIdAsync(id);
            if (train == null) return Ok(new { success = false, message = "Không tìm thấy." });
            train.IsActive = false;
            await _trainRepository.Trains.UpdateAsync(train);
            await _trainRepository.SaveAsync();
            return Ok(new { success = true, message = "Cập nhập thành công." });
        }
    }
}
