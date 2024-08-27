using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.DB.Entities
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Country : BaseEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; } = string.Empty;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual ICollection<City> Cities { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
