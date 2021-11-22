using System;
using System.Collections.Generic;
using System.Text.Json;
using RestSharp;
using System.Linq;

namespace BusBoard
{
    public class Arrival
    {
        public DateTime expectedArrival { get; set; }
        public string lineName { get; set; }
        public string destinationName { get; set; }
        public int timeToStation { get; set; }
        public DateTime timeToLive { get; set; }


        public override string ToString()
        {
            return $"{lineName} to {destinationName}: expected {expectedArrival.ToShortTimeString()}.";
        }
        
    }
}