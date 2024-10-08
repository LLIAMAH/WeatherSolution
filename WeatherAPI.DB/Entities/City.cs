﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.DB.Entities
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    [Index( nameof(Name), nameof(CountryId), IsUnique = true)]
    public class City : BaseEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; } = string.Empty;

        [Required, Column(TypeName = "decimal(9, 6)")]
        public decimal Latitude { get; set; }

        [Required, Column(TypeName = "decimal(9, 6)")]
        public decimal Longitude { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [ForeignKey(nameof(Country))]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<TemperatureData> TemperatureData { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
