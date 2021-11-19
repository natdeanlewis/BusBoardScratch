using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using RestSharp;

namespace BusBoardScratch
{
    public static class TflApiCaller
    {
        private static readonly RestClient Client = new("https://api.tfl.gov.uk/");

        public static List<Bus> GetArrivals(string stop)
        {
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("StopPoint/" + stop + "/Arrivals", DataFormat.Json);

            var response = Client.Get(request);

            var buses = JsonSerializer.Deserialize<List<Bus>>(response.Content);

            return buses.OrderBy(b => b.timeToStation).ToList().GetRange(0, 5);
        }
    }
}