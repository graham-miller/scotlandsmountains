using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Data.Mappings
{
    public class ClassificationMap : ClassMap<Classification>
    {
        public ClassificationMap()
        {
            Id(x => x.Id).Index("ClassificationIndex");
            Map(x => x.Name);

            HasManyToMany(x => x.Mountains)
                .ParentKeyColumn("ClassificationId")
                .ChildKeyColumn("MountainId")
                .Table("MountainClassifications")
                .Inverse();
        }
    }
}