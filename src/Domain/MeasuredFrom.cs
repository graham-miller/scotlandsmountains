namespace ScotlandsMountains.Domain
{
    public abstract class MeasuredFrom
    {
        public virtual Height Height { get; set; }
    }

    public class MeasuredFromFeature : MeasuredFrom
    {
        public virtual string Description { get; set; }
    }

    public class MeasuredFromCol : MeasuredFrom
    {
        public virtual string GridReference { get; set; }
    }
}