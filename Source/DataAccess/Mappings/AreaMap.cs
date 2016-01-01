using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.DataAccess.Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
