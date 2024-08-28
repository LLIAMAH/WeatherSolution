using WeatherAPI.DB.Entities;
using WeatherAPI.DB.Reps.Interfaces;

namespace WeatherAPI.DB.Reps
{
    public class RepCountries : Rep<Country>, IRepCountries
    {
        public RepCountries(AppDbCtx ctx) : base(ctx) { }
    }

    public class RepCities : Rep<City>, IRepCities
    {
        public RepCities(AppDbCtx ctx) : base(ctx) { }
    }
}
