using System;

namespace ScotlandsMountains.Data.Seeding.OrdnanceSurvey
{
    internal class Record
    {
        public Record(string raw)
        {
            var firstSpaceAt = raw.IndexOf(" ", StringComparison.Ordinal);
            var lastSpaceAt = raw.LastIndexOf(" ", StringComparison.Ordinal);

            Code = raw.Substring(0, firstSpaceAt);
            Name = raw.Substring(firstSpaceAt + 1, lastSpaceAt - firstSpaceAt);
            Isbn = raw.Substring(lastSpaceAt + 1);
        }

        public string Code { get; private set; }

        public string Name { get; private set; }

        public string Isbn { get; private set; }
    }
}
