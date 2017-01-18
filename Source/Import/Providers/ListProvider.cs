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
                .ToDictionary(listCode => listCode, listCode => ElementSelector(listCode, idGenerator, listInfoProvider));
        }

        private static List ElementSelector(string listCode, IIdGenerator idGenerator, IListInfoProvider listInfoProvider)
        {
            var listInfo = listInfoProvider.GetListInfoFor(listCode);

            return new List
            {
                Id = idGenerator.Generate(),
                Name = listInfo.Name,
                Order = listInfo.Order,
                Description = listInfo.Description,
                Enabled = listInfo.Enabled
            };
        }

        private readonly IDictionary<string, List> _lists;
    }
}
