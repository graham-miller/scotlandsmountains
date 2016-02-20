using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class MountainSummariesFactory
    {
        public MountainSummariesFactory(IList<Mountain> mountains, EntityFactory entityFactory)
        {
            _mountains = mountains;
            _entityFactory = entityFactory;

            Munros = SelectByClassification(Domain.Constants.Classifications.Munro);
            MunroTops = SelectByClassification(Domain.Constants.Classifications.MunroTop);
            Corbetts = SelectByClassification(Domain.Constants.Classifications.Corbett);
            CorbettTops = SelectByClassification(Domain.Constants.Classifications.CorbettTop);
            Grahams = SelectByClassification(Domain.Constants.Classifications.Graham);
            GrahamTops = SelectByClassification(Domain.Constants.Classifications.GrahamTop);
            Murdos = SelectByClassification(Domain.Constants.Classifications.Murdo);
            Donalds = SelectByClassification(Domain.Constants.Classifications.Donald);
            DonaldDeweys = SelectByClassification(Domain.Constants.Classifications.DonaldDewey);
            HighlandFives = SelectByClassification(Domain.Constants.Classifications.HighlandFive);

            UpTo100M = SelectByHeight(0, 100);
            UpTo200M = SelectByHeight(100, 200);
            UpTo300M = SelectByHeight(200, 300);
            UpTo400M = SelectByHeight(300, 400);
            UpTo500M = SelectByHeight(400, 500);
            UpTo600M = SelectByHeight(500, 600);
            UpTo700M = SelectByHeight(600, 700);
            UpTo800M = SelectByHeight(700, 800);
            UpTo900M = SelectByHeight(800, 900);
            UpTo1000M = SelectByHeight(900, 1000);
            UpTo1100M = SelectByHeight(1000, 1100);
            UpTo1200M = SelectByHeight(1100, 1200);
            UpTo1300M = SelectByHeight(1200, 1300);
            Over1300M = SelectByHeight(1300, 1400);
        }

        public IList<MountainSummary> Munros { get; }
        public IList<MountainSummary> MunroTops { get; }
        public IList<MountainSummary> Corbetts { get; }
        public IList<MountainSummary> CorbettTops { get; }
        public IList<MountainSummary> Grahams { get; }
        public IList<MountainSummary> GrahamTops { get; }
        public IList<MountainSummary> Murdos { get; }
        public IList<MountainSummary> Donalds { get; }
        public IList<MountainSummary> DonaldDeweys { get; }
        public IList<MountainSummary> HighlandFives { get; }

        public IList<MountainSummary> UpTo100M { get; }
        public IList<MountainSummary> UpTo200M { get; }
        public IList<MountainSummary> UpTo300M { get; }
        public IList<MountainSummary> UpTo400M { get; }
        public IList<MountainSummary> UpTo500M { get; }
        public IList<MountainSummary> UpTo600M { get; }
        public IList<MountainSummary> UpTo700M { get; }
        public IList<MountainSummary> UpTo800M { get; }
        public IList<MountainSummary> UpTo900M { get; }
        public IList<MountainSummary> UpTo1000M { get; }
        public IList<MountainSummary> UpTo1100M { get; }
        public IList<MountainSummary> UpTo1200M { get; }
        public IList<MountainSummary> UpTo1300M { get; }
        public IList<MountainSummary> Over1300M { get; }

        private IList<MountainSummary> SelectByClassification(string classificationName)
        {
            var classificationKey = _entityFactory.Classifications.Single(x => x.Name == classificationName).Key;

            return _mountains
                .Where(x => x.ClassificationKeys.Contains(classificationKey))
                .OrderByDescending(x => x.Height.Metres)
                .Select(CreateMountainSummary)
                .ToList();
        }

        private IList<MountainSummary> SelectByHeight(double minHeight, double maxHeight)
        {
            return _mountains
                .Where(x => x.Height.Metres > minHeight && x.Height.Metres <= maxHeight)
                .OrderByDescending(x => x.Height.Metres)
                .Select(CreateMountainSummary)
                .ToList();
        }

        private MountainSummary CreateMountainSummary(Mountain mountain)
        {
            return new MountainSummary
            {
                Data = new object[]
                {
                    mountain.Name,
                    mountain.Height.Metres,
                    mountain.Height.Feet,
                    mountain.Location.Latitude,
                    mountain.Location.Longitude,
                    CreateClassificationsText(mountain),
                    mountain.Key
                }
            };
        }

        private string CreateClassificationsText(Mountain mountain)
        {
            var classifications = _entityFactory.Classifications
                .Where(x => mountain.ClassificationKeys.Contains(x.Key))
                .Select(x => x.Name);

            return string.Join(", ", classifications);
        }

        private IList<Mountain> _mountains;
        private EntityFactory _entityFactory;
    }
}
