using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.DB.Entities
{
    public class TemperatureData : BaseEntity
    {
        public DateTime DateTime { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        [ForeignKey(nameof(Country))]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }


        [ForeignKey(nameof(City))]
        public long CityId { get; set; }
        public virtual City City { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    }
}
