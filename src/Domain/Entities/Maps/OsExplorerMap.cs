namespace ScotlandsMountains.Domain.Entities.Maps
{
    public class OsExplorerMap : OsMap
    {
        public override decimal Scale { get { return MapScale.OneTo25000; } }

        public override string Series { get { return "Explorer"; } }
    }
}