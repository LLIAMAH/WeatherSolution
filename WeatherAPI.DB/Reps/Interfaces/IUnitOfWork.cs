namespace WeatherAPI.DB.Reps.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepCountries RepCountries { get; }
        IRepCities RepCities { get; }
        IRepTemperatures RepTemperatures { get; }

        Task<IResultBool> SaveChangesAsync();
    }
}
