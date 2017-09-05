using System;
using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Import.Domain
{
    public class Map : HasKey
    {
        public static IList<Map> Build(IList<DobihRecord> dobihRecords)
        {
            var landrangerMaps = dobihRecords
                .Where(x => x.Country != Ireland)
                .SelectMany(x => SplitSpaceSeparatedString(x.Map1To50000))
                .Distinct()
                .Select(BuildLandranger);

            var explorerMaps = dobihRecords
                .Where(x => x.Country != Ireland)
                .SelectMany(x => SplitSpaceSeparatedString(x.Map1To25000))
                .Distinct()
                .Select(BuildExplorer);

            var discovererMaps = dobihRecords
                .Where(x => x.Country == Ireland)
                .SelectMany(x => SplitSpaceSeparatedString(x.Map1To50000))
                .Distinct()
                .Where(x => DiscovererCodes.Contains(x))
                .Select(BuildDiscoverer);

            var discoveryMaps = dobihRecords
                .Where(x => x.Country == Ireland)
                .SelectMany(x => SplitSpaceSeparatedString(x.Map1To50000))
                .Distinct()
                .Where(x => !DiscovererCodes.Contains(x))
                .Select(BuildDiscovery);

            return landrangerMaps.Concat(explorerMaps).Concat(discovererMaps).Concat(discoveryMaps).ToList();
        }

        public string Code { get; set; }
        public string Publisher { get; set; }
        public string Series { get; set; }
        public double Scale { get; set; }

        private static Map BuildLandranger(string code)
        {
            return new Map
            {
                Code = code,
                Publisher = "Ordnance Survey",
                Series = "Landranger",
                Scale = 0.00002
            };
        }

        private static Map BuildExplorer(string code)
        {
            return new Map
            {
                Code = code,
                Publisher = "Ordnance Survey",
                Series = "Explorer",
                Scale = 0.00004
            };
        }

        private static Map BuildDiscovery(string code)
        {
            return new Map
            {
                Code = code,
                Publisher = "Ordnance Survey Ireland",
                Series = "Discovery",
                Scale = 0.00002
            };
        }

        private static Map BuildDiscoverer(string code)
        {
            return new Map
            {
                Code = code,
                Publisher = "Ordnance Survey Ireland",
                Series = "Discoverer",
                Scale = 0.00002
            };
        }

        private static string[] SplitSpaceSeparatedString(string s)
        {
            return s.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimStart('0')).ToArray();
        }

        private static readonly string[] DiscovererCodes = {"4", "5", "7", "8", "9", "12", "13", "14", "15", "17", "18", "19", "20", "21", "26", "27", "28", "29"};

        private const string Ireland = "I";
    }
}
