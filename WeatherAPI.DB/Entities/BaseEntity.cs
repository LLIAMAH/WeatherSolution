using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.DB.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
