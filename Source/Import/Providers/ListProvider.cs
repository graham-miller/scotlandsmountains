using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Import.ScotlandsMountains;

namespace ScotlandsMountains.Import.Providers
{
    public class ListProvider : IEntityProvider<List>
    {
        public ListProvider(IIdGenerator idGenerator, IDobihFile dobihFile, IListInfoProvider listInfoProvider)
        {
            _lists = LoadLists(idGenerator, dobihFile, listInfoProvider);
        }

        public IList<List> GetAll()
        {
            return _lists.Select(x => x.Value).OrderBy(x => x.Order).ToList();
        }

        public List GetByDobihId(string dobihId)
        {
            return _lists[dobihId];
        }

        private static Dictionary<string, List> LoadLists(IIdGenerator idGenerator, IDobihFile dobihFile, IListInfoProvider listInfoProvider)
        {
            return dobihFile.Records
                .SelectMany(x => x.Lists)
                .Distinct()
                .ToDictionary(
                    x => x,
                    x => new List
                    {
                        Id = idGenerator.Generate(),
                        Name = listInfoProvider.GetListInfoFor(x).Name,
                        Order = listInfoProvider.GetListInfoFor(x).Order,
                        Description = listInfoProvider.GetListInfoFor(x).Description
                    });
        }

        private readonly IDictionary<string, List> _lists;
    }
}
