using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temperature.Model
{
    public static class TemperatureConverter
    {
        public static int CelsiusToFahrenheit(this int degreesC)
        {
            return (int)((double)degreesC * 1.8 + 32);
        }
        public static int FahrenheitToCelsius(this int degreesF)
        {
            return (int)((double)(degreesF - 32) * 5/9);
        }
    }
}