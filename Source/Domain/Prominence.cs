namespace ScotlandsMountains.Domain
{
    public class Prominence : Height
    {
        public string KeyCol { get; set; }
        public Height KeyColHeight { get; set; }

        public override string ToString()
        {
            var above = GridRef.IsValid(KeyCol) ? "col" : KeyCol;
            return $"{base.ToString()} above {above} ({KeyColHeight})";
        }
    }
}