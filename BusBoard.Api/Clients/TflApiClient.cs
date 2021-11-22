using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using RestSharp;

namespace BusBoardScratch
{
    public class TflApiClient
    {
        private static readonly RestClient Client = new("https://api.tfl.gov.uk/");

        public static List<Bus> GetArrivals(string stop)
        {
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("StopPoint/" + stop + "/Arrivals", DataFormat.Json);

            var response = Client.Get(request);

            var buses = JsonSerializer.Deserialize<List<Bus>>(response.Content);

            return buses.OrderBy(b => b.timeToStation).ToList().GetRange(0, Math.Min(5, buses.Count));
        }

        public List<BusStop> GetStopcode(string lat, string lon, int radius)
        {
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request =
                new RestRequest(
                    $"Place?type=NaptanPublicBusCoachTram&lat={lat}&lon={lon}&radius={radius}",
                    DataFormat.Json);

            var response = Client.Get(request);

            var container = JsonSerializer.Deserialize<BusStopContainer>(response.Content);

            return container.places.OrderBy(bs => bs.distance).ToList().GetRange(0, 2);
        }
    }
}