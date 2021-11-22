using System.Text.Json;
using RestSharp;

namespace BusBoardScratch
{
    public class PostcodeApiCaller
    {
        private readonly RestClient Client = new("https://api.postcodes.io/");

        public LatLong GetLatLong(string postcode)
        {
            var request = new RestRequest($"postcodes/{postcode}", DataFormat.Json);
            var response = Client.Get(request);
            var container = JsonSerializer.Deserialize<PostcodeContainer>(response.Content);
            return container.result;
        }
    }
}