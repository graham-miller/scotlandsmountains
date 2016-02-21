using System;
using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.ValueTypes;
using System.Linq;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class MountainsFactory
    {
        public MountainsFactory(IList<Record> records, EntityFactory entities)
        {
            foreach (var record in records.OrderByDescending(r => decimal.Parse(r[Field.Metres])))
                Mountains.Add(new MountainFactory(record, entities).Mountain);
        }

        public IList<Mountain> Mountains { get; } = new List<Mountain>();

        private class MountainFactory
        {
            private readonly Record _record;
            private readonly EntityFactory _entities;

            public MountainFactory(Record record, EntityFactory entities)
            {
                _record = record;
                _entities = entities;

                Mountain = new Mountain
                {
                    DobihId = record[Field.Number],
                    Name = record[Field.Name],
                    Height = CreateHeight(),
                    Location = CreateLocation(),
                    Prominence = CreateProminence(),
                    SummitFeature = record[Field.Feature],
                    SummitObservations = record[Field.Observations],
                };

                CreateRelationships();
            }

            public Mountain Mountain { get; }

            private Height CreateHeight()
            {
                return new Height { Metres = double.Parse(_record[Field.Metres]) };
            }

            private Location CreateLocation()
            {
                var latitude = double.Parse(_record[Field.Latitude]);
                var longitude = double.Parse(_record[Field.Longitude]);
                var height = double.Parse(_record[Field.Metres]);

                return new Location
                {
                    Latitude = latitude,
                    Longitude = longitude,
                };
            }

            private Prominence CreateProminence()
            {
                return new Prominence
                {
                    Metres = Math.Round(double.Parse(_record[Field.Drop])),
                    KeyCol = CreateKeyCol()
                };
            }

            private KeyCol CreateKeyCol()
            {
                return new KeyCol
                {
                    Location = _record[Field.ColGridRef],
                    Height = new Height { Metres = Math.Round(double.Parse(_record[Field.ColHeight])) }
                };
            }

            private void CreateRelationships()
            {
                CreateSectionRelationships();
                CreateIslandRelationships();
                CreateCountyRelationships();
                CreateTopologicalSectionRelationships();
                CreateMapRelationships();
                CreateClassificationRelationships();
            }

            private void CreateSectionRelationships()
            {
                Mountain.Section = _entities.Sections.Single(x => x.Name == _record[Field.SectionName].SectionName());
                Mountain.Section.Mountains.Add(Mountain);
            }

            private void CreateIslandRelationships()
            {
                var island = _entities.Islands.SingleOrDefault(x => x.Name == _record[Field.Island]);
                if (island != null)
                {
                    Mountain.Island = island;
                    island.Mountains.Add(Mountain);
                }
            }

            private void CreateCountyRelationships()
            {
                var countyNames = _record[Field.County].SplitCounties();
                foreach (var county in _entities.Counties.Where(x => countyNames.Contains(x.Name)).ToList())
                {
                    Mountain.Counties.Add(county);
                    county.Mountains.Add(Mountain);
                }
            }

            private void CreateTopologicalSectionRelationships()
            {
                Mountain.TopologicalSection = _entities.TopologicalSections.Single(x => x.Name == _record[Field.TopoSection].SectionName());
                Mountain.TopologicalSection.Mountains.Add(Mountain);
            }

            private void CreateMapRelationships()
            {
                var mapCodes = _record[Field.Map1To25K].SplitMaps().Concat(_record[Field.Map1To50K].SplitMaps());
                foreach(var map in _entities.Maps.Where(x => mapCodes.Contains(x.Code)))
                {
                    Mountain.Maps.Add(map);
                    map.Mountains.Add(Mountain);
                }
            }

            private void CreateClassificationRelationships()
            {
                CreateClassificationRelationship(_record[Field.Munro], Classification.Munro);
                CreateClassificationRelationship(_record[Field.MunroTop], Classification.MunroTop);
                CreateClassificationRelationship(_record[Field.Corbett], Classification.Corbett);
                CreateClassificationRelationship(_record[Field.CorbettTop], Classification.CorbettTop);
                CreateClassificationRelationship(_record[Field.Graham], Classification.Graham);
                CreateClassificationRelationship(_record[Field.GrahamTop], Classification.GrahamTop);
                CreateClassificationRelationship(_record[Field.Murdo], Classification.Murdo);
                CreateClassificationRelationship(_record[Field.Donald], Classification.Donald);
                CreateClassificationRelationship(_record[Field.DonaldDewey], Classification.DonaldDewey);
                CreateClassificationRelationship(_record[Field.HighlandFive], Classification.HighlandFive);
            }

            private void CreateClassificationRelationship(string fieldValue, string classificationName)
            {
                if (fieldValue.IsTrue())
                {
                    var classification = _entities.Classifications.Single(x => x.Name == classificationName);
                    Mountain.Classifications.Add(classification);
                    classification.Mountains.Add(Mountain);
                }
            }
        }
    }
}