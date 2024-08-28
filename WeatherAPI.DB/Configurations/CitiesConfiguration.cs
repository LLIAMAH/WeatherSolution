using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.DB.Entities;

namespace WeatherAPI.DB.Configurations
{
    internal class CitiesConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(new[]
            {
                new City() { Id = 1, Name = "New York", Latitude = 40.7143M, Longitude = -74.006M, CountryId = 1 },
                new City() { Id = 2, Name = "Los Angeles", Latitude = 34.0522M, Longitude = -118.2437M, CountryId = 1 },
                new City() { Id = 3, Name = "Seattle", Latitude = 47.6062M, Longitude = -122.3321M, CountryId = 1 },

                new City() { Id = 4, Name = "London", Latitude = 51.5085M, Longitude = -0.1257M, CountryId = 2 },
                new City() { Id = 5, Name = "Cambridge", Latitude = 52.2M, Longitude = 0.1167M, CountryId = 2 },
                new City() { Id = 6, Name = "Oxford", Latitude = 51.7522M, Longitude = -1.256M, CountryId = 2 },

                new City() { Id = 7, Name = "Tokyo", Latitude = 35.6895M, Longitude = 139.6917M, CountryId = 3 },
                new City() { Id = 8, Name = "Kyoto", Latitude = 35.0211M, Longitude = 135.7538M, CountryId = 3 },

                new City() { Id = 9, Name = "Paris", Latitude = 48.8534M, Longitude = 2.3488M, CountryId = 4 },
                new City() { Id = 10, Name = "Marseille", Latitude = 43.297M, Longitude = 5.3811M, CountryId = 4 },
                new City() { Id = 11, Name = "Lille", Latitude = 50.633M, Longitude = 3.0586M, CountryId = 4 }
            });
        }
    }
}
