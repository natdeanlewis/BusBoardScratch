namespace BusBoardScratch
{
    public class BusStop
    {
        public string naptanId { get; set; }
        public string stopLetter { get; set; }
        public string commonName { get; set; }
        public float distance { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(stopLetter))
                return $"{commonName} is {(int)distance}m away.";
            return $"{commonName} (stop {stopLetter}) is {(int)distance}m away.";
        }
    }
}