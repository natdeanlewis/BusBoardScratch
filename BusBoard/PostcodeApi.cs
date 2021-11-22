using System;
using System.Net;
using System.Text.Json;
using RestSharp;

namespace BusBoard
{
    public class PostcodeApi
    {
        private readonly RestClient _client = new("https://api.postcodes.io/");

        public LatLong GetLatLong(string postcode)
        {
            var request = new RestRequest($"postcodes/{postcode}", DataFormat.Json);
            var response = _client.Get(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new PostcodeApiRequestFailedException("Request returned with an error");
            }
            var container = JsonSerializer.Deserialize<PostcodeContainer>(response.Content);
            return container.result;
        }
    }
}