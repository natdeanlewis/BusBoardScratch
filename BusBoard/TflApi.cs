using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using RestSharp;

namespace BusBoard
{
    public class TflClient
    {
        private readonly RestClient _client = new("https://api.tfl.gov.uk/");

        public List<StopPoint> GetStopsInArea(LatLong coords, int radius = 200)
        {
            var request =
                new RestRequest(
                    $"StopPoint/?lat={coords.latitude}&lon={coords.longitude}&stopTypes=NaptanPublicBusCoachTram&radius={radius}",
                    DataFormat.Json);

            var response = _client.Get(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new TflApiRequestFailedException("Request returned with an error");
            }

            var stopPoints = JsonSerializer.Deserialize<StopPointGroup>(response.Content);
            
            stopPoints.stopPoints.ForEach(sp => sp.nextArrivals = GetArrivalsAtStop(sp.naptanId));

            return stopPoints.stopPoints.OrderBy(sp => sp.distance).ToList();
        }

        public List<ArrivalPrediction> GetArrivalsAtStop(string stopCode)
        {
            var request = new RestRequest($"StopPoint/{stopCode}/Arrivals", DataFormat.Json);

            var response = _client.Get(request);
            
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new TflApiRequestFailedException("Request returned with an error");
            }
            
            var arrivals = JsonSerializer.Deserialize<List<ArrivalPrediction>>(response.Content);

            return arrivals.OrderBy(b => b.timeToStation).ToList();
        }
    }
}