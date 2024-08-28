using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherAPI.DB.Entities;

namespace WeatherAPI.DB.Configurations
{
    internal class CountriesConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new[]
            {
                new Country() { Id = 1, Name = "USA" },
                new Country() { Id = 2, Name = "Great Britain" },
                new Country() { Id = 3, Name = "Japan" },
                new Country() { Id = 4, Name = "France" }
            });
        }
    }
}
