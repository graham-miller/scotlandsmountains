using System.Collections.Generic;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories;
using ScotlandsMountains.Domain.Entities;
using DobihReader = ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.Reader;
using OsReader = ScotlandsMountains.Import.ConsoleApp.OrdnanceSurvey.Reader;

namespace ScotlandsMountains.Import.ConsoleApp
{
    public class Importer
    {
        public void Import()
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
