using HashidsNet;

namespace ScotlandsMountains.Import
{
    public interface IIdGenerator
    {
        string Generate();
        string Generate(int number);
    }

    public sealed class IdGenerator : IIdGenerator
    {
        private const string Salt = "Scotland's Mountains Import";
        private const int MinHashLength = 8;

        private int _sequence;
        private readonly Hashids _hashids;

        public IdGenerator(int seed)
        {
            _sequence = seed;
            _hashids = new Hashids(Salt, MinHashLength);
        }

        public string Generate()
        {
            return _hashids.Encode(_sequence++);
        }

        public string Generate(int number)
        {
            return _hashids.Encode(number);
        }
    }
}
