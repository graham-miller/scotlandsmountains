using System;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories;
using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp
{
    public class Importer
    {
        public void Import()
        {
            ReadDobihRecords();
            ReadMapRecords();
            CreateEntities();
            //WriteEntitiesToFirebase();
            CreateMountains();
            //WriteMountainsToFirebase();
        }

        private void ReadDobihRecords()
        {
            _records = new DatabaseOfBritishAndIrishHills.Reader(ImportConfiguration.DobihCsvPath, ImportConfiguration.DobihFilter).Read();
        }

        private void ReadMapRecords()
        {
            _maps = new OrdnanceSurvey.Reader(ImportConfiguration.ExplorerTxtPath, ImportConfiguration.ExplorerActiveTxtPath, ImportConfiguration.LandrangerTxtPath, ImportConfiguration.LandrangerActiveTxtPath).Read();
        }

        private void CreateEntities()
        {
            _entityFactory = new EntityFactory(_records, _maps);
        }

        private void WriteEntitiesToFirebase()
        {
            using (var writer = new FirebaseWriter())
                writer.Write(_entityFactory);
        }

        private void CreateMountains()
        {
            _mountains = new MountainsFactory(_records, _entityFactory).Mountains;
        }

        private void WriteMountainsToFirebase()
        {
            using (var writer = new FirebaseWriter())
                writer.Write(_mountains);
        }

        private IList<Record> _records;
        private IList<Map> _maps;
        private IList<Mountain> _mountains;
        private EntityFactory _entityFactory;
    }
}
