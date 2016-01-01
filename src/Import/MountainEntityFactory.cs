using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.OrdnanceSurvey;
using Record = ScotlandsMountains.Import.Dobih.Record;

namespace ScotlandsMountains.Import
{
    internal class MountainEntityFactory
    {
        private readonly CountryEntityFactory _countryEntityFactory;
        private readonly AreaEntityFactory _areaEntityFactory;
        private readonly MapEntityFactory _mapEntityFactory;
        private readonly ClassificationEntityFactory _classificationEntityFactory;
        private readonly IList<MountainTuple> _tuples = new List<MountainTuple>();

        public IList<Mountain> Mountains
        {
            get { return _tuples.Select(x => x.Mountain).ToList(); }
        }

        public MountainEntityFactory(
            IDobihReader records,
            CountryEntityFactory countryEntityFactory,
            AreaEntityFactory areaEntityFactory,
            MapEntityFactory mapEntityFactory,
            ClassificationEntityFactory classificationEntityFactory)
        {
            _countryEntityFactory = countryEntityFactory;
            _areaEntityFactory = areaEntityFactory;
            _mapEntityFactory = mapEntityFactory;
            _classificationEntityFactory = classificationEntityFactory;

            _tuples = records.Records
                             .Select(x => new MountainTuple {Record = x, Mountain = CreateMountain(x)})
                             .ToList();

            foreach (var tuple in _tuples)
                SetChildCollections(tuple);
        }

        private Mountain CreateMountain(Record record)
        {
            return new Mountain
                {
                    Name = record.Name,
                    SummitDescription = String.IsNullOrEmpty(record.Feature) ? null : record.Feature,
                    SummitDetails = String.IsNullOrEmpty(record.Observations) ? null : record.Observations,
                    Children = new List<Mountain>(),
                    Height = new Height {Metres = record.Metres},
                    Prominence = ProminenceFactory.BuildFrom(record),
                    Location = LocationFactory.BuildFrom(record),
                    Country = _countryEntityFactory.GetCountry(record.Country),
                    DobihNumber = record.Number
                };
        }

        private void SetChildCollections(MountainTuple tuple)
        {
            SetParents(tuple);
            SetAreas(tuple);
            SetMaps(tuple);
            SetClassifications(tuple);
        }

        private void SetParents(MountainTuple tuple)
        {
            if (String.IsNullOrEmpty(tuple.Record.ParentNumber)) return;

            var parentNumber = Int32.Parse(tuple.Record.ParentNumber);

            if (!IsValidMountainNumber(parentNumber)) return;

            var parent = _tuples.Single(x => x.Record.Number == parentNumber).Mountain;
            parent.Children.Add(tuple.Mountain);
            tuple.Mountain.Parent = parent;
        }

        private void SetAreas(MountainTuple tuple)
        {
            var area = _areaEntityFactory.Areas.Single(x => x.Name == tuple.Record.Region);
            area.Mountains.Add(tuple.Mountain);
            tuple.Mountain.Area = area;
        }

        private void SetMaps(MountainTuple tuple)
        {
            tuple.Mountain.Maps = new List<Map>();

            if (IsIrish(tuple))
            {
                SetMaps(tuple.Record.LandrangerSheets, new[] { Constants.Discovery }, tuple);
            }
            else
            {
                SetMaps(tuple.Record.LandrangerSheets, new[] { Constants.Landranger, Constants.LandrangerActive }, tuple);
                SetMaps(tuple.Record.ExplorerSheets, new[] { Constants.Explorer, Constants.ExplorerActive }, tuple);
            }
        }

        private void SetClassifications(MountainTuple tuple)
        {
            _classificationEntityFactory.SetClassificationsFor(tuple);
        }

        private static bool IsIrish(MountainTuple tuple)
        {
            return tuple.Record.Country == "I";
        }

        private void SetMaps(IList<string> sheets, IEnumerable<string> seriesNames, MountainTuple tuple)
        {
            _mapEntityFactory.Maps.ToList()
                .Where(x => seriesNames.Contains(x.Series.Name))
                .Where(x => sheets.Contains(x.Sheet))
                .ToList()
                .ForEach(tuple.Mountain.Maps.Add);
        }

        private static bool IsValidMountainNumber(int number)
        {
            return number != 0;
        }
    }
}