using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Net.Mime;
using RestSharp;

namespace BusBoardScratch
{
    public class APICaller
    {
        public static List<Bus> GetArrivals(string stop)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("StopPoint/" + stop + "/Arrivals", DataFormat.Json);

            var response = client.Get(request);

            var buses = JsonSerializer.Deserialize<List<Bus>>(response.Content);

            return buses.OrderBy(b => b.timeToStation).ToList().GetRange(0, 5);
        }
    }
}