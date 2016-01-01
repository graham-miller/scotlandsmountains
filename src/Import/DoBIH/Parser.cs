using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import.Dobih
{
    public static class Parser
    {
        public static IList<Mountain> Parse(IList<Record> records)
        {
            return records
                .Select(x =>
                    new Mountain
                        {
                            Name = x.Name
                        })
                .ToList();
        }
    }
}
