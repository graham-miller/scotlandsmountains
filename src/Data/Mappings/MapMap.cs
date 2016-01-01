using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Data.Mappings
{
    public class MapMap : ClassMap<Map>
    {
        public MapMap()
        {
            Id(x => x.Id).Index("MapsIndex");
            Map(x => x.Name);

            HasManyToMany(x => x.Mountains)
                .ParentKeyColumn("MapId")
                .ChildKeyColumn("MountainId")
                .Table("MountainMaps")
                .Inverse();

            Map(x => x.Sheet);
            Map(x => x.Scale);
            Map(x => x.Isbn);
            Map(x => x.PublicationDate);
            Map(x => x.Edition);

            References(x => x.Series).ForeignKey("Map_Series_FK").Column("SeriesId");
            References(x => x.Publisher).ForeignKey("Map_Publisher_FK").Column("PublisherId");
        }
    }
}