namespace ScotlandsMountains.Domain.ValueObjects
{
    public class Prominence
    {
        public Height Height { get; set; }
        public Above Above { get; set; }
    }

    public class Above
    {
        public string SixFigureGridReference { get; set; }
        public string TenFigureGridReference { get; set; }
        public string Feature { get; set; }
        public Height Height { get; set; }
    }
}

