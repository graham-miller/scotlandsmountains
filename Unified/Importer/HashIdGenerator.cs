using System;
using System.Collections.Generic;
using System.Linq;
using HashidsNet;

namespace ScotlandsMountains.Importer
{
    public class HashIds
    {
        public HashIds()
        {
            var hashids = new Hashids("Scotland's Mountains", Length);
            var id = 0;

            while (_hashIds.Count < 20000)
            {
                id++;
                var hash = hashids.Encode(id);

                if(hash.Length != Length)
                    throw new Exception("Not " + Length.ToString("0") + " characters");

                _hashIds.Add(hash, id);
            }
        }

        public string Next()
        {
            return _hashIds.ElementAt(_next++).Key;
        }

        private const int Length = 8;
        private readonly Dictionary<string, int> _hashIds = new Dictionary<string, int>();
        private int _next;
    }
}
