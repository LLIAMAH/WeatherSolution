using Microsoft.Extensions.Logging;
using WeatherAPI.DB.Reps.Interfaces;

namespace WeatherAPI.DB.Reps
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;
        private readonly AppDbCtx _ctx;

        public IRepCountries RepCountries { get; }
        public IRepCities RepCities { get; }

        public UnitOfWork(AppDbCtx ctx, ILogger<UnitOfWork> logger)
        {
            this._logger = logger;
            this._ctx = ctx;
            this.RepCountries = new RepCountries(this._ctx);
            this.RepCities = new RepCities(this._ctx);
        }
        
        public async Task<IResultBool> SaveChangesAsync()
        {
            try
            {
                await this._ctx.SaveChangesAsync();
                return new ResultBool(true);
            }
            catch (Exception ex)
            {
                this._logger.LogCritical(ex, "UnitOfWork.SaveChangesAsync failed.");
                return new ResultBool(false, ex.Message);
            }
        }

        #region IDisposable
        public void Dispose()
        {
            this._ctx?.Dispose();
        }
        #endregion
    }
}
