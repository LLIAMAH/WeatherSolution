using Microsoft.EntityFrameworkCore;
using WeatherAPI.DB.Entities;

namespace WeatherAPI.DB
{
    public class AppDbCtx : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public AppDbCtx(DbContextOptions<AppDbCtx> options) : base(options) { }
    }
}
