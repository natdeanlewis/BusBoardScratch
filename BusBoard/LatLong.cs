namespace BusBoard
{
    public class LatLong
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

        public override string ToString()
        {
            return $"({latitude}, {longitude})";
        }
    }
}