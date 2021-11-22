using System;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var pc = new PostcodeClient();
            var tfl = new TflClient();

            tfl.GetStopCodes(pc.GetLatLong("NW5 1TL"));
        }
    }
}