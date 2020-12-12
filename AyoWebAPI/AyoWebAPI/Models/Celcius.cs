using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyoWebAPI.Models
{
    public static class Celcius
    {
        public static void ToF(Converter c, bool reverse)
        {
            c.Result = (double.Parse(c.UnitValue) * 9/5) + 32;
            if (reverse)
            {
                c.Result = (double.Parse(c.UnitValue) - 32) * 5/9;
            }
        }
    }
}
