using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Data.Mappings
{
    public class MapPublisherMap : ClassMap<MapPublisher>
    {
        public MapPublisherMap()
        {
            Id(x => x.Id).Index("MapPublisherIndex");
            Map(x => x.Name);

            HasMany(x => x.MapSeries).KeyColumn("PublisherId").ForeignKeyConstraintName("Series_Publisher_FK");
        }
    }
}