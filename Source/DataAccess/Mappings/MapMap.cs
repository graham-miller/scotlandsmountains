using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.DataAccess.Mappings
{
    public class MapMap : ClassMap<Map>
    {
        public MapMap()
        {
            Id(x => x.Id);
            Map(x => x.Publisher);
            Map(x => x.Description);
            Map(x => x.Scale);
            Map(x => x.Code);
        }
    }
}
