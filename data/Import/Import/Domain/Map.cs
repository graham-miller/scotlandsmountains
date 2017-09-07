using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Import.Extensions;

namespace ScotlandsMountains.Import.Domain
{
    public class Map : HasKey
    {
        public static IList<Map> Build(IList<DobihRecord> dobihRecords)
        {
            var landrangerMaps = dobihRecords
                .Where(x => x.Country != Ireland)
                .SelectMany(x => x.Map1To50000.SplitMapCodes())
                .Distinct()
                .Select(x => new Map(x, OrdnanceSurvey, Landranger, Scale1To50000));

            var explorerMaps = dobihRecords
                .Where(x => x.Country != Ireland)
                .SelectMany(x => x.Map1To25000.SplitMapCodes())
                .Distinct()
                .Select(x => new Map(x, OrdnanceSurvey, Explorer, Scale1To25000));

            var discovererMaps = dobihRecords
                .Where(x => x.Country == Ireland)
                .SelectMany(x => x.Map1To50000.SplitMapCodes())
                .Distinct()
                .Where(x => DiscovererCodes.Contains(x))
                .Select(x => new Map(x, OrdnanceSurveyIreland, Discoverer, Scale1To50000));

            var discoveryMaps = dobihRecords
                .Where(x => x.Country == Ireland)
                .SelectMany(x => x.Map1To50000.SplitMapCodes())
                .Distinct()
                .Where(x => !DiscovererCodes.Contains(x))
                .Select(x => new Map(x, OrdnanceSurveyIreland, Discovery, Scale1To50000));

            return landrangerMaps.Concat(explorerMaps).Concat(discovererMaps).Concat(discoveryMaps).ToList();
        }

        private Map(string code, string publisher, string series, decimal scale)
        {
            Code = code;
            Publisher = publisher;
            Series = series;
            Scale = scale;
        }

        public string Code { get; set; }
        public string Publisher { get; set; }
        public string Series { get; set; }
        public decimal Scale { get; set; }

        public const string Ireland = "I";
        public const string OrdnanceSurvey = "Ordnance Survey";
        public const string Landranger = "Landranger";
        public const string Explorer = "Explorer";
        public const string OrdnanceSurveyIreland = "Ordnance Survey Ireland";
        public const string Discovery = "Discovery";
        public const string Discoverer = "Discoverer";
        public const decimal Scale1To50000 = 0.00002m;
        public const decimal Scale1To25000 = 0.00004m;

        private static readonly string[] DiscovererCodes = { "4", "5", "7", "8", "9", "12", "13", "14", "15", "17", "18", "19", "20", "21", "26", "27", "28", "29" };
    }
}
