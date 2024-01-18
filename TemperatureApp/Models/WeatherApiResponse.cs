﻿namespace TemperatureApp.Models
{
    public class WeatherApiResponse
    {
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public double TemperatureCelsius { get; set; }
        public double TemperatureFahrenheit => TemperatureCelsius * 9 / 5 + 32;
    }
}