namespace ScotlandsMountains.Domain.Entities.Maps
{
    public class MapScale
    {
        public static readonly decimal OneTo25000 = decimal.Divide(1, 25000);
        public static readonly decimal OneTo50000 = decimal.Divide(1, 50000);
    }
}