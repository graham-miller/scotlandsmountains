using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain.Entities;

namespace DataAccess.Mappings
{
    public class TableMap : ClassMap<Table>
    {
        public TableMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);

            HasManyToMany(x => x.Mountains)
                .Cascade.None()
                .ParentKeyColumn("TableId")
                .ChildKeyColumn("MountainId")
                .Cascade.None();
        }
    }
}
