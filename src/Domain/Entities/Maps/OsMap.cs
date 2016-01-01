namespace ScotlandsMountains.Domain.Entities.Maps
{
    public abstract class OsMap : Map
    {
        public override string Publisher { get { return "Ordnance Survey"; } }
    }
}