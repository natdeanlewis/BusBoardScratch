using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using RestSharp;

namespace BusBoard
{
    public class TflClient
    {
        private readonly RestClient _client = new("https://api.tfl.gov.uk/");

        public string GetStopCodes(LatLong coords, int radius = 200)
        {
            var request = new RestRequest($"StopPoint/?lat={coords.latitude}&lon={coords.longitude}&stopTypes=NaptanPublicBusCoachTram&radius={radius}", DataFormat.Json);

            var response = _client.Get(request);

            Console.WriteLine(response.Content);

            return "";
        }

        public List<Arrival> GetArrivals(string stopCode)
        {
            var request = new RestRequest($"StopPoint/{stopCode}/Arrivals", DataFormat.Json);

            var response = _client.Get(request);

            var arrivals = JsonSerializer.Deserialize<List<Arrival>>(response.Content);

            return arrivals.OrderBy(b => b.timeToStation).ToList().GetRange(0, 5);
        }
    }
}