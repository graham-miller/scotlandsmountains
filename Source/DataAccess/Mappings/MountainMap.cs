using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain.Entities;

namespace DataAccess.Mappings
{
    public class MountainMap : ClassMap<Mountain>
    {
        public MountainMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.DobihId);

            Component(x => x.Height, m =>
            {
                m.Map(x => x.Feet).Column("Height_Feet");
                m.Map(x => x.Metres).Column("Height_Meters");
            });

            Component(x => x.Location, m =>
            {
                m.Component(x => x.GridReference, n =>
                {
                    n.Map(x => x.Letters).Column("Location_GridReference_Letters");
                    n.Map(x => x.Eastings).Column("Location_GridReference_Eastings");
                    n.Map(x => x.Northings).Column("Location_GridReference_Northings");
                });
                m.Map(x => x.Latitude).Column("Location_Latitude");
                m.Map(x => x.Longitude).Column("Location_Longitude");
                m.References(x => x.Area).Column("Location_AreaId").Cascade.None();
            });

            Component(x => x.Summit, m =>
            {
                m.Map(x => x.Feature).Column("Summit_Feature");
                m.Map(x => x.Observations).Column("Summit_Observations");
            });

            HasManyToMany(x => x.Maps)
                .Cascade.None()
                .ParentKeyColumn("MountainId")
                .ChildKeyColumn("MapId")
                .Cascade.None();

            References(x => x.Parent)
                .Column("ParentMountainId")
                .Cascade.None();

            HasManyToMany(x => x.Tables)
                .Cascade.None()
                .ParentKeyColumn("MountainId")
                .ChildKeyColumn("TableId")
                .Cascade.None();
        }
    }
}
