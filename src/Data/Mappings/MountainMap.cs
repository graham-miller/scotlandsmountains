using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Data.Mappings
{
    public class MountainMap : ClassMap<Mountain>
    {
        public MountainMap()
        {
            Id(x => x.Id).Index("MountainsIndex");
            Map(x => x.Name);
            Map(x => x.SummitDescription);
            Map(x => x.SummitDetails);

            HasMany(x => x.Children).KeyColumn("ParentId");
            References(x => x.Parent).ForeignKey("Mountain_Parent_FK").Column("ParentId");

            References(x => x.Area).ForeignKey("Mountain_Area_FK").Column("AreaId");

            Component(x => x.Height, m => m.Map(x => x.Metres).Column("Height"));

            Component(x => x.Location, m =>
                {
                    m.Map(x => x.GridReference).Column("GridReference");
                    m.Map(x => x.Latitude).Column("Latitude");
                    m.Map(x => x.Longitude).Column("Longitude");
                });

            References(x => x.Country).ForeignKey("Mountain_Country_FK").Column("CountryId");

            HasManyToMany(x => x.Maps)
                .ParentKeyColumn("MountainId")
                .ChildKeyColumn("MapId")
                .ForeignKeyConstraintNames("Map_Mountain_FK", "Mountain_Map_FK")
                .Table("MountainMaps");


            Component(x => x.Prominence, m =>
                {
                    m.Component(x => x.Drop, n => n.Map(x => x.Metres).Column("Prominence"));
                    m.Component(Prominence.Expressions.MeasuredFromFeature, n =>
                    {
                        n.Component(x => x.Height, o => o.Map(x => x.Metres).Column("FeatureHeight"));
                        n.Map(x => x.Description).Column("FeatureDescription");
                    });
                    m.Component(Prominence.Expressions.MeasuredFromCol, n =>
                    {
                        n.Component(x => x.Height, o => o.Map(x => x.Metres).Column("ColHeight"));
                        n.Map(x => x.GridReference).Column("ColGridReference");
                    });
                });

            HasManyToMany(x => x.Classifications)
                .ParentKeyColumn("MountainId")
                .ChildKeyColumn("ClassificationId")
                .ForeignKeyConstraintNames("Classification_Mountain_FK", "Mountain_Classification_FK")
                .Table("MountainClassifications");

            Map(x => x.DobihNumber);
        }
    }
}
