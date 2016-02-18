using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.ImportConsole.OrdnanceSurvey
{
    public class Reader
    {
        public Reader(
            string explorerPath,
            string explorerActivePath,
            string landrangerPath,
            string landrangerActivePath)
        {
            _explorerPath = explorerPath;
            _explorerActivePath = explorerActivePath;
            _landrangerPath = landrangerPath;
            _landrangerActivePath = landrangerActivePath;
        }

        public IList<Map> Read()
        {
            Read(_explorerPath, Explorer, Scale1To25000);
            Read(_explorerActivePath, ExplorerActive, Scale1To25000);
            Read(_landrangerPath, Landranger, Scale1To50000);
            Read(_landrangerActivePath, LandrangerActive, Scale1To50000);
            return _maps;
        }

        private void Read(string path, string series, decimal scale)
        {
            var lineIndex = 0;
            var lines = File.ReadAllLines(path);

            while (lineIndex < lines.Length)
            {
                var line = string.Empty;

                do
                {
                    var nextLine = lines[lineIndex].Trim();
                    line = Combine(line, nextLine);
                    lineIndex++;
                } while (DoesNotEndWithIsbn(line));

                var firstSpaceIndex = line.IndexOf(Space);
                var lastSpaceIndex = line.LastIndexOf(Space);

                _id++;
                var code = line.Substring(0, firstSpaceIndex);
                var name = line.Substring(firstSpaceIndex + 1, lastSpaceIndex - firstSpaceIndex - 1);
                var isbn = line.Substring(lastSpaceIndex + 1);

                _maps.Add(new Map
                {
                    Id = _id,
                    Publisher = Publisher,
                    Series = series,
                    Scale = scale,
                    Code = code,
                    Name = name,
                    Isbn = isbn
                });
            }
        }

        private static bool DoesNotEndWithIsbn(string line)
        {
            var toTest = line.Trim();

            if (line.Contains(Space))
                toTest = line.Substring(line.LastIndexOf(Space, StringComparison.Ordinal) + 1);

            long notUsed;
            var doesNotEndWithIsbn = !(long.TryParse(toTest, out notUsed) && toTest.Length >= 10);
            return doesNotEndWithIsbn;
        }

        private static string Combine(string line1, string line2)
        {
            if (!string.IsNullOrWhiteSpace(line1))
            {
                var lastChar = line1.Last();
                if (lastChar != '-')
                    return line1 + Space + line2;
            }

            return line1 + line2;
        }

        private const string Space = " ";
        private const string Publisher = "Ordnance Survey";
        private const string Explorer = "Explorer";
        private const string ExplorerActive = "Explorer Active";
        private const string Landranger = "Landranger";
        private const string LandrangerActive = "Landranger Active";
        private const decimal Scale1To25000 = 0.00004m;
        private const decimal Scale1To50000 = 0.00002m;

        private int _id = 0;
        private List<Map> _maps = new List<Map>();
        private readonly string _explorerPath;
        private readonly string _explorerActivePath;
        private readonly string _landrangerPath;
        private readonly string _landrangerActivePath;
    }
}
