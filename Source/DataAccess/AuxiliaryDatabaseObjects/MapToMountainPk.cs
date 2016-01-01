using System.Collections.Generic;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Mapping;

namespace ScotlandsMountains.DataAccess.AuxiliaryDatabaseObjects
{
    public class MapToMountainPk : IAuxiliaryDatabaseObject
    {
        public string SqlCreateString(Dialect dialect, IMapping p, string defaultCatalog, string defaultSchema)
        {
            return "ALTER TABLE MapToMountain ADD CONSTRAINT PK_MapToMountain PRIMARY KEY CLUSTERED (MountainId, MapId)";
        }

        public string SqlDropString(Dialect dialect, string defaultCatalog, string defaultSchema)
        {
            return "ALTER TABLE MapToMountain DROP CONSTRAINT PK_MapToMountain";
        }

        public void AddDialectScope(string dialectName)
        {
        }

        public bool AppliesToDialect(Dialect dialect)
        {
            return true;
        }

        public void SetParameterValues(IDictionary<string, string> parameters)
        {
        }
    }
}
