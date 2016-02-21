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
            ReadDobihRecords();
            ReadMapRecords();
            CreateEntities();
        }

        private void ReadDobihRecords()
        {
            _records = new DobihReader(ImportConfiguration.DobihCsvPath, ImportConfiguration.DobihFilter).Read();
        }

        private void ReadMapRecords()
        {
            _maps = new OsReader(ImportConfiguration.ExplorerTxtPath, ImportConfiguration.ExplorerActiveTxtPath, ImportConfiguration.LandrangerTxtPath, ImportConfiguration.LandrangerActiveTxtPath).Read();
        }

        private void CreateEntities()
        {
            _entityFactory = new EntityFactory(_records, _maps);
        }

        private IList<Record> _records;
        private IList<Map> _maps;
        private EntityFactory _entityFactory;
    }
}
