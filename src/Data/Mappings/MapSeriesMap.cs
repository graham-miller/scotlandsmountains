using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Data.Mappings
{
    public class MapSeriesMap : ClassMap<MapSeries>
    {
        public MapSeriesMap()
        {
            Id(x => x.Id).Index("MapSeriesIndex");
            Map(x => x.Name);

            HasMany(x => x.Maps).KeyColumn("SeriesId").ForeignKeyConstraintName("Map_Series_FK");
        }
    }
}