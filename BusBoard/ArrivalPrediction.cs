using System;

namespace BusBoard
{
    public class ArrivalPrediction
    {
        public DateTime expectedArrival { get; set; }
        public string lineName { get; set; }
        public string destinationName { get; set; }
        public int timeToStation { get; set; }
        public DateTime timeToLive { get; set; }


        public override string ToString()
        {
            return $"Expected {expectedArrival.ToShortTimeString()}: {lineName} to {destinationName}";
        }
    }
}