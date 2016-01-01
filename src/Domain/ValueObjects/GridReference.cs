namespace ScotlandsMountains.Domain.ValueObjects
{
    public class GridReference
    {
        protected GridReference() { }

        public GridReference(string sixFigure, string tenFigure = null)
        {
            SixFigure = sixFigure;
            TenFigure = tenFigure;
        }

        public string SixFigure { get; set; }

        public string TenFigure { get; set; }
    }
}