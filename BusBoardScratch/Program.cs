using System;
using System.Collections.Generic;

namespace BusBoardScratch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Bus> nextFive = APICaller.GetArrivals("490008660N");

            foreach (var bus in nextFive)
            {
                Console.WriteLine(bus);
            }
            
        }
    }
}