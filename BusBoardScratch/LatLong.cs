namespace BusBoardScratch
{
    public class LatLong
    {
        public float latitude { get; set; }
        public float longitude { get; set; }

        public override string ToString()
        {
            return $"({latitude}, {longitude})";
        }
    }
}