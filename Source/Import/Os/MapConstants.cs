namespace ScotlandsMountains.Import.Os
{
    public class MapConstants
    {
        public const string OrdnanceSurvey = "Ordnance Survey";
        public const string Landranger = "Landranger";
        public const string LandrangerActive = "Landranger Active";
        public const string Explorer = "Explorer";
        public const string ExplorerActive = "Explorer Active";
        public const string Discoverer = "Discoverer";
        public const string Discovery = "Discovery";
        public const decimal OneTo50K = 1 / 50000m;
        public const decimal OneTo25K = 1 / 25000m;

        public enum Region
        {
            GreatBritain,
            Ireland
        }
    }
}
