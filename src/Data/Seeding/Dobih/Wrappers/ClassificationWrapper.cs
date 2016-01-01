using System;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Wrappers
{
    internal class ClassificationWrapper
    {
        public ClassificationWrapper(Func<Record,bool> isInClassification, string name)
        {
            _isInClassification = isInClassification;
            Classification = new Classification(name);
        }

        public Classification Classification { get; private set; }

        private readonly Func<Record, bool> _isInClassification;

        public bool IsMember(Record record)
        {
            return _isInClassification(record);
        }
    }
}
