using Microsoft.EntityFrameworkCore;
using WeatherAPI.DB.Configurations;
using WeatherAPI.DB.Entities;

namespace WeatherAPI.DB
{
    public class AppDbCtx : DbContext
    {
        // ReSharper disable once UnusedMember.Global
        public DbSet<Country> Countries { get; set; }
        // ReSharper disable once UnusedMember.Global
        public DbSet<City> Cities { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public AppDbCtx(DbContextOptions<AppDbCtx> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new CitiesConfiguration());
        }
    }
}
