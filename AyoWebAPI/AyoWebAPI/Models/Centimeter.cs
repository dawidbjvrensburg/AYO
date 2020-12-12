using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyoWebAPI.Models
{
    public static class Centimeter
    {
        public static readonly double cmtoinch = 2.54;
        public static readonly double cmtofeet = 30.48;
        public static readonly double cmtoyard = 91.44;
        public static readonly double cmtomiles = 160934;
        public static void ToInch(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / cmtoinch;
            if (reverse)
            {
                c.Result = cmtoinch * double.Parse(c.UnitValue);
            }
        }

        public static void ToFeet(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / cmtofeet;
            if (reverse)
            {
                c.Result = cmtofeet * double.Parse(c.UnitValue);
            }
        }

        public static void ToYards(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / cmtoyard;
            if (reverse)
            {
                c.Result = cmtoyard * double.Parse(c.UnitValue);
            }
        }

        public static void ToMiles(Converter c, bool reverse)
        {
            c.Result = double.Parse(c.UnitValue) / cmtomiles;
            if (reverse)
            {
                c.Result = cmtomiles * double.Parse(c.UnitValue);
            }
        }
    }
}
