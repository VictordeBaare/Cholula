using System;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlateCore.Entities
{
    public class WeatherForecast : EntityBase
    {        
        [Range(typeof(DateTime), "1/1/2011", "1/1/2020", ErrorMessage = "Date is out of Range")]
        public DateTime Date { get; set; }

        [Required]
        [Range(-100, 100)]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        [StringLength(128)]
        public string Summary { get; set; }
    }
}
