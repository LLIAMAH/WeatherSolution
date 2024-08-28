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
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CitiesController(ILogger<CitiesController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public async Task<CityDto?> GetById(long id)
        {
            return await this._unitOfWork
                .RepCities.Get(o => o.Id == id, navs: "Country")
                .Select(o => new CityDto()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Lat = o.Latitude,
                    Long = o.Longitude,
                    Country = new CountryDto()
                    {
                        Id = o.Country.Id,
                        Name = o.Country.Name,
                    }
                }).FirstOrDefaultAsync();
        }

        [HttpGet("GetByName")]
        public async Task<IEnumerable<CityDto>> GetByName(string? nameStart = null)
        {
            if (nameStart == null)
            {
                return await this._unitOfWork.RepCities.Get(navs: "Country")
                    .Select(o => new CityDto()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Lat = o.Latitude,
                        Long = o.Longitude,
                        Country = new CountryDto()
                        {
                            Id = o.Country.Id,
                            Name = o.Country.Name,
                        }
                    }).ToListAsync();
            }

            return await this._unitOfWork
                .RepCities.Get(o => o.Name.ToLower().StartsWith(nameStart.ToLower()), navs: "Country")
                .Select(o => new CityDto()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Lat = o.Latitude,
                    Long = o.Longitude,
                    Country = new CountryDto()
                    {
                        Id = o.Country.Id,
                        Name = o.Country.Name,
                    }
                }).ToListAsync();

        }

        [HttpGet("GetByCountryId")]
        public async Task<IEnumerable<CityDto>> GetByCountryId(long id)
        {
            return await this._unitOfWork
                .RepCities.Get(o => o.CountryId == id)
                .Select(o => new CityDto()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Lat = o.Latitude,
                    Long = o.Longitude,
                }).ToListAsync();
        }

        [HttpPost]
        public async Task<IResultBool> Post([FromBody] CityCreateDto item)
        {
            var exist = await this._unitOfWork
                .RepCities.Get(o => o.CountryId == item.CountryId && o.Name.ToLower().Equals(item.Name.ToLower()))
                .FirstOrDefaultAsync();

            if (exist != null)
                return new ResultBool(false, $"City with name:'{item.Name}' for this country already exists.");

            this._unitOfWork.RepCities.Add(new City()
            {
                Name = item.Name,
                CountryId = item.CountryId,
                Latitude = item.Lat,
                Longitude = item.Long
            });

            return await this._unitOfWork.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task<IResultBool> Delete(long id)
        {
            var exist = await this._unitOfWork
                .RepCities.Get(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (exist == null)
                return new ResultBool(false, $"No city with such id:{id} has been found.");

            this._unitOfWork.RepCities.Remove(exist);
            return await this._unitOfWork.SaveChangesAsync();
        }
    }
}
