using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.DataAccess.Mappings
{
    public class TableMap : ClassMap<Table>
    {
        public TableMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);

            HasManyToMany(x => x.Mountains)
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .ParentKeyColumn("TableId")
                .ChildKeyColumn("MountainId");
        }
    }
}
