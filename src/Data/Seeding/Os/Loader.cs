using System;
using System.Collections.Generic;
using System.IO;
using ScotlandsMountains.Domain.Entities.Maps;

namespace ScotlandsMountains.Data.Seeding.OrdnanceSurvey
{
    internal class Loader
    {
        public List<Map> Maps { get; private set; }

        public Loader(Configuration configuration)
        {
            _configuration = configuration;
        }

        public void Load()
        {
            Maps = new List<Map>();
            Load<OsExplorerMap>(_configuration.OsExplorerTxtPath);
            Load<OsExplorerActiveMap>(_configuration.OsExplorerActiveTxtPath);
            Load<OsLandrangerMap>(_configuration.OsLandrangerTxtPath);
            Load<OsLandrangerActiveMap>(_configuration.OsLandrangerActiveTxtPath);
            Load<OsDiscoveryMap>(_configuration.OsDiscoveryTxtPath);
        }

        private void Load<T>(string path) where T : Map, new()
        {
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var record = new Record(reader.ReadLine());
                    var map = Activator.CreateInstance<T>();
                    map.Code = record.Code;
                    map.Name = record.Name;
                    map.Isbn = record.Isbn;
                    Maps.Add(map);
                }
            }
        }

        private readonly Configuration _configuration;

        internal class Configuration
        {
            public string OsExplorerTxtPath { get; set; }
            public string OsExplorerActiveTxtPath { get; set; }
            public string OsLandrangerTxtPath { get; set; }
            public string OsLandrangerActiveTxtPath { get; set; }
            public string OsDiscoveryTxtPath { get; set; }
        }
    }
}
