using System.Collections.Generic;
using ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills;
using ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills.EntityFactories;
using ScotlandsMountains.Domain.Entities;
using DobihReader = ScotlandsMountains.Importer.DatabaseOfBritishAndIrishHills.Reader;
using OsReader = ScotlandsMountains.Importer.OrdnanceSurvey.Reader;

namespace ScotlandsMountains.Importer
{
    public class ImportProcess
    {
        public void Run()
        {
            CreateHashIds();
            ReadDobihRecords();
            ReadMapRecords();
            CreateEntities();
            WriteFirebaseFile();
        }

        private void CreateHashIds()
        {
            _hashIds = new HashIds();
        }

        private void ReadDobihRecords()
        {
            _records = new DobihReader(ImportConfiguration.DobihCsvPath, ImportConfiguration.DobihFilter).Read();
        }

        private void ReadMapRecords()
        {
            _maps = new OsReader(ImportConfiguration.ExplorerTxtPath, ImportConfiguration.ExplorerActiveTxtPath, ImportConfiguration.LandrangerTxtPath, ImportConfiguration.LandrangerActiveTxtPath).Read();
            foreach (var map in _maps)
                map.Key = _hashIds.Next();
        }

        private void CreateEntities()
        {
            _entityFactory = new EntityFactory(_records, _maps, _hashIds);
        }

        private void WriteFirebaseFile()
        {
            FilebaseFileWriter.Write(_entityFactory, ImportConfiguration.FirebaseJsonPath);
        }

        private HashIds _hashIds;
        private IList<Record> _records;
        private IList<Map> _maps;
        private EntityFactory _entityFactory;
    }
}
