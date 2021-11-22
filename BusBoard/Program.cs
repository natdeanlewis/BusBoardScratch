using System;
using System.Collections.Generic;

namespace BusBoard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pc = new PostcodeApi();
            var tfl = new TflClient();

            List<StopPoint> nearestTwoStops;
            try
            {
                var location = pc.GetLatLong("error");
                nearestTwoStops = tfl.GetStopsInArea(location).GetRange(0, 2);
            }
            catch (TflApiRequestFailedException)
            {
                Console.Error.WriteLine("Failed to retrieve stops for the given postcode.");
                return;
            }
            catch (PostcodeApiRequestFailedException)
            {
                Console.Error.WriteLine("Failed to resolve postcode.");
                return;
            }
            
            foreach (var stop in nearestTwoStops)
            {
                Console.WriteLine(stop);
                try
                {
                    foreach (var arrival in tfl.GetArrivalsAtStop(stop.naptanId))
                    {
                        Console.WriteLine(arrival);
                    }
                }
                catch (TflApiRequestFailedException)
                {
                    Console.Error.WriteLine("Failed to retrieve arrivals for this stop.");
                }
                finally
                {
                    Console.WriteLine("=======================");
                }
            }
            
        }
    }
}
