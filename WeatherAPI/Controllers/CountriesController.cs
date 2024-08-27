using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.DB.Reps.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CountriesController(ILogger<CountriesController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDto>> Get(string? nameStart = null)
        {
            if (nameStart == null)
            {
                return await this._unitOfWork.RepCountries.Get()
                    .Select(o => new CountryDto()
                    {
                        Id = o.Id,
                        Name = o.Name,
                    }).ToListAsync();
            }

            return await this._unitOfWork.RepCountries
                .Get(o => o.Name.StartsWith(nameStart.ToLower(), StringComparison.OrdinalIgnoreCase))
                .Select(o => new CountryDto()
                {
                    Id = o.Id,
                    Name = o.Name,
                }).ToListAsync();
        }
    }
}
