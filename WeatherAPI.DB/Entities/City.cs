using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.DB.Entities
{
    public class City
    {
        [Required, MaxLength(256)]
        public string Name { get; set; } = string.Empty;
    }
}
