using System;

namespace WebApplicationDZ5
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public decimal TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / (decimal)0.5556);
        public float A { get; set; }
        public long B { get; set; }
        

        public string Summary { get; set; }
    }
}
