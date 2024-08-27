namespace WeatherAPI.DB.Reps.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepCountries RepCountries { get; }
        IRepCities RepCities { get; }

        Task<bool> SaveChangesAsync();
    }
}
