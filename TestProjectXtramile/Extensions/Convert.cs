using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectXtramile.Extensions
{
    public static class ConvertDegrees
    {
        public static double ToCelcius(double input)
        {
            return input - 273;
        }

        public static double Tofahrenheit(double input)
        {
            return input * 18 / 10 + 32;
        }
    }
}
