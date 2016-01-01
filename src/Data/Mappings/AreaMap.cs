using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Data.Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap()
        {
            Id(x => x.Id).Index("AreasIndex");
            Map(x => x.Name);
            HasMany(x => x.Mountains).KeyColumn("AreaId");
        }
    }
}