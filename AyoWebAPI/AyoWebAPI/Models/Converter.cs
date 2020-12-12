using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyoWebAPI.Models
{
    public class Converter
    {
        public int? ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public string UnitValue { get; set; }
        public double Result { get; set; }
        public DateTime RequestDate { get; set; }
    }

    public class Convert
    {
        public bool IsImperial { get; set; }
        public string MetricUnit { get; set;  }
        public string ImperialUnit { get; set; }
        public string UnitValue { get; set; }
    }

    public class ConvertCalc
    {
        

        public Converter Create(Convert c)
        {
            Converter retval = new Converter();
            retval.ID = null;
            retval.UnitValue = c.UnitValue.Replace('.',',');
            if (c.IsImperial)
            {
                retval.From = "Imperial";
                retval.To = "Metric";
                retval.FromUnit = c.ImperialUnit;
                retval.ToUnit = c.MetricUnit;
                ConvertImperial(retval);
            }
            else
            {
                retval.From = "Metric";
                retval.To = "Imperial";
                retval.FromUnit = c.MetricUnit;
                retval.ToUnit = c.ImperialUnit;
                ConvertMetric(retval);
            }
            
            retval.RequestDate = DateTime.Now;
            return retval;
        }

        public void ConvertMetric(Converter c)
        {
            if(c.FromUnit == "millimeter")
            {
                switch (c.ToUnit)
                {
                    case "inches":
                        Millimeter.ToInch(c, false);
                    break;
                    case "feet":
                        Millimeter.ToFeet(c, false);
                    break;
                    case "yards":
                        Millimeter.ToYards(c, false);
                        break;
                    case "miles":
                        Millimeter.ToMiles(c, false);
                        break;
                    default:
                    break;
                }
            }
            else if(c.FromUnit == "centimeter")
            {
                switch (c.ToUnit)
                {
                    case "inches":
                        Centimeter.ToInch(c, false);
                        break;
                    case "feet":
                        Centimeter.ToFeet(c, false);
                        break;
                    case "yards":
                        Centimeter.ToYards(c, false);
                        break;
                    case "miles":
                        Centimeter.ToMiles(c, false);
                        break;
                    default:
                        break;
                }
            }
            else if (c.FromUnit == "meter")
            {
                switch (c.ToUnit)
                {
                    case "inches":
                        Meter.ToInch(c, false);
                        break;
                    case "feet":
                        Meter.ToFeet(c, false);
                        break;
                    case "yards":
                        Meter.ToYards(c, false);
                        break;
                    case "miles":
                        Meter.ToMiles(c, false);
                        break;
                    default:
                        break;
                }
            }
            else if (c.FromUnit == "kilometer")
            {
                switch (c.ToUnit)
                {
                    case "inches":
                        Kilometer.ToInch(c, false);
                        break;
                    case "feet":
                        Kilometer.ToFeet(c, false);
                        break;
                    case "yards":
                        Kilometer.ToYards(c, false);
                        break;
                    case "miles":
                        Kilometer.ToMiles(c, false);
                        break;
                    default:
                        break;
                }
            }
            else if (c.FromUnit == "celcius")
            {
                Celcius.ToF(c, false);
            }
        }

        public void ConvertImperial(Converter c)
        {
            if (c.FromUnit == "inches")
            {
                switch (c.ToUnit)
                {
                    case "millimeter":
                        Millimeter.ToInch(c, true);
                        break;
                    case "centimeter":
                        Centimeter.ToInch(c, true);
                        break;
                    case "meter":
                        Meter.ToInch(c, true);
                        break;
                    case "kilometer":
                        Kilometer.ToInch(c, true);
                        break;
                    default:
                        break;
                }
            }
            else if (c.FromUnit == "feet")
            {
                switch (c.ToUnit)
                {
                    case "millimeter":
                        Millimeter.ToFeet(c, true);
                        break;
                    case "centimeter":
                        Centimeter.ToFeet(c, true);
                        break;
                    case "meter":
                        Meter.ToFeet(c, true);
                        break;
                    case "kilometer":
                        Kilometer.ToFeet(c, true);
                        break;
                    default:
                        break;
                }
            }
            else if (c.FromUnit == "yards")
            {
                switch (c.ToUnit)
                {
                    case "millimeter":
                        Millimeter.ToYards(c, true);
                        break;
                    case "centimeter":
                        Centimeter.ToYards(c, true);
                        break;
                    case "meter":
                        Meter.ToYards(c, true);
                        break;
                    case "kilometer":
                        Kilometer.ToYards(c, true);
                        break;
                    default:
                        break;
                }
            }
            else if (c.FromUnit == "miles")
            {
                switch (c.ToUnit)
                {
                    case "millimeter":
                        Millimeter.ToMiles(c, true);
                        break;
                    case "centimeter":
                        Centimeter.ToMiles(c, true);
                        break;
                    case "meter":
                        Meter.ToMiles(c, true);
                        break;
                    case "kilometer":
                        Kilometer.ToMiles(c, true);
                        break;
                    default:
                        break;
                }
            }
            else if (c.FromUnit == "celcius")
            {
                Celcius.ToF(c, true);
            }
        }
    }
}
