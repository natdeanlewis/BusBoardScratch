using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using RestSharp;

namespace BusBoardScratch
{
    public class TflLatLongApiCaller
    {
        private readonly RestClient Client = new("https://api.tfl.gov.uk/");

        public List<BusStop> GetStopcode(string lat, string lon)
        {
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request =
                new RestRequest(
                    $"https://api.tfl.gov.uk/Place?type=NaptanPublicBusCoachTram&lat={lat}&lon={lon}&radius=200",
                    DataFormat.Json);

            var response = Client.Get(request);

            var container = JsonSerializer.Deserialize<BusStopContainer>(response.Content);

            // return buses.OrderBy(b => b.timeToStation).ToList().GetRange(0, 5);
            return container.places.OrderBy(b => b.distance).ToList().GetRange(0, 2);
        }
    }
}