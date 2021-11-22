using System.Collections.Generic;
using BusBoardScratch;

namespace BusBoard.Web.Models
{
    public class BusStopViewModel
    {
        public List<Bus> Arrivals;
        public string CommonName;
        public string StopLetter;
        public float Distance;

        public BusStopViewModel(BusStop bs)
        {
            Arrivals = bs.arrivals;
            CommonName = bs.commonName;
            StopLetter = bs.stopLetter;
            Distance = bs.distance;
            
        }
    }
}