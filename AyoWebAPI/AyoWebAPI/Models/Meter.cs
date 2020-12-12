using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyoWebAPI.Models
{
    public static class Meter
    {
        public static readonly double mtoinch = 39.37;
        public static readonly double mtofeet = 3.281;
        public static readonly double mtoyard = 1.094;
        public static readonly double mtomiles = 1609;

        public static void ToInch(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) * mtoinch;
            if (reverse)
            {
                c.Result = double.Parse(c.UnitValue) / mtoinch;
            }
        }

        public static void ToFeet(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) * mtofeet;
            if (reverse)
            {
                c.Result = double.Parse(c.UnitValue) / mtofeet;
            }
        }

        public static void ToYards(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) * mtoyard;
            if (reverse)
            {
                c.Result = double.Parse(c.UnitValue) / mtoyard;
            }
        }

        public static void ToMiles(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / mtomiles;
            if (reverse)
            {
                c.Result = mtomiles * double.Parse(c.UnitValue);
            }
        }
    }

}
