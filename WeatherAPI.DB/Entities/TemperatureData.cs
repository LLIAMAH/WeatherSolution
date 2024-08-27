using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.DB.Entities
{
    public class TemperatureData : BaseEntity
    {
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(Country))]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey(nameof(City))]
        public long CityId { get; set; }
        public virtual City City { get; set; }
    }
}
