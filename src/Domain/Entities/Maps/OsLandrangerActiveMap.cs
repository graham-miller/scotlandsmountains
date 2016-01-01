namespace ScotlandsMountains.Domain.Entities.Maps
{
    public class OsLandrangerActiveMap : OsMap
    {
        public override decimal Scale { get { return MapScale.OneTo50000; } }

        public override string Series { get { return "Landranger Active"; } }
    }
}