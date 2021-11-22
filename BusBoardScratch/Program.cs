using System;

namespace BusBoardScratch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var postcodeClient = new PostcodeApiCaller();

            var latLong = postcodeClient.GetLatLong("NW51PB");

            var latLongClient = new TflLatLongApiCaller();

            var places = latLongClient.GetStopcode(latLong.latitude.ToString(), latLong.longitude.ToString());

            foreach (var stop in places)
            {
                Console.WriteLine();
                Console.WriteLine(stop);
                Console.WriteLine("Here are the next 5 buses from this stop:");
                var nextFive = TflArrivalApiCaller.GetArrivals(stop.naptanId);

                foreach (var bus in nextFive) Console.WriteLine(bus);
            }
        }
    }
}