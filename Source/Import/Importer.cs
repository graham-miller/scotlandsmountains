using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    public static class Importer
    {
        public static DomainRoot Import()
        {
            using (var dobihLoader = new DobihLoader())
            {
                return new DomainRoot
                {
                    Mountains = dobihLoader.Mountains
                };
            }
        }

        private static IEnumerable<DobihRecord> LoadMountainsFromDobih()
        {
            throw new NotImplementedException();
        }
    }

    internal class DobihRecord
    {
        public Mountain CreateEntity()
        {
            return new Mountain
            {
                Id = IdGenerator.Instance.GenerateId()
            };
        }
    }
}
