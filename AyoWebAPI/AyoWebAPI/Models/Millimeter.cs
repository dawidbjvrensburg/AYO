using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyoWebAPI.Models
{
    public static class Millimeter
    {
        public static readonly double mmtoinch = 25.4;
        public static readonly double mmtofeet = 305;
        public static readonly double mmtoyard = 914;
        public static readonly double mmtomiles = 0.00000062137;
        public static void ToInch(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / mmtoinch;
            if (reverse)
            {
                c.Result = mmtoinch * double.Parse(c.UnitValue);
            }
        }

        public static void ToFeet(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / mmtofeet;
            if (reverse)
            {
                c.Result = mmtofeet * double.Parse(c.UnitValue);
            }
        }

        public static void ToYards(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / mmtoyard;
            if (reverse)
            {
                c.Result = mmtoyard * double.Parse(c.UnitValue);
            }
        }

        public static void ToMiles(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) * mmtomiles;
            if (reverse)
            {
                c.Result = mmtomiles * double.Parse(c.UnitValue);
            }
        }
    }
}
