using System.Collections.Generic;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Mapping;

namespace ScotlandsMountains.DataAccess.AuxiliaryDatabaseObjects
{
    public class MountainsToTablePk : IAuxiliaryDatabaseObject
    {
        // Try using surrogate key field???

        public string SqlCreateString(Dialect dialect, IMapping p, string defaultCatalog, string defaultSchema)
        {
            return "ALTER TABLE MountainsToTables ADD CONSTRAINT PK_MountainsToTables PRIMARY KEY CLUSTERED (MountainId, TableId)";
        }

        public string SqlDropString(Dialect dialect, string defaultCatalog, string defaultSchema)
        {
            return "ALTER TABLE MountainsToTables DROP CONSTRAINT PK_MountainsToTables";
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
