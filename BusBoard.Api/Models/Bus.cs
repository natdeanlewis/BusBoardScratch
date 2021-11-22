using System;

namespace BusBoardScratch
{
    public class Bus
    {
        public DateTime expectedArrival { get; set; }
        public string lineName { get; set; }
        public string destinationName { get; set; }
        public int timeToStation { get; set; }
        public DateTime timeToLive { get; set; }


        public override string ToString()
        {
            // return expectedArrival.ToString(CultureInfo.CurrentCulture);
            return
                $"The number {lineName} to {destinationName} is expected to arrive at {expectedArrival.ToShortTimeString()}.";
        }
    }
}