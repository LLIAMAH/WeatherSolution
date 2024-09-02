using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.DB.Entities;
using WeatherAPI.DB.Reps;
using WeatherAPI.DB.Reps.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        private readonly ILogger<WeatherDataController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WeatherDataController(ILogger<WeatherDataController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IResultBool> Post([FromBody] CityTemperaturePostDto[] items)
        {
            var dateTime = DateTime.Now;
            foreach (var inputItem in items)
            {
                this._unitOfWork.RepTemperatures.Add(new TemperatureData
                {
                    DateTime = dateTime,
                    CityId = inputItem.CityId,
                    Temperature = inputItem.TempData
                });
            }

            return await this._unitOfWork.SaveChangesAsync();
        }
    }
}
