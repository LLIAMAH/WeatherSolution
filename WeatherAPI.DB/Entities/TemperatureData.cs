using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.DB.Entities
{
    // ReSharper disable once ClassNeverInstantiated.Global
    //[Index(nameof(CityId), nameof(DateTime), IsUnique = true)]
    public class TemperatureData : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        [ForeignKey(nameof(City))]
        public long CityId { get; set; }
        public virtual City City { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    }
}
