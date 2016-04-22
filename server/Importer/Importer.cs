using System.Collections.Generic;
using ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills;
using ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills.EntityFactories;
using ScotlandsMountains.Domain.Entities;
using DobihReader = ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills.Reader;
using OsReader = ScotlandsMountains.Importer.OrdnanceSurvey.Reader;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace ScotlandsMountains.Importer
{
    public class ImportProcess
    {
        private static readonly string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\GitHub\ScotlandsMountains\Resources";
        private static readonly string FirebaseJsonPath = BasePath + @"\FirebaseData\firebase.json";
        private static readonly string SearchJsonPath = BasePath + @"\SearchData\search.json";

        public void Run()
        {
            CreateHashIds();
            ReadDobihRecords();
            ReadMapRecords();
            CreateEntities();
            WriteFirebaseFile();
            WriteSearchFile();
        }

        private void CreateHashIds()
        {
            _hashIds = new HashIds();
        }

        private void ReadDobihRecords()
        {
            _records = new DobihReader().Read();
        }

        private void ReadMapRecords()
        {
            _maps = new OsReader().Read();
            foreach (var map in _maps)
                map.Key = _hashIds.Next();
        }

        private void CreateEntities()
        {
            _entityFactory = new EntityFactory(_records, _maps, _hashIds);
        }

        private void WriteFirebaseFile()
        {
            FilebaseFileWriter.Write(_entityFactory, FirebaseJsonPath);
        }

        private void WriteSearchFile()
        {
            File.WriteAllText(SearchJsonPath,
                JsonConvert.SerializeObject(
                    _entityFactory,
                    Formatting.Indented,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }

        private HashIds _hashIds;
        private IList<Record> _records;
        private IList<Map> _maps;
        private EntityFactory _entityFactory;
    }
}
