using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.DB.Entities
{
    public class Country : BaseEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; } = string.Empty;
    }
}
