using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.DB.Reps.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GraphDataController : ControllerBase
    {
        private readonly ILogger<GraphDataController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GraphDataController(ILogger<GraphDataController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetByCountryId")]
        public async Task<List<GraphTemperatureDataDto>> GetByCountryId()
        {
            var data = await this._unitOfWork
                .RepTemperatures
                .Get(navs: "City,City.Country")
                .GroupBy(td => new { td.City.Country.Name, td.DateTime })
                .Select(g => new GraphTemperatureDataDto
                {
                    Name = g.Key.Name,
                    DateTime = g.Key.DateTime,
                    Temperature = g.Average(x => x.Temperature)
                }).ToListAsync();

            return data;
        }

        [HttpGet(Name = "GetByCityId")]
        public async Task<List<GraphTemperatureDataDto>> GetByCityId()
        {
            var data = await this._unitOfWork
                .RepTemperatures
                .Get(navs: "City")
                .GroupBy(td => new { td.City.Name, td.DateTime })
                .Select(g => new GraphTemperatureDataDto
                {
                    Name = g.Key.Name,
                    DateTime = g.Key.DateTime,
                    Temperature = g.Average(x => x.Temperature)
                }).ToListAsync();

            return data;
        }
    }
}
