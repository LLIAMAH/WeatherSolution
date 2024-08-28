namespace WeatherAPI.Models
{
    public class CountryDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CityDto>? Cities { get; set; }
    }

    public class CountryCreateDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class CityDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public CountryDto? Country { get; set; }
    }

    public class CityCreateDto
    {
        public long CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
    }
}
