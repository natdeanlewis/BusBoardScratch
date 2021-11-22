using System.Text.Json;
using RestSharp;

namespace BusBoard
{
    public class PostcodeClient
    {
        private readonly RestClient _client = new("https://api.postcodes.io/");

        public LatLong GetLatLong(string postcode)
        {
            var request = new RestRequest($"postcodes/{postcode}", DataFormat.Json);
            var response = _client.Get(request);
            var container = JsonSerializer.Deserialize<PostcodeContainer>(response.Content);
            return container.result;
        }
    }
}