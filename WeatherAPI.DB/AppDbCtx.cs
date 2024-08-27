using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.DB
{
    public class AppDbCtx : DbContext
    {
        public AppDbCtx(DbContextOptions<AppDbCtx> options)
            : base(options)
        {
        }
    }
}
