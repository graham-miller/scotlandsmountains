namespace ScotlandsMountains.Import.Domain
{
    public class Prominence
    {
        public Height Drop { get; set; }
        public string Feature { get; set; }
        public Height FeatureHeight { get; set; }
        public GridRef ColGridRef { get; set; }
    }
}