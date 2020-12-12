using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyoWebAPI.Models
{
    public static class Kilometer
    {
        public static readonly double kmtoinch = 39370;
        public static readonly double kmtofeet = 3281;
        public static readonly double kmtoyard = 1094;
        public static readonly double kmtomiles = 1.609;

        public static void ToInch(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) * kmtoinch;
            if (reverse)
            {
                c.Result = double.Parse(c.UnitValue) / kmtoinch;
            }
        }

        public static void ToFeet(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) * kmtofeet;
            if (reverse)
            {
                c.Result = double.Parse(c.UnitValue) / kmtofeet;
            }
        }

        public static void ToYards(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) * kmtoyard;
            if (reverse)
            {
                c.Result = double.Parse(c.UnitValue) / kmtoyard;
            }
        }

        public static void ToMiles(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / kmtomiles;
            if (reverse)
            {
                c.Result = kmtomiles * double.Parse(c.UnitValue);
            }
        }
    }
}
