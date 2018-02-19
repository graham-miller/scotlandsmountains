using System;
using System.Collections.Generic;
using HashidsNet;
using Newtonsoft.Json;

namespace ScotlandsMountains.Domain
{
    public abstract class HasId
    {
        private static readonly IdGenerator IdGenerator = new IdGenerator();

        protected HasId()
        {
            Id = IdGenerator.GenerateIdFor(GetType());
        }

        [JsonIgnore]
        public string Id { get; set; }
    }

    public class IdGenerator
    {
        private readonly object _lockObject = new object();

        public string GenerateIdFor(Type type)
        {
            lock (_lockObject)
            {
                if (!_idGeneratorByType.ContainsKey(type))
                    _idGeneratorByType.Add(type, new IdGeneratorForType(type));

                return _idGeneratorByType[type].GenerateId();
            }
        }

        private readonly IDictionary<Type, IdGeneratorForType> _idGeneratorByType = new Dictionary<Type, IdGeneratorForType>();
    }

    public class IdGeneratorForType
    {
        public IdGeneratorForType(Type type)
        {
            _hashids = new Hashids(type.Name, 8);
        }

        public string GenerateId()
        {
            return _hashids.Encode(++_currentId);
        }

        private readonly Hashids _hashids;
        private int _currentId = 0;
    }
}