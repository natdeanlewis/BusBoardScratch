using System;

namespace BusBoardScratch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nextFive = TflApiCaller.GetArrivals("490008660N");

            foreach (var bus in nextFive) Console.WriteLine(bus);
            
            Console.WriteLine(PostcodeApiCaller.GetLatLong("CB241AE"));
        }
    }
}