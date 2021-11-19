using System;
using System.Globalization;

namespace BusBoardScratch
{
    public class Bus
    {
        public DateTime expectedArrival { get; set; }

        public override string ToString()
        {
            return expectedArrival.ToString(CultureInfo.CurrentCulture);
        }
    }
}