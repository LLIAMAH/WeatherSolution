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
                return await this._unitOfWork.RepCountries.Get(navs: "Cities")
                    .Select(o => new CountryDto()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Cities = o.Cities.Select(c => new CityDto()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Lat = c.Latitude,
                            Long = c.Longitude
                        })
                    }).ToListAsync();
            }

            return await this._unitOfWork.RepCountries
                .Get(o => o.Name.ToLower().StartsWith(nameStart.ToLower()), navs: "Cities")
                .Select(o => new CountryDto()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Cities = o.Cities.Select(c => new CityDto()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Lat = c.Latitude,
                        Long = c.Longitude
                    })
                }).ToListAsync();
        }

        [HttpPost]
        public async Task<IResultBool> Post([FromBody] CountryCreateDto item)
        {
            //var exist = await this._unitOfWork
            //    .RepCountries.Get(o => o.Name.ToLower().Equals(item.Name.ToLower()))
            //    .FirstOrDefaultAsync();

            //if (exist != null)
            //    return new ResultBool(false, $"Country with name:'{item.Name}' already exists.");

            this._unitOfWork.RepCountries.Add(new Country() { Name = item.Name });

            return await this._unitOfWork.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task<IResultBool> Delete(long id)
        {
            var exist = await this._unitOfWork
                .RepCountries.Get(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (exist == null)
                return new ResultBool(false, $"No country with such id:{id} has been found.");

            this._unitOfWork.RepCountries.Remove(exist);
            return await this._unitOfWork.SaveChangesAsync();
        }
    }
}
