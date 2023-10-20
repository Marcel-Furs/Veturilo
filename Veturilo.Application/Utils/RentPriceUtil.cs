using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veturilo.Application.Utils
{
    public static class RentPriceUtil
    {
        public static double CountFinalPrice(DateTime start, DateTime stop)
        {
            var minues = (stop - start).TotalMinutes;
            if(minues <= 20)
            {
                return 0;
            }
            else if(minues <= 60)
            {
                return 1;
            }
            else
            {
                double hours = Math.Ceiling(minues / 60.0);
                return 1 + (hours - 1) * 3;
            }
        }
    }
}
