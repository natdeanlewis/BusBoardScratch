using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusBoard
{
    public class StopPoint
    {
        public string commonName { get; set; }
        public decimal distance { get; set; }
        public string naptanId { get; set; }
        public string stopLetter { get; set; }

        public override string ToString()
        {
            return stopLetter == null ? $"Stop {commonName} is {distance:F0}m away." : $"Stop {commonName} ({stopLetter}) is {distance:F0}m away.";
        }
        
        public List<ArrivalPrediction> nextArrivals { get; set; }
    }
}