using System;
using System.Collections.Generic;
using HashidsNet;

namespace ScotlandsMountains.Domain
{
    public sealed class IdGenerator
    {
        private static volatile IdGenerator _instance;
        private static readonly object SyncRoot = new object();

        private readonly Hashids _hashids;
        private readonly List<string> _history = new List<string>();
        private int _sequence;

        private IdGenerator()
        {
            _hashids = new Hashids("Scotland's Mountains");
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

        public string GenerateId()
        {
            _sequence++;
            var id = _hashids.Encode(_sequence);

            if (_history.Contains(id))
                throw new Exception("Duplicate entity ID detected");

            _history.Add(id);
            return id;
        }
    }
}
