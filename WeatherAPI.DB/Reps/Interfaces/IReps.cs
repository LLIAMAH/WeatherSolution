using WeatherAPI.DB.Entities;

namespace WeatherAPI.DB.Reps.Interfaces
{
    public interface IRepCountries : IRep<Country>{}
    public interface IRepCities : IRep<City> { }
    public interface IRepTemperatures: IRep<TemperatureData> { }
}
