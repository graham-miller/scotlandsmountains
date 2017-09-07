using System;
using System.Collections.Generic;
using HashidsNet;
using Newtonsoft.Json;

namespace ScotlandsMountains.Import.Domain
{
    public abstract class HasKey
    {
        private static readonly KeyGenerator KeyGenerator = new KeyGenerator();

        protected HasKey()
        {
            Key = KeyGenerator.GenerateKeyFor(GetType());
        }

        [JsonIgnore]
        public string Key { get; private set; }
    }

    public class KeyGenerator
    {
        private readonly object _lockObject = new object();

        public string GenerateKeyFor(Type type)
        {
            lock (_lockObject)
            {
                if (!_keyGeneratorByType.ContainsKey(type))
                    _keyGeneratorByType.Add(type, new KeyGeneratorForType(type));

                return _keyGeneratorByType[type].GenerateKey();
            }
        }

        private readonly IDictionary<Type, KeyGeneratorForType> _keyGeneratorByType = new Dictionary<Type, KeyGeneratorForType>();
    }

    public class KeyGeneratorForType
    {
        public KeyGeneratorForType(Type type)
        {
            _hashids = new Hashids(type.Name, 8);
        }

        public string GenerateKey()
        {
            return _hashids.Encode(++_currentId);
        }

        private readonly Hashids _hashids;
        private int _currentId = 0;
    }
}