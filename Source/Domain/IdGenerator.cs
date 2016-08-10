using HashidsNet;

namespace ScotlandsMountains.Domain
{
    public sealed class IdGenerator
    {
        private const string Salt = "Scotland's Mountains";
        private const int MinHashLength = 8;

        private static volatile IdGenerator _instance;
        private static readonly object SyncRoot = new object();

        private readonly Hashids _hashids;

        private IdGenerator()
        {
            _hashids = new Hashids(Salt, MinHashLength);
        }

        public static IdGenerator Instance
        {
            get
            {
                if (_instance == null) CreateInstance();

                return _instance;
            }
        }

        private static void CreateInstance()
        {
            lock (SyncRoot)
            {
                if (_instance == null)
                    _instance = new IdGenerator();
            }
        }

        public string GenerateId(int number)
        {
            return _hashids.Encode(number);
        }
    }
}
